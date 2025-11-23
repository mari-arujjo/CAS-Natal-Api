using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace api.AppUserIdentity.Dtos
{
    public class UpdateUserDto
    {
        [MinLength(10, ErrorMessage = "O nome deve ter no mínimo 10 caracteres.")]
        [MaxLength(50, ErrorMessage = "Limite de caracteres: 50")]
        public string? name { get; set; }

        [MinLength(10, ErrorMessage = "O username deve ter no mínimo 10 caracteres.")]
        [MaxLength(20, ErrorMessage = "Limite de caracteres: 20")]
        public string? username { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string? email { get; set; }

        [DefaultValue(true)]
        public bool? active { get; set; }
    }
}
