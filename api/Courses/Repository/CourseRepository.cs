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
            _context.Courses.Remove(course);
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

        public async Task<Course> UpdateAsync(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return course;
        }
    }
}
