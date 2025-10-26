using api.Courses.Dtos;

namespace api.Courses.Repository
{
    public interface ICourseRepository : IGenericRepository<Course, Guid>
    {
        Task<Course?> GetBySymbol(string symbol);

    }
}
