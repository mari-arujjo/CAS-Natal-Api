using api.Generate_Codes;
using api.Lessons.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Logs
{
    [ApiController]
    [Route("CASNatal/logs")]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository _logRep;
        public LogController(ILogRepository logRepository)
        {
            _logRep = logRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLogs() {
            var logs = await _logRep.GetAllAsync();
            if (logs == null) return NotFound();
            return Ok(logs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var log = await _logRep.GetByIdAsync(id);
            if (log == null) return NotFound();
            return Ok(log);
        }
    }
}
