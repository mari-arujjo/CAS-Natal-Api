namespace api.Generate_Codes
{
    public class GenerateCodes
    {
        public static string GenerateEnrollmentCode(string courseSymbol, Guid enrollmentId)
        {
            string shortGuid = enrollmentId.ToString("N").Substring(0, 5).ToUpper();
            string year = DateTime.UtcNow.Year.ToString();
            return $"{courseSymbol}-{year}-{shortGuid}";
        }
        public static string GenerateCourseCode(string courseSymbol, Guid courseId)
        {
            string shortGuid = courseId.ToString("N").Substring(0, 5).ToUpper();
            return $"CS-{courseSymbol}-{shortGuid}";
        }
        public static string GenerateLessonCode(string courseSymbol, Guid lessonId)
        {
            string shortGuid = lessonId.ToString("N").Substring(0, 5).ToUpper();
            return $"LS-{courseSymbol}-{shortGuid}";
        }
        public static string GenerateGlossaryCode(Guid glossaryId)
        {
            string shortGuid = glossaryId.ToString("N").Substring(0, 5).ToUpper();
            return $"GL-{shortGuid}";
        }
    }
}
