using api.Lesson;
using System.ComponentModel.DataAnnotations;

namespace api.Glossary
{
    public class GlossaryModel
    {
        [Key]
        public int Id { get; set; }
        public string Sign { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public byte[]? Photo { get; set; } = Array.Empty<byte>();
        public string Category { get; set; } = string.Empty;
    }
}
