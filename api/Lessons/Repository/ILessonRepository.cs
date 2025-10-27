using api.Lessons.Dtos;

namespace api.Lessons.Repository
{
    public interface ILessonRepository : IGenericRepository<Lesson, Guid>
    {
        Task<List<Lesson>> GetAllWithGlossariesAsync();
    }
}
