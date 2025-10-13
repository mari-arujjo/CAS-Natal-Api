using api.Courses;
using api.Glossaries;

namespace api.Lessons.Dtos
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public string LessonCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool Completed { get; set; } = false;
        public string Url { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Guid CourseId { get; set; }
        public List<Glossary> Glossaries { get; set; } = new List<Glossary>();
    }
}
