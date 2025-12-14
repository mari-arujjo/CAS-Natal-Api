using api.QuizQuestions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.QuizOptions
{
    [Table("QuizOptions")]
    public class QuizOptionsModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid QuestionId { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        public QuizQuestionsModel QuizQuestion { get; set; }

    }
}
