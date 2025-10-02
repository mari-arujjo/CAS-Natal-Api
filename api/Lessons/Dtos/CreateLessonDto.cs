namespace api.Lessons.Dtos
{
    public class CreateLessonDto
    {
        public string Name { get; set; } = string.Empty;
        public bool Completed { get; set; } = false;
        public string Url { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

    }
}
