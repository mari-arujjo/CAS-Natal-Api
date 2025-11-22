namespace api.Lessons.Dtos
{
    public class UpdateLessonDto
    {
        public string? name { get; set; }
        public bool completed { get; set; } = false;
        public string? url { get; set; }
        public string? content { get; set; }
    }
}
