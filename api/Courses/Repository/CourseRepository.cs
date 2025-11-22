using api.Courses.Dtos;
using Microsoft.EntityFrameworkCore;

namespace api.Courses.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Course> CreateAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course?> DeleteAsync(Guid id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return null;
            course.UpdatedAt = DateTime.UtcNow;
            course.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return course;
        }
        public Task<bool> ExistsAsync(Guid id)
        {
            return _context.Courses.AnyAsync(c => c.Id == id);
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<List<Course>> GetAllWithLessonsAsync()
        {
            return await _context.Courses.Include(l => l.Lessons).ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(Guid id)
        {
            return await _context.Courses.Include(l => l.Lessons).Include(e => e.Enrollments).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course?> GetBySymbol(string symbol)
        {
            return await _context.Courses.Include(l => l.Lessons).FirstOrDefaultAsync(a => a.Symbol == symbol);
        }

        public async Task<Course> UpdateAsync(Guid id, UpdateCourseDto dto)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return null;

            course.Name = dto.Name;
            course.Symbol = dto.Symbol;
            course.Description = dto.Description;
            course.UpdatedAt = DateTime.UtcNow;
            //course.Photo = dto.Photo;
            await _context.SaveChangesAsync();
            return course;
        }
    }
}
