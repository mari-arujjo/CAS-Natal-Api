using api.Courses;
using api.Glossaries.Dtos;
using Microsoft.EntityFrameworkCore;

namespace api.Glossaries.Repository
{
    public class GlossaryRepository : IGlossaryRepository
    {
        private readonly ApplicationDbContext _context;
        public GlossaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Glossary> CreateAsync(Glossary gloss)
        {
            await _context.Glossaries.AddAsync(gloss);
            await _context.SaveChangesAsync();
            return gloss;
        }

        public async Task<Glossary?> DeleteAsync(Guid id)
        {
            var glossary = await _context.Glossaries.FirstOrDefaultAsync(g => g.Id == id);
            if (glossary == null) return null;
            _context.Glossaries.Remove(glossary);
            await _context.SaveChangesAsync();
            return glossary;
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            return _context.Glossaries.AnyAsync(g => g.Id == id);
        }

        public async Task<List<Glossary>> GetAllAsync()
        {
            return await _context.Glossaries.ToListAsync();
        }

        public async Task<Glossary?> GetByCategoryAsync(GlossaryCategory category)
        {
            return await _context.Glossaries.FirstOrDefaultAsync(g => g.Category == category);
        }

        public async Task<Glossary?> GetByIdAsync(Guid id)
        {
            return await _context.Glossaries.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Glossary> UpdateAsync(Glossary glossary)
        {
            _context.Entry(glossary).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return glossary;
        }
    }
}
