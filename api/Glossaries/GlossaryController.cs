using api.Generate_Codes;
using api.Glossaries.Dtos;
using api.Glossaries.Repository;
using api.Lessons.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Glossaries
{
    [ApiController]
    [Route("CASNatal/glossaries")]
    public class GlossaryController : ControllerBase
    {
        private readonly IGlossaryRepository _glossaryRep;
        private readonly ILessonRepository _lessonRep;
        public GlossaryController(IGlossaryRepository glossaryRep, ILessonRepository lessonRep)
        {
            _glossaryRep = glossaryRep;
            _lessonRep = lessonRep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var glossaries = await _glossaryRep.GetAllAsync();
            var glossariesDto = glossaries.Select(g => g.ConvertToGlossaryDto());
            if (glossariesDto == null) return NotFound();
            return Ok(glossariesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var glossary = await _glossaryRep.GetByIdAsync(id);
            if (glossary == null) return NotFound();
            return Ok(glossary.ConvertToGlossaryDto());
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByICategory([FromRoute] GlossaryCategory category)
        {
            var glossary = await _glossaryRep.GetByCategoryAsync(category);
            if (glossary == null) return NotFound();
            return Ok(glossary.ConvertToGlossaryDto());
        }

        [HttpPost("create/{lessonId}")]
        public async Task<IActionResult> NewGlossary([FromRoute] Guid lessonId,[FromBody] CreateGlossaryDto dto)
        {
            var lesson = await _lessonRep.GetByIdAsync(lessonId);
            if (lesson == null) return NotFound();

            var glossary = dto.CreateNewGlossaryDto();
            glossary.GlossaryCode = GenerateCodes.GenerateGlossaryCode(glossary.Id);            
            await _glossaryRep.CreateAsync(glossary);
            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = glossary.Id,
                },
                glossary.ConvertToGlossaryDto()
            );
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateGlossary([FromRoute] Guid id, CreateGlossaryDto dto)
        {
            var glossary = await _glossaryRep.GetByIdAsync(id);
            if (glossary == null) return NotFound();

            glossary.Sign = dto.Sign;
            glossary.Description = dto.Description;
            glossary.Url = dto.Url;
            //glossary.Photo = dto.Photo;
            glossary.Category = dto.Category;

            var courseUpdated = await _glossaryRep.UpdateAsync(glossary);
            return Ok(courseUpdated.ConvertToGlossaryDto());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteGlossary([FromRoute] Guid id)
        {
            var glossary = await _glossaryRep.DeleteAsync(id);
            if (glossary == null) return NotFound();
            return NoContent();
        }
    }
}
