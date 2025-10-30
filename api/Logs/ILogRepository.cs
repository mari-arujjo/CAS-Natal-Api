namespace api.Logs
{
    public interface ILogRepository
    {
        Task<List<Log>> GetAllAsync();
        Task<Log?> GetByIdAsync(Guid id);
        Task<Log> CreateAsync(Log entity);
    }
}
