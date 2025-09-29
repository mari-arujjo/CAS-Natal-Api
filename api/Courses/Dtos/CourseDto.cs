using api.Enrollments;
using api.Lessons;
using System.ComponentModel.DataAnnotations;

namespace api.Courses.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Photo { get; set; } = Array.Empty<byte>();
        //public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        //public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
