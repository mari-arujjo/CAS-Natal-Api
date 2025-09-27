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


        // método do EF Core que permite personalizar o modelo do banco de dados.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // configura a prorpiedade PrivateId como autoincrementada no bd
            builder.Entity<AppUser>().Property(u => u.PrivateId).ValueGeneratedOnAdd();

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
