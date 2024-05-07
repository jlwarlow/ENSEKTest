namespace Reading.Application
{
    public interface IReadingValidator
    {
        string? Validate(string input, out Entity.Reading? reading);
    }
}
