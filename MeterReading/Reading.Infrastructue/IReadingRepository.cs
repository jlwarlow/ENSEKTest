namespace Reading.Infrastructure
{
    public interface IReadingRepository
    {
        Task<int> Add(Entity.Reading reading);
        Task<Entity.Reading?> GetLastReading(int accountId);
    }
}
