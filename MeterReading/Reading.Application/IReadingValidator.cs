namespace Reading.Application
{
    public interface IReadingValidator
    {
        string? Validate(string input, out Entity.Reading? reading);
        bool NewReadingIsValid(Entity.Reading newReading, Entity.Reading lastReading);
    }
}
