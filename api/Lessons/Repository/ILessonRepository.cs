using api.Lessons.Dtos;

namespace api.Lessons.Repository
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetAllAsync();
        Task<Lesson> GetByIdAsync(int id);
        Task<Lesson> CreateAsync(Lesson course);
        Task<Lesson> DeleteAsync(int id);
        Task<Lesson> UpdateAsync(int id, UpdateLessonDto dto);
    }
}
