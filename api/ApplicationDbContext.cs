using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Identity;
using api.Courses;
using api.Lessons;
using api.Glossaries;
using api.Enrollments;
using api.AppUserIdentity;

namespace api
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) {}

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Glossary> Glossaries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Enrollment>(x => x.HasKey(p => new {p.UserId, p.CourseId}));
            builder.Entity<Enrollment>()
                .HasOne(u => u.User)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(p => p.UserId);
            builder.Entity<Enrollment>()
                .HasOne(u => u.Course)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(p => p.CourseId);

            builder.Entity<AppUser>().Property(u => u.Id).ValueGeneratedOnAdd();

            List<IdentityRole> roles = new List<IdentityRole> {
                new IdentityRole{
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Name = "Default",
                    NormalizedName = "DEFAULT"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
