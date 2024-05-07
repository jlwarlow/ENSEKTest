namespace Reading.Application
{
    public class AccountValidator : IAccountValidator
    {
        public string? Validate(string input, out Entity.Account? account)
        {
            account = null;

            if (string.IsNullOrEmpty(input))
            {
                return "Empty input";
            }

            var values = input.Split(',');

            if (values.Length != 3)
            {
                return "Expecting 3 fields in input (AccountId, FirstName, LastName";
            }

            if (!int.TryParse(values[0], out var accountId))
            {
                return $"Invalid AccountId in input {values[0]}";
            }

            if (string.IsNullOrEmpty(values[1]))
            {
                return $"Invalid FirstName in input {values[1]}";
            }

            if (string.IsNullOrEmpty(values[2]))
            {
                return $"Invalid LastName in input {values[2]}";
            }

            account = new Entity.Account
            {
                AccountId = accountId,
                FirstName = values[1],
                LastName = values[2]
            };

            return null;
        }
    }
}
