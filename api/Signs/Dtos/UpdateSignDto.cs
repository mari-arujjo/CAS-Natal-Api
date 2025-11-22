using api.Lessons;
using api.Signs;

namespace api.Signs.Dtos
{
    public class UpdateSignDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        //public byte[] Photo { get; set; }
        public GlossaryCategory category { get; set; }
    }
}
