using System.ComponentModel.DataAnnotations;

namespace api.AppUserIdentity
{
    public class RegisterUserDto
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

    }
}
