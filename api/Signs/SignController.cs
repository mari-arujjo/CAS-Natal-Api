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
    [Route("CASNatal/glossaries")]
    public class SignController : ControllerBase
    {
        private readonly ISignRepository _signRep;
        private readonly ILessonRepository _lessonRep;
        public SignController(ISignRepository glossaryRep, ILessonRepository lessonRep)
        {
            _signRep = glossaryRep;
            _lessonRep = lessonRep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var signs = await _signRep.GetAllAsync();
            var signsDto = signs.Select(g => g.ConvertToGlossaryDto());
            if (signsDto == null) return NotFound();
            return Ok(signsDto);
        }

        [HttpGet("lessons")]
        public async Task<IActionResult> GetAllWithLessons()
        {
            var glossaries = await _signRep.GetAllWithLessonsAsync();
            var glossariesDto = glossaries.Select(g => g.ConvertToGlossaryDto());
            if (glossariesDto == null) return NotFound();
            return Ok(glossariesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var glossary = await _signRep.GetByIdAsync(id);
            if (glossary == null) return NotFound();
            return Ok(glossary.ConvertToGlossaryDto());
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByICategory([FromRoute] GlossaryCategory category)
        {
            var glossary = await _signRep.GetByCategoryAsync(category);
            if (glossary == null) return NotFound();
            return Ok(glossary.ConvertToGlossaryDto());
        }

        [HttpPost("create/{lessonId}")]
        public async Task<IActionResult> NewGlossaryOneLesson([FromRoute] Guid lessonId,[FromBody] CreateSignDto dto)
        {
            var lesson = await _lessonRep.GetByIdAsync(lessonId);
            if (lesson == null) return NotFound();

            var glossary = dto.CreateNewGlossaryDto();
            glossary.SignCode = GenerateCodes.GenerateGlossaryCode(glossary.Id);
            glossary.Lessons.Add(lesson);
            await _signRep.CreateAsync(glossary);
            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = glossary.Id,
                },
                glossary.ConvertToGlossaryDto()
            );
        }

        [HttpPost("create")]
        public async Task<IActionResult> NewGlossaryManyLessons([FromBody] CreateSignDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var glossary = dto.CreateNewGlossaryDto();
            glossary.SignCode = GenerateCodes.GenerateGlossaryCode(glossary.Id);

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
                    glossary.Lessons.Add(lesson);
            }

            await _signRep.CreateAsync(glossary);

            return CreatedAtAction(
                nameof(GetById),
                new { id = glossary.Id },
                glossary.ConvertToGlossaryDto()
            );
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateGlossary([FromRoute] Guid id, UpdateSignDto dto)
        {
            var sign = await _signRep.UpdateAsync(id, dto);
            if (sign == null) return NotFound();
            return Ok(sign.ConvertToGlossaryDto());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteGlossary([FromRoute] Guid id)
        {
            var glossary = await _signRep.DeleteAsync(id);
            if (glossary == null) return NotFound();
            return NoContent();
        }
    }
}
