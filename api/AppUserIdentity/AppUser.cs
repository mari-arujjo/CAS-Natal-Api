using api.Courses;
using api.Enrollments;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.AppUserIdentity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public byte[]? Avatar { get; set; } = null;
        public string PrivateRole { get; set; } = string.Empty;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}
