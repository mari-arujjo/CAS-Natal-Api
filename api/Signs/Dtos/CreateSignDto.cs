using api.Signs;

namespace api.Signs.Dtos
{
    public class CreateSignDto
    {
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;
        //public byte[] Photo { get; set; }
        public GlossaryCategory category { get; set; }
        public List<Guid>? lessonIds { get; set; }
    }
}
