using api.Enrollments;
using api.Lessons;
using api.Lessons.Dtos;
using System.ComponentModel.DataAnnotations;

namespace api.Courses.Dtos
{
    public class CourseDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CourseCode { get; set; } = string.Empty; //CS-HCN-hash do guid
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Photo { get; set; } = null;
        public List<LessonDto> Lessons { get; set; } = new List<LessonDto>();
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
