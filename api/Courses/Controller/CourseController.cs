using api.Courses.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Courses.Controller
{

    [ApiController]
    [Route("CASNatal/course")]
    public class CourseController : ControllerBase
    {
        public readonly ICourseRepository _courseRep;
        public CourseController(ICourseRepository courseRep)
        {
            _courseRep = courseRep;
        }
    }
}
