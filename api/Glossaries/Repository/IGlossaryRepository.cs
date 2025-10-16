using api.Courses.Dtos;
using api.Courses;
using api.Glossaries.Dtos;

namespace api.Glossaries.Repository
{
    public interface IGlossaryRepository
    {
        Task<List<Glossary>> GetAllAsync();
        Task<Glossary?> GetByIdAsync(Guid id);
        Task<Glossary?> GetByCategory(string category);
        Task<Glossary> CreateAsync(Glossary gloss);
        Task<Glossary> DeleteAsync(Guid id);
        Task<Glossary> UpdateAsync(Guid id, UpdateGlossaryDto dto);
    }
}
