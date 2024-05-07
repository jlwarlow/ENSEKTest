using Reading.Entity;

namespace Reading.Application
{
    public class AccountValidator : IAccountValidator
    {
        public Task<(bool valid, Account account)> Validate(string input)
        {
            throw new NotImplementedException();
        }
    }
}
