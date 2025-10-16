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

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var glossaries = await _glossaryRep.GetAllAsync();
            var glossariesDto = glossaries.Select(g => g.ConvertToGlossaryDto());
            if (glossariesDto == null) return NotFound();
            return Ok(glossariesDto);
        }
    }
}
