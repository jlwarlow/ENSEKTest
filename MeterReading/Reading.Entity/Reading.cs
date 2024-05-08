namespace Reading.Entity
{
    public class Reading
    {
        public Reading(int accountId, DateTime meterReadingDateTime, int meterReadingValue)
        {
            AccountId = accountId;
            MeterReadingDateTime = meterReadingDateTime;
            MeterReadingValue = meterReadingValue;
        }

        public int AccountId { get; set; }
        public DateTime MeterReadingDateTime { get; set; }
        public int MeterReadingValue { get; set; }
    }
}
