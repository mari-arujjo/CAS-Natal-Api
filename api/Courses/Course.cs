using api.Enrollments;
using api.Lessons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Courses
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Photo { get; set; } = Array.Empty<byte>();

        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
