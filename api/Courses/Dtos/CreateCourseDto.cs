using System.ComponentModel.DataAnnotations;

namespace api.Courses.Dtos
{
    public class CreateCourseDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "O nome deve ter no mínimo 10 caracteres.")]
        [MaxLength(30, ErrorMessage = "Limite de caracteres: 30")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(2, ErrorMessage = "A sigla deve ter no mínimo 2 caracteres.")]
        [MaxLength(4, ErrorMessage = "Limite de caracteres: 4")]
        public string Abbreviation { get; set; } = string.Empty;

        [Required]
        [MinLength(10, ErrorMessage = "A descrição deve ter no mínimo 10 caracteres.")]
        [MaxLength(300, ErrorMessage = "Limite de caracteres: 300")]
        public string Description { get; set; } = string.Empty;
    }
}
