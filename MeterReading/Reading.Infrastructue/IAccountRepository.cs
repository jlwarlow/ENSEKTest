namespace Reading.Infrastructure
{
    public interface IAccountRepository
    {
        Task<int> Add(Entity.Account account);
        Task<Entity.Account?> Get(int accountId);
    }
}
