using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Identity;
using api.Courses;
using api.Lessons;
using api.Glossaries;
using api.Enrollments;
using api.AppUserIdentity;
using api.Logs;

namespace api
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) {}

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Glossary> Glossaries { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Enrollment>()
                .HasOne(e => e.User)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.UserId);
            builder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);
            builder.Entity<Enrollment>()
                .HasIndex(e => new { e.UserId, e.CourseId })
                .IsUnique();

            builder.Entity<Lesson>()
                .HasMany(l => l.Glossaries)
                .WithMany(g => g.Lessons)
                .UsingEntity(j => j.ToTable("LessonGlossaries"));

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
