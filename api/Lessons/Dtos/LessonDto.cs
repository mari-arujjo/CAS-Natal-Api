using api.Courses;
using api.Glossaries;

namespace api.Lessons.Dtos
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Completed { get; set; } = false;
        public string Url { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        //public ICollection<Glossary> Glossaries { get; set; } = new List<Glossary>();

        //public int CourseId { get; set; }
        //public Course Course { get; set; } //navigation propriety
    }
}
