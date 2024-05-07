namespace Reading.Infrastructure
{
    public interface IRepository
    {
        void Add(Entity.Reading reading);
        void Add(Entity.Account account);
    }
}
