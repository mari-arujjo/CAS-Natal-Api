using api.Courses;
using api.Glossaries;
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
        public bool Completed { get; set; } = false;
        public string Url { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public List<Glossary> Glossaries { get; set; } = new List<Glossary>();

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
