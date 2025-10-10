using api.AppUserIdentity;
using api.Courses;
using Microsoft.EntityFrameworkCore;

namespace api.Enrollments.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Enrollment>> GetEnrollment()
        {
            return _context.Enrollments.ToListAsync();
        }

        public async Task<List<Course>> GetUserEnrollment(AppUser user)
        {
            return await _context.Enrollments.Where(u => u.UserId == user.Id)
            .Select(course => new Course
            {
                Id = course.Course.Id,
                Name = course.Course.Name,
                Abbreviation = course.Course.Abbreviation,
                Description = course.Course.Description,
                Photo = course.Course.Photo,
                Lessons = course.Course.Lessons,
            }).ToListAsync();
        }
    }
}
