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
            return await _context.Lessons.OrderBy(l => l.Order).ToListAsync();
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
            lesson.Order = dto.order;
            lesson.Completed = dto.completed;
            lesson.Url = dto.url ?? lesson.Url;
            lesson.Content = dto.content ?? lesson.Content;
            lesson.UpdatedAt = DateTime.UtcNow;

            if (dto.topics != null)
            {
                var idsNoDto = dto.topics
                    .Where(t => t.id != Guid.Empty)
                    .Select(t => t.id)
                    .ToList();

                var topicsParaRemover = lesson.LessonTopics
                    .Where(t => !idsNoDto.Contains(t.Id))
                    .ToList();

                foreach (var t in topicsParaRemover)
                {
                    _context.Entry(t).State = EntityState.Deleted;
                }

                foreach (var topicDto in dto.topics)
                {
                    var existingTopic = lesson.LessonTopics.FirstOrDefault(t => t.Id == topicDto.id);

                    if (topicDto.id != Guid.Empty && existingTopic != null)
                    {
                        _context.Entry(existingTopic).CurrentValues.SetValues(new
                        {
                            topicDto.title,
                            topicDto.textContent,
                            topicDto.order
                        });
                        _context.Entry(existingTopic).State = EntityState.Modified;
                    }
                    else
                    {
                        var newTopic = new LessonTopic
                        {
                            Id = Guid.NewGuid(),
                            Title = topicDto.title,
                            TextContent = topicDto.textContent,
                            Order = topicDto.order,
                            LessonId = lesson.Id
                        };
                        _context.LessonTopics.Add(newTopic);
                    }
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    entry.State = EntityState.Detached;
                }
                throw new Exception("Erro de concorrência detectado.");
            }

            return lesson;
        }
    }
}
