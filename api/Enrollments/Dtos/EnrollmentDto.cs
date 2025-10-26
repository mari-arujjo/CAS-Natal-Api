using api.AppUserIdentity;
using api.Courses;

namespace api.Enrollments.Dtos
{
    public class EnrollmentDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string EnrollmentCode { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Active;
        public int ProgressPercentage { get; set; } = 0;
        public Guid CourseId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
