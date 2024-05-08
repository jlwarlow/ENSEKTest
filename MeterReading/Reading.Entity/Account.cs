namespace Reading.Entity
{
    public class Account
    {
        public Account()
        {
        }

        public Account(int accountId, string firstName, string lastName)
        {
            AccountId = accountId;
            FirstName = firstName;
            LastName = lastName;
        }

        public int AccountId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
