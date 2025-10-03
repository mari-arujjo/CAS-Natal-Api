using api.AppUserIdentity;
using api.Courses;

namespace api.Enrollments.Repository
{
    public interface IEnrollmentRepository
    {
        Task<List<Course>> GetUserEnrollment(AppUser user);
    }
}
