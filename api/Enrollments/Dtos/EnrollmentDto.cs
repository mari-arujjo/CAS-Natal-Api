using api.AppUserIdentity;
using api.Courses;

namespace api.Enrollments.Dtos
{
    public class EnrollmentDto
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string enrollmentCode { get; set; } = string.Empty;
        public EnrollmentStatus status { get; set; } = EnrollmentStatus.Active;
        public int progressPercentage { get; set; } = 0;
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
        public DateTime updatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? deletedAt { get; set; }

        public Guid courseId { get; set; }
        public string userId { get; set; } = string.Empty;
    }
}
