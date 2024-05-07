namespace Reading.Application
{
    public interface IValidator
    {
        bool Validate(string input, out Entity.Reading? validReading);
    }
}
