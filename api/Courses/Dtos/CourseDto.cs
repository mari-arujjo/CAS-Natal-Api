using api.Enrollments.Dtos;
using api.Lessons.Dtos;

namespace api.Courses.Dtos
{
    public class CourseDto
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string courseCode { get; set; } = string.Empty; //CS-HCN-hash do guid
        public string name { get; set; } = string.Empty;
        public string symbol { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public byte[]? photo { get; set; } = null;
        public List<LessonDto> lessons { get; set; } = new List<LessonDto>();
        public List<EnrollmentDto> enrollments { get; set; } = new List<EnrollmentDto>();

    }
}
