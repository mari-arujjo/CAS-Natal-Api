using api.Enrollments;
using api.Lessons;
using api.Lessons.Dtos;
using System.ComponentModel.DataAnnotations;

namespace api.Courses.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Photo { get; set; } = Array.Empty<byte>();
        public List<LessonDto> Lessons { get; set; } = new List<LessonDto>();
    }
}
