using api.Enrollments.Dtos;

namespace api.Enrollments
{
    public static class EnrollmentMapper
    {
        public static EnrollmentDto ConvertToEnrollmentDto(this Enrollment e)
        {
            return new EnrollmentDto
            {
                id = e.Id,
                enrollmentCode = e.EnrollmentCode,
                status = e.Status,
                progressPercentage = e.ProgressPercentage,
                courseId = e.CourseId,
                userId = e.UserId,
                createdAt = e.CreatedAt,
                updatedAt = e.UpdatedAt,
                deletedAt = e.DeletedAt,
            };
        }
    }
}
