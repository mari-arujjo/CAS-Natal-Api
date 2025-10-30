
using api.Lessons;
using Microsoft.EntityFrameworkCore;

namespace api.Logs
{
    public class LogRepository : ILogRepository
    {
        private readonly ApplicationDbContext _context;
        public LogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Log> CreateAsync(Log log)
        {
            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<List<Log>> GetAllAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<Log?> GetByIdAsync(Guid id)
        {
            return await _context.Logs.FindAsync(id);
        }
    }
}
