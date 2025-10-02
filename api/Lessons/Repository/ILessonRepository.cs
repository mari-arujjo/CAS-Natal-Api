using api.Lessons.Dtos;

namespace api.Lessons.Repository
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetAllAsync();
        Task<Lesson> GetByIdAsync(int id);
        Task<Lesson> CreateAsync(Lesson lesson);
        Task<Lesson> DeleteAsync(int id);
        Task<Lesson> UpdateAsync(int id, UpdateLessonDto dto);
    }
}
