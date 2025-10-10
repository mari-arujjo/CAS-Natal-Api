using api.Lessons.Dtos;

namespace api.Lessons.Repository
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetAllAsync();
        Task<Lesson?> GetByIdAsync(Guid id);
        Task<Lesson> CreateAsync(Lesson lesson);
        Task<Lesson> DeleteAsync(Guid id);
        Task<Lesson> UpdateAsync(Guid id, UpdateLessonDto dto);
    }
}
