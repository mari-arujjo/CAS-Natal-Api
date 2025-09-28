using System.ComponentModel.DataAnnotations;

namespace api.AppUserIdentity.Dtos
{
    public class LoginDto
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}
