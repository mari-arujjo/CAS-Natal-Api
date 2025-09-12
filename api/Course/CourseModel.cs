using api.Lesson;
using System.ComponentModel.DataAnnotations;

namespace api.Course
{
    public class CourseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Photo { get; set; } = Array.Empty<byte>();
        public string Status { get; set; } = string.Empty;
        public List<LessonModel> Lessons { get; set; } = new();
    }
}
