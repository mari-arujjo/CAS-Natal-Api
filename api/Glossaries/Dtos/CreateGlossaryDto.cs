namespace api.Glossaries.Dtos
{
    public class CreateGlossaryDto
    {
        public string Sign { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        //public byte[] Photo { get; set; }
        public GlossaryCategory Category { get; set; }
        public List<Guid> LessonsIds { get; set; } = new List<Guid>();
    }
}
