using api.Courses;
using api.Glossaries;
using api.LessonTopics.Dtos;
using api.Signs.Dtos;

namespace api.Lessons.Dtos
{
    public class LessonDto
    {
        public Guid id { get; set; }
        public string lessonCode { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public bool completed { get; set; } = false;
        public string url { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public Guid courseId { get; set; }
        public List<LessonTopicDto> topics { get; set; } = new();
        public List<SignDtoSimple> signs { get; set; } = new List<SignDtoSimple>();
    }
}
