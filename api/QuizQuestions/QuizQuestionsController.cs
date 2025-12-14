using api.QuizQuestions.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.QuizQuestions
{
    [ApiController]
    [Route("CASNatal/quizQuestions")]
    public class QuizQuestionsController : ControllerBase
    {
        public readonly IQuizQuestionsRepository _quizRep;

        public QuizQuestionsController(IQuizQuestionsRepository quizRep)
        {
            _quizRep = quizRep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithQuizOptions()
        {
            var questions = await _quizRep.GetAllWithQuizOptionsAsync();
            var questionsDto = questions.Select(q => q.ConvertToQuizQuestionsDto());
            if (questionsDto == null || !questionsDto.Any()) return NotFound();
            return Ok(questionsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdWithQuizOptions([FromRoute] Guid id)
        {
            var question = await _quizRep.GetByIdWithQuizOptionsAsync(id);
            if (question == null) return NotFound();
            return Ok(question.ConvertToQuizQuestionsDto());
        }

        [HttpGet("byLessonId/{id}")]
        public async Task<IActionResult> GetByLessonIdWithQuizOptions([FromRoute] Guid id)
        {
            var question = await _quizRep.GetByLessonIdWithQuizOptionsAsync(id);
            if (question == null) return NotFound();
            return Ok(question.ConvertToQuizQuestionsDto());
        }
    }
}
