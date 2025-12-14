using api.QuizOptions;
using api.QuizOptions.Dtos;
using api.QuizQuestions.Dtos;

namespace api.QuizQuestions
{
    public static class QuizQuestionsMapper
    {
        public static QuizOptionsDto ConvertToQuizOptionsDto(this QuizOptionsModel option)
        {
            return new QuizOptionsDto
            {
                id = option.Id,
                optionText = option.OptionText,
                isCorrect = option.IsCorrect
            };
        }

        public static QuizQuestionsDto ConvertToQuizQuestionsDto(this QuizQuestionsModel question)
        {
            return new QuizQuestionsDto
            {
                id = question.Id,
                lessonId = question.LessonId,
                questionText = question.QuestionText,
                feedback = question.Feedback,
                quizOptions = question.QuizOptions.Select(o => o.ConvertToQuizOptionsDto()).ToList()
            };
        }
    }
}
