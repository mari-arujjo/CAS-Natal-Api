using api.Lessons.Dtos;

namespace api.Lessons.Repository
{
    public interface ILessonRepository : IGenericRepository<Lesson, Guid>
    {
        Task<List<Lesson>> GetAllWithGlossariesAsync();
        Task<List<Lesson>> GetByIdsAsync(IEnumerable<Guid> ids);
        Task<Lesson> UpdateAsync(Guid id, UpdateLessonDto dto);


    }
}
