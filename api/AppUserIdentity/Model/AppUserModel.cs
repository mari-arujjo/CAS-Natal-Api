using api.Course;
using api.Glossary;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace api.AppUserIdentity.Model
{
    public class AppUserModel : IdentityUser
    {
        public int Id_AppUser { get; set; }
        public List<CourseModel> Courses { get; set; } = new();
        public byte[]? Avatar { get; set; } = Array.Empty<byte>();
    }
}
