namespace Reading.Application
{
    public class ReadingValidator : IReadingValidator
    {
        public Task<(bool valid, Entity.Reading reading)> Validate(string input)
        {
            throw new NotImplementedException();
        }
    }
}
