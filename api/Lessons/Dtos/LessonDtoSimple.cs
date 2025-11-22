namespace api.Lessons.Dtos
{
    public class LessonDtoSimple
    {
        public Guid id { get; set; }
        public string lessonCode { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        //public bool completed { get; set; } = false;
        //public string url { get; set; } = string.Empty;
        //public string content { get; set; } = string.Empty;
        //public Guid courseId { get; set; }
    }
}
