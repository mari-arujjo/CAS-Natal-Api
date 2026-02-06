using api.Courses;
using api.Lessons.Dtos;
using api.LessonTopics;
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
            lesson.DeletedAt = DateTime.UtcNow;
            lesson.DeletedAt = DateTime.UtcNow;
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
            return await _context.Lessons.Include(g => g.Signs).ToListAsync();
        }

        public async Task<Lesson?> GetByIdAsync(Guid id)
        {
            return await _context.Lessons.Include(l => l.LessonTopics).Include(l => l.Signs).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Lesson>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            return await _context.Lessons.Where(l => ids.Contains(l.Id)).ToListAsync();
        }

        public async Task<Lesson> UpdateAsync(Guid id, UpdateLessonDto dto)
        {
            var lesson = await _context.Lessons
                .Include(l => l.LessonTopics)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (lesson == null) return null;

            lesson.Name = dto.name ?? lesson.Name;
            lesson.Completed = dto.completed;
            lesson.Url = dto.url ?? lesson.Url;
            lesson.UpdatedAt = DateTime.UtcNow;

            if (dto.topics != null)
            {
                _context.LessonTopics.RemoveRange(lesson.LessonTopics);
                lesson.LessonTopics = dto.topics.Select(t => new LessonTopic
                {
                    Order = t.order,
                    Title = t.title,
                    TextContent = t.textContent,
                    LessonId = lesson.Id 
                }).ToList();
            }

            await _context.SaveChangesAsync();
            return lesson;
        }
    }
}
