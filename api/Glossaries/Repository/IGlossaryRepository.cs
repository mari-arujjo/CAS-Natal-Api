using api.Courses.Dtos;
using api.Courses;
using api.Glossaries.Dtos;

namespace api.Glossaries.Repository
{
    public interface IGlossaryRepository : IGenericRepository<Glossary, Guid>
    {
        Task<Glossary?> GetByCategoryAsync(GlossaryCategory category);
        Task<List<Glossary>> GetAllWithLessonsAsync();
        Task<Glossary?> GetByIdWithLessonsAsync(Guid id);
    }
}
