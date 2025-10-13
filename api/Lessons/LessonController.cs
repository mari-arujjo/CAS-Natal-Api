using api.Courses;
using api.Courses.Repository;
using api.Enrollments;
using api.Generate_Codes;
using api.Lessons.Dtos;
using api.Lessons.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Lessons
{
    [ApiController]
    [Route("CASNatal/lesson")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRep;
        private readonly ICourseRepository _courseRep;
        public LessonController(ILessonRepository lessonRep, ICourseRepository courseRep)
        {
            _lessonRep = lessonRep;
            _courseRep = courseRep;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var lessons = await _lessonRep.GetAllAsync();
            var lessonsDto = lessons.Select(l => l.ConvertToLessonDto());
            if (lessonsDto == null) return NotFound();
            return Ok(lessonsDto);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var lessons = await _lessonRep.GetByIdAsync(id);
            if (lessons == null) return NotFound();
            return Ok(lessons.ConvertToLessonDto()); 
        }

        [HttpPost("postLesson/{courseId}")]
        public async Task<IActionResult> NewLesson([FromRoute] Guid courseId, [FromBody] CreateLessonDto dto)
        {
            var course = await _courseRep.GetByIdAsync(courseId);
            if (course == null) return BadRequest("Course does not exist.");

            var lesson = dto.CreateNewLessonDto(courseId);
            lesson.LessonCode = GenerateCodes.GenerateLessonCode(course.Symbol, lesson.Id);
            await _lessonRep.CreateAsync(lesson);
            return CreatedAtAction
            (
            nameof(GetById),
                new
                {
                    id = lesson.Id, 
                },
                lesson.ConvertToLessonDto()
            );
        }

        [HttpPut("putLesson/{id}")]
        public async Task<IActionResult> UpdatePutLesson([FromRoute] Guid id, [FromBody] UpdateLessonDto dto)
        {
            var lesson = await _lessonRep.UpdateAsync(id, dto);
            if (lesson == null) return NotFound();
            return Ok(lesson.ConvertToLessonDto());
        }

        [HttpDelete("deleteLesson/{id}")]
        public async Task<IActionResult> UpdatePutLesson([FromRoute] Guid id)
        {
            var lesson = await _lessonRep.DeleteAsync(id);
            if (lesson == null) return NotFound();
            return NoContent();
        }
    }
}
