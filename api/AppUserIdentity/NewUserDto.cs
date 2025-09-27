using System.ComponentModel.DataAnnotations;

namespace api.AppUserIdentity
{
    public class NewUserDto
    {
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string privateRole { get; set; }
        public string token { get; set; }
    }
}
