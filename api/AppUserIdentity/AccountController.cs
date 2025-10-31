using api.AppUserIdentity.Dtos;
using api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.AppUserIdentity
{
    [ApiController]
    [Route("CASNatal/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllWithLessons()
        {
            var users = await _userManager.Users.ToListAsync();
            if (users == null) return NotFound();
            return Ok(users);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == dto.username.ToLower());
            if (user == null) return Unauthorized("Invalid username or password.");
            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.password, false);
            if(!result.Succeeded) return Unauthorized("Invalid username or password.");
            return Ok(
                new NewUserDto
                {
                    name = user.FullName,
                    username = user.UserName,
                    email = user.Email,
                    privateRole = user.PrivateRole,
                    token = _tokenService.CreateToken(user)
                }
            );
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var defaultRole = "Default";
                var appUser = new AppUser
                {
                    FullName = dto.name,
                    UserName = dto.username,
                    Email = dto.email,
                    PrivateRole = defaultRole,
                };

                var createdUser = await _userManager.CreateAsync(appUser, dto.password);
                if (createdUser.Succeeded)
                {
                    var userRole = await _userManager.AddToRoleAsync(appUser, "Default");
                    if (userRole.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                name = appUser.FullName,
                                username = appUser.UserName,
                                email = appUser.Email,
                                privateRole = appUser.PrivateRole,
                                token = _tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, userRole.Errors);

                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [Authorize]
        [HttpPost("registerAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var defaultRole = "Admin";
                var appUser = new AppUser
                {
                    FullName = dto.name,
                    UserName = dto.username,
                    Email = dto.email,
                    PrivateRole = defaultRole,
                };

                var createdUser = await _userManager.CreateAsync(appUser, dto.password);
                if (createdUser.Succeeded)
                {
                    var userRole = await _userManager.AddToRoleAsync(appUser, "Admin");
                    if (userRole.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                name = appUser.FullName,
                                username = appUser.UserName,
                                email = appUser.Email,
                                privateRole = appUser.PrivateRole,
                                token = _tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, userRole.Errors);

                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
