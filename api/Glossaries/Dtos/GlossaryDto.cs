using api.Lessons;
using api.Lessons.Dtos;

namespace api.Glossaries.Dtos
{
    public class GlossaryDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string GlossaryCode { get; set; } = string.Empty;
        public string Sign { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Url { get; set; } = null;
        public byte[]? Photo { get; set; } = null;
        public GlossaryCategory Category { get; set; }
        public ICollection<LessonDtoSimple> Lessons { get; set; } = new List<LessonDtoSimple>();
    }
}
