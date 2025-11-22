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
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CourseCode { get; set; } = string.Empty; //CS-HCN-hash do guid
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Photo { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }

        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
