using api.Courses;
using api.LessonTopics;
using api.QuizQuestions;
using api.Signs;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Lessons
{
    [Table("Lessons")]
    public class Lesson
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string LessonCode { get; set; } = string.Empty; //LS-HCN-hash do guid
        public string Name { get; set; } = string.Empty; 
        
        [DefaultValue(false)]
        public bool Completed { get; set; } = false;
        public string Url { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty; 
        public List<LessonTopic> LessonTopics { get; set; } = new List<LessonTopic>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }

        public List<Sign> Signs { get; set; } = new List<Sign>();
        public ICollection<QuizQuestionsModel> QuizQuestions { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
