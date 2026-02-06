using api.Lessons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.LessonTopics
{
    [Table("LessonTopic")]
    public class LessonTopic
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Order { get; set; }
        public string Title { get; set; } = string.Empty;
        public string TextContent { get; set; } = string.Empty;

        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
