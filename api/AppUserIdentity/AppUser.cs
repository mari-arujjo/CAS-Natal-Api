using api.Courses;
using api.Enrollments;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.AppUserIdentity
{
    public class AppUser : IdentityUser
    {
        public int PrivateId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public byte[]? Avatar { get; set; } = Array.Empty<byte>();
        public string PrivateRole { get; set; } = string.Empty;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
