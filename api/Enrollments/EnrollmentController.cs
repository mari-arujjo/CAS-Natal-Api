using api.AppUserIdentity;
using api.Claims;
using api.Courses.Repository;
using api.Enrollments.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Enrollments
{
    [ApiController]
    [Route("CASNatal/enrollment")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRep;
        private readonly UserManager<AppUser> _userMan;
        private readonly ICourseRepository _courseRep;
        public EnrollmentController(IEnrollmentRepository enrollmentRep, UserManager<AppUser> userMan, ICourseRepository courseRep)
        {
            _enrollmentRep = enrollmentRep;
            _userMan = userMan;
            _courseRep = courseRep;
        }

        [HttpGet("getUserEnrollment")]
        [Authorize]
        public async Task<IActionResult> GetUserEnrollment()
        {
            var username = User.GetUsername();
            if (string.IsNullOrEmpty(username)) return BadRequest("Invalid token or username not found in token.");

            var appUser = await _userMan.FindByNameAsync(username);
            if (appUser == null) return BadRequest("User does not exists.");

            var userEnrollment = await _enrollmentRep.GetUserEnrollment(appUser);
            return Ok(userEnrollment);
        }
    }
}
