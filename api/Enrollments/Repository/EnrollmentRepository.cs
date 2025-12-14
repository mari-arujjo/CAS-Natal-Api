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

        public async Task<Enrollment?> DeleteAsync(Guid id)
        {
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
            if (enrollment == null) return null;

            enrollment.Status = EnrollmentStatus.Inactive;
            enrollment.UpdatedAt = DateTime.UtcNow;
            enrollment.DeletedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return enrollment;
        }

        public Task<List<Enrollment>> GetEnrollment()
        {
            return _context.Enrollments.ToListAsync();
        }

        public async Task<List<CourseEnrollmentDto>> GetCourseUserEnrollment(AppUser user)
        {
            return await _context.Enrollments
            .Where(u => u.UserId == user.Id)
            .Select(enrollment => new CourseEnrollmentDto
            {
                enrollmentId = enrollment.Id,
                courseId = enrollment.Course.Id,
                courseCode = enrollment.Course.CourseCode,
                name = enrollment.Course.Name,
                symbol = enrollment.Course.Symbol,
                description = enrollment.Course.Description,
                photo = enrollment.Course.Photo,
                //lessons = enrollment.Course.Lessons,
            }).ToListAsync();
        }

        public async Task<Enrollment> UpdateAsync(Guid id, UpdateEnrollmentDto dto)
        {
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
            if (enrollment == null) return null;

            enrollment.Status = dto.status;
            enrollment.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return enrollment;
        }
    }
}
