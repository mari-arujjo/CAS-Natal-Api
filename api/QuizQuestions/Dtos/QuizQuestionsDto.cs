using api.Lessons;
using api.QuizOptions;
using api.QuizOptions.Dtos;

namespace api.QuizQuestions.Dtos
{
    public class QuizQuestionsDto
    {
        public Guid id { get; set; }
        public Guid lessonId { get; set; }
        public string questionText { get; set; } = string.Empty;
        public string feedback { get; set; } = string.Empty;
        public int order { get; set; }
        public List<QuizOptionsDto> quizOptions { get; set; } = new List<QuizOptionsDto>();
    }
}
