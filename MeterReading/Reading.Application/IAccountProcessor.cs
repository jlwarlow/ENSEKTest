namespace Reading.Application
{
    public interface IAccountProcessor
    {
        Task Seed(string csv);
    }
}
