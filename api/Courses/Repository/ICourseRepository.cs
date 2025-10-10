using api.Courses.Dtos;

namespace api.Courses.Repository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(Guid id);
        Task<Course?> GetBySymbol(string symbol);
        Task<Course> CreateAsync(Course course);
        Task<Course> DeleteAsync(Guid id);
        Task<Course> UpdateAsync(Guid id, UpdateCourseDto dto);
        Task<bool> CourseExists(Guid id);

    }
}
