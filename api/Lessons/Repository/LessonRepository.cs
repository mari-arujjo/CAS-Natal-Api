using api.Courses;
using api.Lessons.Dtos;
using Microsoft.EntityFrameworkCore;

namespace api.Lessons.Repository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _context;
        public LessonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Lesson> CreateAsync(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<Lesson?> DeleteAsync(Guid id)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);
            if (lesson == null) return null;
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public Task<bool> ExistsAsync(Guid id)
        {

            return _context.Lessons.AnyAsync(c => c.Id == id);
        }

        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<List<Lesson>> GetAllWithGlossariesAsync()
        {
            return await _context.Lessons.Include(g => g.Glossaries).ToListAsync();
        }

        public async Task<Lesson?> GetByIdAsync(Guid id)
        {
            return await _context.Lessons.FindAsync(id);
        }

        public async Task<Lesson> UpdateAsync(Guid id, UpdateLessonDto dto)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);
            if (lesson == null) return null;

            lesson.Name = dto.Name;
            lesson.Completed = dto.Completed;
            lesson.Url = dto.Url;
            lesson.Content = dto.Content;
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<Lesson> UpdateAsync(Lesson lesson)
        {
            _context.Entry(lesson).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return lesson;
        }
    }
}
