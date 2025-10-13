using api.AppUserIdentity;
using api.Courses;
using api.Enrollments.Dtos;
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

        public async Task<Enrollment> CreateEnrollment(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
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
                Symbol = course.Course.Symbol,
                Description = course.Course.Description,
                Photo = course.Course.Photo,
                Lessons = course.Course.Lessons,
            }).ToListAsync();
        }

        public async Task<Enrollment> UpdateAsync(Guid id, UpdateEnrollmentDto dto)
        {
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
            if (enrollment == null) return null;

            enrollment.Status = dto.Status;

            await _context.SaveChangesAsync();
            return enrollment;
        }
    }
}
