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

        public async Task<Lesson> CreateAsync(Lesson course)
        {
            throw new NotImplementedException();
        }

        public async Task<Lesson> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Lesson>> GetAllAsync()
        {
            var lesson = await _context.Lessons.ToListAsync();
            return lesson;
        }

        public async Task<Lesson> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Lesson> UpdateAsync(int id, UpdateLessonDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
