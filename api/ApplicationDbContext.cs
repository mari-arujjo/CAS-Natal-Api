using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Identity;
using api.AppUserIdentity.Model;
using api.Course;
using api.Lesson;
using api.Glossary;

namespace api
{
    public class ApplicationDbContext : IdentityDbContext<AppUserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) {}

        public DbSet<CourseModel> Course { get; set; }
        public DbSet<LessonModel> Lesson { get; set; }
        public DbSet<GlossaryModel> Glossary { get; set; }
    }
}
