namespace Reading.Application
{
    public interface IAccountValidator
    {
        Task<(bool valid, Entity.Account account)> Validate(string input);
    }
}
