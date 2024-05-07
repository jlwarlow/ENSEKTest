namespace Reading.Application
{
    public interface IProcessor
    {
        Task<int> ProcessCSV(string csv);
    }
}
