using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Identity;
using api.Courses;
using api.Lessons;
using api.Enrollments;
using api.AppUserIdentity;
using api.Signs;
using api.QuizQuestions;
using api.QuizOptions;

namespace api
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) {}

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<QuizQuestionsModel> QuizQuestions { get; set; }
        public DbSet<QuizOptionsModel> QuizOptions { get; set; }
        public DbSet<Sign> Signs { get; set; }

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
                .HasMany(l => l.Signs)
                .WithMany(g => g.Lessons)
                .UsingEntity(j => j.ToTable("LessonsSigns")); 

            builder.Entity<Lesson>()
                .HasMany(l => l.QuizQuestions)
                .WithOne(q => q.Lesson)
                .HasForeignKey(q => q.LessonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<QuizQuestionsModel>()
                .HasMany(q => q.QuizOptions)
                .WithOne(o => o.QuizQuestion)
                .HasForeignKey(o => o.QuestionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

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


            builder.Entity<AppUser>().HasQueryFilter(u => u.DeletedAt == null);
            builder.Entity<Enrollment>().HasQueryFilter(e => e.DeletedAt == null);
            builder.Entity<Course>().HasQueryFilter(c => c.DeletedAt == null);
            builder.Entity<Lesson>().HasQueryFilter(l => l.DeletedAt == null);
            builder.Entity<Sign>().HasQueryFilter(s => s.DeletedAt == null);
        }
    }
}
