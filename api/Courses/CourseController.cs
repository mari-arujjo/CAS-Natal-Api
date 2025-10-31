using api.Courses.Dtos;
using api.Courses.Repository;
using api.Generate_Codes;
using api.Logs;
using Microsoft.AspNetCore.Mvc;

namespace api.Courses
{

    [ApiController]
    [Route("CASNatal/courses")]
    public class CourseController : ControllerBase
    {
        public readonly ICourseRepository _courseRep;
        public readonly ILogRepository _logRep;
        public CourseController(ICourseRepository courseRep, ILogRepository logRep)
        {
            _courseRep = courseRep;
            _logRep = logRep;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseRep.GetAllAsync();
            var coursesDto = courses.Select(c => c.ConvertToCourseDto());
            if (coursesDto == null) return NotFound();
            return Ok(coursesDto);
        }

        [HttpGet("lessons")]
        public async Task<IActionResult> GetAllWithLessons()
        {
            var courses = await _courseRep.GetAllWithLessonsAsync();
            var coursesDto = courses.Select(c => c.ConvertToCourseDto());
            if (coursesDto == null) return NotFound();
            return Ok(coursesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var course = await _courseRep.GetByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course.ConvertToCourseDto());
        }

        [HttpGet("symbol/{symbol}")]
        public async Task<IActionResult> GetBySymbol([FromRoute] string symbol)
        {
            var course = await _courseRep.GetBySymbol(symbol);
            if (course == null) return NotFound();
            return Ok(course.ConvertToCourseDto());
        }

        [HttpPost("create")]
        public async Task<IActionResult> NewCourse([FromBody] CreateCourseDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = dto.CreateNewCourseDto();
            course.CourseCode = GenerateCodes.GenerateCourseCode(course.Symbol, course.Id);
            await _courseRep.CreateAsync(course);
            var logSuccess = new Log
            {
                Timestamp = DateTime.UtcNow,
                UserId = null,
                SourceIp = null,
                Action = "CREATE",
                Status = "SUCCESS",
                Table = "Courses",
                RecordId = null,
                BeforeState = null,
                AfterState = null,
                Details = null
            };
            await _logRep.CreateAsync(logSuccess);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = course.Id,
                },
                course.ConvertToCourseDto()
            );
        }
            

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePutCourse([FromRoute] Guid id, [FromBody] UpdateCourseDto dto)
        {
            var course = await _courseRep.GetByIdAsync(id);
            if (course == null) return NotFound();

            course.Name = dto.Name;
            course.Symbol = dto.Symbol;
            course.Description = dto.Description;
            //course.Photo = dto.Photo;

            var courseUpdated = await _courseRep.UpdateAsync(course);
            return Ok(courseUpdated.ConvertToCourseDto());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] Guid id)
        {
            var course = await _courseRep.DeleteAsync(id);
            if (course == null) return NotFound();
            return NoContent();
        }

    }
}
