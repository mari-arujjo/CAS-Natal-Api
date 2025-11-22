using api.AppUserIdentity;
using api.Courses;
using api.Lessons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Enrollments
{
    [Table("Enrollments")]
    public class Enrollment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string EnrollmentCode { get; set; } = string.Empty; //HCN-2025-hash do guid
        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Active;
        public int ProgressPercentage { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        ////////////////////////////////////////////////////
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; }


    }

    public enum EnrollmentStatus
    {
        Active,
        Inactive,
        Completed,
    }
}