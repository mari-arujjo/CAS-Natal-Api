using api.LessonTopics.Dtos;
using System.ComponentModel;

namespace api.Lessons.Dtos
{
    public class UpdateLessonDto
    {
        public string? name { get; set; }

        [DefaultValue(false)]
        public bool completed { get; set; } = false;
        public string? url { get; set; }
        public string? content { get; set; }
        public List<LessonTopicDto>? topics { get; set; }
    }
}
