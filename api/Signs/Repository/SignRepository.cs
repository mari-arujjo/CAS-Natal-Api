using api.Courses;
using api.Lessons.Dtos;
using api.Signs;
using api.Signs.Dtos;
using Microsoft.EntityFrameworkCore;

namespace api.Signs.Repository
{
    public class SignRepository : ISignRepository
    {
        private readonly ApplicationDbContext _context;
        public SignRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Sign> CreateAsync(Sign sign)
        {
            await _context.Signs.AddAsync(sign);
            await _context.SaveChangesAsync();
            return sign;
        }

        public async Task<Sign?> DeleteAsync(Guid id)
        {
            var sign = await _context.Signs.FirstOrDefaultAsync(g => g.Id == id);
            if (sign == null) return null;
            sign.UpdatedAt = DateTime.UtcNow;
            sign.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return sign;
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            return _context.Signs.AnyAsync(g => g.Id == id);
        }

        public async Task<List<Sign>> GetAllAsync()
        {
            return await _context.Signs.ToListAsync();
        }

        public async Task<List<Sign>> GetAllWithLessonsAsync()
        {
            return await _context.Signs.Include(l => l.Lessons).ToListAsync();
        }

        public async Task<Sign?> GetByCategoryAsync(GlossaryCategory category)
        {
            return await _context.Signs.FirstOrDefaultAsync(s => s.Category == category);
        }

        public async Task<Sign?> GetByIdAsync(Guid id)
        {
            return await _context.Signs.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Sign?> GetByIdWithLessonsAsync(Guid id)
        {
            return await _context.Signs.Include(s => s.Lessons).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Sign> UpdateAsync(Guid id, UpdateSignDto dto)
        {
            var sign = await _context.Signs.FirstOrDefaultAsync(l => l.Id == id);
            if (sign == null) return null;

            sign.Name = dto.name;
            sign.Description = dto.description;
            sign.Url = dto.url;
            sign.Photo = dto.photo;
            sign.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return sign;
        }
    }
}
