using api.AppUserIdentity;
using api.Courses;
using api.Courses.Dtos;
using api.Enrollments.Dtos;

namespace api.Enrollments.Repository
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetEnrollment();
        Task<List<CourseEnrollmentDto>> GetCourseUserEnrollment(AppUser user);
        Task<Enrollment> CreateEnrollment(Enrollment enrollment);
        Task<Enrollment> UpdateAsync(Guid id, UpdateEnrollmentDto dto);
        Task<Enrollment?> DeleteAsync(Guid id);

    }
}
