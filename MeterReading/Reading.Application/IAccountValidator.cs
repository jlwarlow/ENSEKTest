namespace Reading.Application
{
    public interface IAccountValidator
    {
        string? Validate(string input, out Entity.Account? account);
    }
}
