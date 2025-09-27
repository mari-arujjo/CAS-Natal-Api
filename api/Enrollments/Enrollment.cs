using api.AppUserIdentity;
using api.Courses;
using api.Lessons;
using System.ComponentModel.DataAnnotations;

namespace api.Enrollments
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        ///
        public int CourseId { get; set; }
        public Course Course { get; set; }
        ///
        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; }
        ///
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Active"; //active, inactive
        public int ProgressPercentage { get; set; } = 0;

        
    }
}
