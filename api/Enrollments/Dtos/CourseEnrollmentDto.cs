using api.Lessons;

namespace api.Enrollments.Dtos
{
    public class CourseEnrollmentDto
    {
        public Guid enrollmentId { get; set; }
        public Guid courseId { get; set; }
        public string courseCode { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public byte[]? photo { get; set; }
        //public ICollection<Lesson> lessons { get; set; }
    }
}
