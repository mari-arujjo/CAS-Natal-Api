using api.Lessons;

namespace api.Glossaries.Dtos
{
    public class UpdateGlossaryDto
    {
        public string Sign { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        //public byte[] Photo { get; set; }
        public GlossaryCategory Category { get; set; }
    }
}
