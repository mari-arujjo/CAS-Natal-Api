using System.ComponentModel;

namespace api.AppUserIdentity.Dtos
{
    public class AppUserDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string privateRole { get; set; }
        public byte[]? avatar { get; set; } = null;
        public DateTime createdAt { get; set; }

        [DefaultValue(true)]
        public bool active { get; set; }
    }
}
