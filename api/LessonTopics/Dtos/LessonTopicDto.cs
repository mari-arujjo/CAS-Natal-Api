namespace api.LessonTopics.Dtos
{
    public class LessonTopicDto
    {
        public int order { get; set; }
        public string title { get; set; } = string.Empty;
        public string textContent { get; set; } = string.Empty;
    }
}
