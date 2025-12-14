using api.Lessons;
using api.QuizOptions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.QuizQuestions
{
    [Table("QuizQuestions")]
    public class QuizQuestionsModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid LessonId { get; set; } = Guid.NewGuid();
        public string QuestionText { get; set; }
        public string Feedback { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        public ICollection<QuizOptionsModel> QuizOptions { get; set; }
        public Lesson Lesson { get; set; }

    }
}
