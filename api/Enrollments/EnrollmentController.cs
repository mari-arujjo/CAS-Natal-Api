using api.AppUserIdentity;
using api.Courses.Dtos;
using api.Courses.Repository;
using api.Enrollments.Dtos;
using api.Enrollments.Repository;
using api.Generate_Codes;
using api.Services.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Enrollments
{
    [ApiController]
    [Route("CASNatal/enrollments")]
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

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAll()
        {
            var enrollment = await _enrollmentRep.GetEnrollment();
            return Ok(enrollment);
        }

        [HttpGet("getCourseUserEnrollment")]
        [Authorize]
        public async Task<IActionResult> GetCourseUserEnrollment()
        {
            var username = User.GetUsername();
            if (string.IsNullOrEmpty(username)) return BadRequest("Token inválido ou username não encontrado no token.");

            var appUser = await _userMan.FindByNameAsync(username);
            if (appUser == null) return BadRequest("Usuário não existe");

            var userEnrollment = await _enrollmentRep.GetCourseUserEnrollment(appUser);
            return Ok(userEnrollment);
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> NewEnrollment(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userMan.FindByNameAsync(username);
            var course = await _courseRep.GetBySymbol(symbol);
            if (course == null) return BadRequest("Curso não encontrado.");

            var userEnrollment = await _enrollmentRep.GetCourseUserEnrollment(appUser);
            if (userEnrollment.Any(e => e.symbol.ToLower() == symbol.ToLower())) return BadRequest("O usuário já está matriculado neste curso.");
            var enrollment = new Enrollment();
            enrollment.CourseId = course.Id;
            enrollment.UserId = appUser.Id;
            enrollment.EnrollmentCode = GenerateCodes.GenerateEnrollmentCode(course.Symbol, enrollment.Id);
            enrollment.Status = EnrollmentStatus.Active;
            enrollment.ProgressPercentage = 0;
            enrollment.CreatedAt = DateTime.UtcNow;
            enrollment.UpdatedAt = DateTime.UtcNow;
            enrollment.DeletedAt = null;

            await _enrollmentRep.CreateEnrollment(enrollment);
            if (enrollment == null) return BadRequest("Matrícula não foi criada.");
            return Created("", enrollment.ConvertToEnrollmentDto());
        }


        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateEnrollment([FromRoute] Guid id, [FromBody] UpdateEnrollmentDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var enrollment = await _enrollmentRep.UpdateAsync(id, dto);
            if (enrollment == null) return NotFound();
            return Ok(enrollment.ConvertToEnrollmentDto());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEnrollment([FromRoute] Guid id)
        {
            var enrollment = await _enrollmentRep.DeleteAsync(id);
            if (enrollment == null) return NotFound();
            return NoContent();
        }
    }
}
