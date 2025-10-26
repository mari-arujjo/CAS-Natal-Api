using api.Enrollments.Dtos;

namespace api.Enrollments
{
    public static class EnrollmentMapper
    {
        public static EnrollmentDto ConvertToEnrollmentDto(this Enrollment e)
        {
            return new EnrollmentDto
            {
                Id = e.Id,
                EnrollmentCode = e.EnrollmentCode,
                Timestamp = e.Timestamp,
                Status = e.Status,
                ProgressPercentage = e.ProgressPercentage,
                CourseId = e.CourseId,
                UserId = e.UserId,
            };
        }
    }
}
