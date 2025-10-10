using api.AppUserIdentity;
using api.Courses;

namespace api.Enrollments.Repository
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetEnrollment();
        Task<List<Course>> GetUserEnrollment(AppUser user);
        Task<Enrollment> CreateEnrollment(Enrollment enrollment);
    }
}
