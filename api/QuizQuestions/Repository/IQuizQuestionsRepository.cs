namespace api.QuizQuestions.Repository
{
    public interface IQuizQuestionsRepository : IGenericRepository<QuizQuestionsModel, Guid>
    {
        Task<List<QuizQuestionsModel>> GetAllWithQuizOptionsAsync();
        Task<QuizQuestionsModel?> GetByIdWithQuizOptionsAsync(Guid id);
        Task<QuizQuestionsModel?> GetByLessonIdWithQuizOptionsAsync(Guid lessonId);
    }
}
