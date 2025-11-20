using System.ComponentModel.DataAnnotations;

namespace api.AppUserIdentity.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        [MinLength(10, ErrorMessage = "O nome deve ter no mínimo 10 caracteres.")]
        [MaxLength(50, ErrorMessage = "Limite de caracteres: 50")]
        public string name { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "O username deve ter no mínimo 10 caracteres.")]
        [MaxLength(20, ErrorMessage = "Limite de caracteres: 20")]
        public string username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

    }
}
