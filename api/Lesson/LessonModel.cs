using api.Glossary;
using System.ComponentModel.DataAnnotations;

namespace api.Lesson
{
    public class LessonModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public List<GlossaryModel> Glossaries { get; set; } = new();
    }
}
