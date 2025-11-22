using api.Lessons;
using api.Lessons.Dtos;
using api.Signs;

namespace api.Signs.Dtos
{
    public class SignDto
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string signCode { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string? url { get; set; } = null;
        public byte[]? photo { get; set; } = null;
        public GlossaryCategory category { get; set; }
        public ICollection<LessonDtoSimple> lessons { get; set; } = new List<LessonDtoSimple>();
    }
}
