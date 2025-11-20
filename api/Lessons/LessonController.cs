using api.Courses;
using api.Courses.Repository;
using api.Enrollments;
using api.Generate_Codes;
using api.Lessons.Dtos;
using api.Lessons.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Lessons
{
    [ApiController]
    [Route("CASNatal/lessons")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRep;
        private readonly ICourseRepository _courseRep;
        public LessonController(ILessonRepository lessonRep, ICourseRepository courseRep)
        {
            _lessonRep = lessonRep;
            _courseRep = courseRep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lessons = await _lessonRep.GetAllAsync();
            var lessonsDto = lessons.Select(l => l.ConvertToLessonDto());
            if (lessonsDto == null) return NotFound();
            return Ok(lessonsDto);
        }

        [HttpGet("glossaries")]
        public async Task<IActionResult> GetAllWithGlossaries()
        {
            var lessons = await _lessonRep.GetAllWithGlossariesAsync();
            var lessonsDto = lessons.Select(l => l.ConvertToLessonDto());
            if (lessonsDto == null) return NotFound();
            return Ok(lessonsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var lessons = await _lessonRep.GetByIdAsync(id);
            if (lessons == null) return NotFound();
            return Ok(lessons.ConvertToLessonDto()); 
        }

        [HttpPost("create/{courseId}")]
        public async Task<IActionResult> NewLesson([FromRoute] Guid courseId, [FromBody] CreateLessonDto dto)
        {
            var course = await _courseRep.GetByIdAsync(courseId);
            if (course == null) return BadRequest("Curso não existe.");

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

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePutLesson([FromRoute] Guid id, [FromBody] UpdateLessonDto dto)
        {
            var lesson = await _lessonRep.GetByIdAsync(id);
            if (lesson == null) return NotFound();

            lesson.Name = dto.Name;
            lesson.Completed = dto.Completed;
            lesson.Url = dto.Url;
            lesson.Content = dto.Content;

            var lessonUpdated = await _lessonRep.UpdateAsync(lesson);
            return Ok(lessonUpdated.ConvertToLessonDto());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> UpdatePutLesson([FromRoute] Guid id)
        {
            var lesson = await _lessonRep.DeleteAsync(id);
            if (lesson == null) return NotFound();
            return NoContent();
        }
    }
}
