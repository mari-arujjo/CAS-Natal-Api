using api.Lessons.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Lessons
{
    [ApiController]
    [Route("CASNatal/lesson")]
    public class LessonController
    {
        private readonly ILessonRepository _lessonRep;
        public LessonController(ILessonRepository lessonRep)
        {
            _lessonRep = lessonRep;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {

        }
    }
}
