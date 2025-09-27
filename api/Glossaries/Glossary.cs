using api.Lessons;
using System.ComponentModel.DataAnnotations;

namespace api.Glossaries
{
    public class Glossary
    {
        [Key]
        public int Id { get; set; }
        public string Sign { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public byte[]? Photo { get; set; } = Array.Empty<byte>();
        public string Category { get; set; } = string.Empty;

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
