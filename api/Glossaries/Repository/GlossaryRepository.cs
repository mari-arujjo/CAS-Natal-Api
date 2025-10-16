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


        public Task<Glossary> CreateAsync(Glossary gloss)
        {
            throw new NotImplementedException();
        }

        public Task<Glossary> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Glossary>> GetAllAsync()
        {
            return _context.Glossaries.ToListAsync();
        }

        public Task<Glossary?> GetByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task<Glossary?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Glossary> UpdateAsync(Guid id, UpdateGlossaryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
