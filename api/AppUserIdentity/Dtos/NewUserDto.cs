using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace api.AppUserIdentity.Dtos
{
    public class NewUserDto
    {
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string privateRole { get; set; }
        public DateTime createdAt { get; set; }

        [DefaultValue(true)]
        public bool active { get; set; }
        public string token { get; set; }
    }
}
