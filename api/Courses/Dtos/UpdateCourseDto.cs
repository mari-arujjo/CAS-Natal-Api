using System.ComponentModel.DataAnnotations;

namespace api.Courses.Dtos
{
    public class UpdateCourseDto
    {
        [MinLength(10, ErrorMessage = "O nome deve ter no mínimo 10 caracteres.")]
        [MaxLength(50, ErrorMessage = "Limite de caracteres: 50")]
        public string? name { get; set; }

        [MinLength(2, ErrorMessage = "A sigla deve ter no mínimo 2 caracteres.")]
        [MaxLength(4, ErrorMessage = "Limite de caracteres: 4")]
        public string? symbol { get; set; }

        [MinLength(10, ErrorMessage = "A descrição deve ter no mínimo 10 caracteres.")]
        [MaxLength(300, ErrorMessage = "Limite de caracteres: 300")]
        public string? description { get; set; }
        public byte[]? photo { get; set; } = null;
    }
}
