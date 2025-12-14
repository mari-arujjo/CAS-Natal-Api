using Microsoft.EntityFrameworkCore;

namespace api.QuizQuestions.Repository
{
    public class QuizQuestionsRepository : IQuizQuestionsRepository
    {
        public readonly ApplicationDbContext _context;

        public QuizQuestionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuizQuestionsModel>> GetAllWithQuizOptionsAsync()
        {
            return await _context.QuizQuestions.Include(q => q.QuizOptions).ToListAsync();
        }

        public async Task<QuizQuestionsModel?> GetByIdWithQuizOptionsAsync(Guid id)
        {
            return await _context.QuizQuestions.Include(q => q.QuizOptions).FirstOrDefaultAsync(q => q.Id == id);
        }

        public Task<QuizQuestionsModel> CreateAsync(QuizQuestionsModel entity) { throw new NotImplementedException(); }
        public Task<QuizQuestionsModel?> DeleteAsync(Guid id) { throw new NotImplementedException(); }
        public Task<bool> ExistsAsync(Guid id) { throw new NotImplementedException(); }
        public Task<List<QuizQuestionsModel>> GetAllAsync() { throw new NotImplementedException(); }
        public Task<QuizQuestionsModel?> GetByIdAsync(Guid id) { throw new NotImplementedException(); }
    }
}
