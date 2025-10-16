using api.Generate_Codes;
using api.Glossaries.Dtos;
using api.Glossaries.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Glossaries
{
    [ApiController]
    [Route("CASNatal/glossary")]
    public class GlossaryController : ControllerBase
    {
        private readonly IGlossaryRepository _glossaryRep;
        public GlossaryController(IGlossaryRepository glossaryRep)
        {
            _glossaryRep = glossaryRep;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var glossaries = await _glossaryRep.GetAllAsync();
            var glossariesDto = glossaries.Select(g => g.ConvertToGlossaryDto());
            if (glossariesDto == null) return NotFound();
            return Ok(glossariesDto);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var glossary = await _glossaryRep.GetByIdAsync(id);
            if (glossary == null) return NotFound();
            return Ok(glossary.ConvertToGlossaryDto());
        }

        [HttpGet("getByCategory/{category}")]
        public async Task<IActionResult> GetByICategory(GlossaryCategory category)
        {
            var glossary = await _glossaryRep.GetByCategoryAsync(category);
            if (glossary == null) return NotFound();
            return Ok(glossary.ConvertToGlossaryDto());
        }

        [HttpPost("postGlossary")]
        public async Task<IActionResult> NewGlossary([FromBody] CreateGlossaryDto dto)
        {
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
    }
}
