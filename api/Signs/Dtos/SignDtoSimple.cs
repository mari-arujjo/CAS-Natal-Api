namespace api.Signs.Dtos
{
    public class SignDtoSimple
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string signCode { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        //public string Description { get; set; } = string.Empty;
        //public string? Url { get; set; } = null;
        //public byte[]? Photo { get; set; } = null;
        //public GlossaryCategory Category { get; set; }
    }
}
