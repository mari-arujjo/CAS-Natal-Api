namespace api.QuizOptions.Dtos
{
    public class QuizOptionsDto
    {
        public Guid id { get; set; }
        public string optionText { get; set; } = string.Empty;
        public bool isCorrect { get; set; }
    }
}
