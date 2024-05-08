namespace Reading.Application
{
    public interface IReadingProcessor
    {
        Task<int> ProcessCSV(string csv);
    }
}
