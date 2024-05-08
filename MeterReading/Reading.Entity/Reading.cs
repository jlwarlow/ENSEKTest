namespace Reading.Entity
{
    public class Reading
    {
        public Reading()
        {
        }

        public Reading(int accountId, DateTime meterReadingDateTime, int meterReadValue)
        {
            AccountId = accountId;
            MeterReadingDateTime = meterReadingDateTime;
            MeterReadValue = meterReadValue;
        }

        public int AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public int MeterReadValue { get; set; }
    }
}
