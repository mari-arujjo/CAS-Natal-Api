using api.Courses.Dtos;
using api.Courses;
using api.Signs;
using api.Signs.Dtos;

namespace api.Signs.Repository
{
    public interface ISignRepository : IGenericRepository<Sign, Guid>
    {
        Task<Sign?> GetByCategoryAsync(GlossaryCategory category);
        Task<List<Sign>> GetAllWithLessonsAsync();
        Task<Sign?> GetByIdWithLessonsAsync(Guid id);
        Task<Sign> UpdateAsync(Guid id, UpdateSignDto dto);
    }
}
