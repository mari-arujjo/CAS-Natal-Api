using api.LessonTopics.Dtos;

namespace api.Lessons.Dtos
{
    public class CreateLessonDto
    {
        public string name { get; set; } = string.Empty;
        //public bool completed { get; set; } = false;
        public int order { get; set; }
        public string url { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty; 
        public List<LessonTopicDto> topics { get; set; } = new();

    }
}
