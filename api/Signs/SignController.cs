using api.Generate_Codes;
using api.Glossaries;
using api.Lessons.Repository;
using api.Signs.Dtos;
using api.Signs.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Signs
{
    [ApiController]
    [Route("CASNatal/signs")]
    public class SignController : ControllerBase
    {
        private readonly ISignRepository _signRep;
        private readonly ILessonRepository _lessonRep;
        public SignController(ISignRepository signsRep, ILessonRepository lessonRep)
        {
            _signRep = signsRep;
            _lessonRep = lessonRep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var signs = await _signRep.GetAllAsync();
            var signsDto = signs.Select(g => g.ConvertToSignDto());
            if (signsDto == null) return NotFound();
            return Ok(signsDto);
        }

        [HttpGet("lessons")]
        public async Task<IActionResult> GetAllWithLessons()
        {
            var sign = await _signRep.GetAllWithLessonsAsync();
            var signsDto = sign.Select(g => g.ConvertToSignDto());
            if (signsDto == null) return NotFound();
            return Ok(signsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var sign = await _signRep.GetByIdAsync(id);
            if (sign == null) return NotFound();
            return Ok(sign.ConvertToSignDto());
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByICategory([FromRoute] SignCategory category)
        {
            var sign = await _signRep.GetByCategoryAsync(category);
            if (sign == null) return NotFound();
            return Ok(sign.ConvertToSignDto());
        }

        [HttpPost("create/{lessonId}")]
        public async Task<IActionResult> NewSignOneLesson([FromRoute] Guid lessonId, [FromBody] CreateSignDto dto)
        {
            var lesson = await _lessonRep.GetByIdAsync(lessonId);
            if (lesson == null) return NotFound();

            var sign = dto.CreateNewSignDto();
            sign.SignCode = GenerateCodes.GenerateGlossaryCode(sign.Id);
            sign.Lessons.Add(lesson);
            await _signRep.CreateAsync(sign);
            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = sign.Id,
                },
                sign.ConvertToSignDto()
            );
        }

        [HttpPost("create")]
        public async Task<IActionResult> NewSignManyLessons([FromBody] CreateSignDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var sign = dto.CreateNewSignDto();
            sign.SignCode = GenerateCodes.GenerateGlossaryCode(sign.Id);

            if (dto.lessonIds is { Count: > 0 })
            {
                var distinctIds = dto.lessonIds.Distinct().ToList();
                var lessons = await _lessonRep.GetByIdsAsync(distinctIds);

                var found = lessons.Select(l => l.Id).ToHashSet();
                var notFound = distinctIds.Where(id => !found.Contains(id)).ToList();
                if (notFound.Count > 0)
                {
                    return BadRequest(new
                    {
                        error = "Some lessonIds were not found.",
                        lessonIdsNotFound = notFound
                    });
                }

                foreach (var lesson in lessons)
                    sign.Lessons.Add(lesson);
            }

            await _signRep.CreateAsync(sign);

            return CreatedAtAction(
                nameof(GetById),
                new { id = sign.Id },
                sign.ConvertToSignDto()
            );
        }


        [HttpPatch("update/{id}")]
        public async Task<IActionResult> PatchSign([FromRoute] Guid id, UpdateSignDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var sign = await _signRep.UpdateAsync(id, dto);
            if (sign == null) return NotFound();
            return Ok(sign.ConvertToSignDto());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSign([FromRoute] Guid id)
        {
            var sign = await _signRep.DeleteAsync(id);
            if (sign == null) return NotFound();
            return NoContent();
        }
    }
}