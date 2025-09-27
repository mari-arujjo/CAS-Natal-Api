
namespace api.Courses.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Course> CreateAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<Course> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
