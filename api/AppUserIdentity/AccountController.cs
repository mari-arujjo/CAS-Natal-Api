using api.AppUserIdentity.Dtos;
using api.Service;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDto = users.Select(u => u.ConvertToUserDto());
            if (usersDto == null) return NotFound();
            return Ok(usersDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == dto.username.ToLower());
            if (user == null) return Unauthorized("Username ou senha inválidos.");
            if (user.Active == false) return Unauthorized("");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.password, false);
            if(!result.Succeeded) return Unauthorized("Username ou senha inválidos.");
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
                    CreatedAt = DateTime.UtcNow,
                    Active = true,
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
                                token = _tokenService.CreateToken(appUser),
                                createdAt = appUser.CreatedAt,
                                active = appUser.Active
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
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    DeletedAt = null
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
                                token = _tokenService.CreateToken(appUser),
                                createdAt = appUser.CreatedAt,
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

        
        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto dto)
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username)) return Unauthorized();

            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound("Usuário não encontrado.");
            if (user.Active == false) return Unauthorized();

            user.FullName = dto.name;
            user.UserName = dto.username;
            user.Email = dto.email;
            user.UpdatedAt = DateTime.UtcNow;
            user.Active = dto.active;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                return StatusCode(500, updateResult.Errors);
            }

            var newToken = _tokenService.CreateToken(user);

            return Ok(
                new NewUserDto
                {
                    name = user.FullName,
                    username = user.UserName,
                    email = user.Email,
                    privateRole = user.PrivateRole,
                    token = newToken,
                }
            );
        }


        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username)) return Unauthorized();

            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound("Usuário não encontrado.");

            user.Active = false;
            user.DeletedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            var deleteResult = await _userManager.UpdateAsync(user);
            if (!deleteResult.Succeeded)
            {
                return StatusCode(500, deleteResult.Errors);
            }

            return NoContent();
        }

    }
}
