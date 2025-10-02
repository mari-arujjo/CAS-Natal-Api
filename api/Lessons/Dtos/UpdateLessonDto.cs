namespace api.Lessons.Dtos
{
    public class UpdateLessonDto
    {
        public string Name { get; set; }
        public bool Completed { get; set; } = false;
        public string Url { get; set; }
        public string Content { get; set; }
    }
}
