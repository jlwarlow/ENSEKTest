using Reading.Entity;

namespace Reading.Application
{
    public class AccountValidator : IAccountValidator
    {
        public string? Validate(string input, out Entity.Account? account)
        {
            throw new NotImplementedException();
        }
    }
}
