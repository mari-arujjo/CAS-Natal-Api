using api.Lessons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Signs
{
    [Table("Signs")]
    public class Sign
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SignCode { get; set; } = string.Empty; //GL-hash do guid
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Url { get; set; } = null;
        public byte[]? Photo { get; set; } = null;
        public GlossaryCategory Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }

        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }

    public enum GlossaryCategory
    {
        [Display(Name = "Emoções e Comunicação")]
        EmoçõesEComunicacao,

        [Display(Name = "Sinais Regionais")]
        SinaisRegionais,

        [Display(Name = "Pessoas e Profissões")]
        PessoasEProfissoes,

        [Display(Name = "Verbos e Adjetivos")]
        VerbosEAdjetivos,

        [Display(Name ="Mídia e Tecnologia")]
        MidiaETecnologia,

        [Display(Name = "Clima e Natureza")]
        ClimaENatureza,
    }
}
