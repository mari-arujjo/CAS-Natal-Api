using api.Courses.Dtos;

namespace api.Courses.Repository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task<Course> CreateAsync(Course course);
        Task<Course> DeleteAsync(int id);
        Task<Course> UpdateAsync(int id, UpdateCourseDto dto);

    }
}
