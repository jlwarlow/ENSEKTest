namespace Reading.Application
{
    public class ReadingValidator : IReadingValidator
    {
        public string? Validate(string input, out Entity.Reading? reading)
        {
            reading = null;

            if (string.IsNullOrEmpty(input))
            {
                return "Empty input";
            }

            var values = input.Split(',');

            if (values.Length != 3)
            {
                return "Expecting 3 fields in input (AccountId, MeterReadingDate, MeterReadingValue";
            }

            if (!int.TryParse(values[0], out var accountId))
            {
                return $"Invalid AccountId in input {values[0]}";
            }

            if (!DateTime.TryParse(values[1], out var meterReadingDateTime))
            {
                return $"Invalid MeterReadingDateTime in input {values[1]}";
            }

            if (!int.TryParse(values[2], out var meterReadingValue) || meterReadingValue < 0)
            {
                return $"Invalid MeterReadingValue in input {values[2]}";
            }

            reading = new Entity.Reading
            {
                AccountId = accountId,
                MeterReadingDateTime = meterReadingDateTime,
                MeterReadingValue = meterReadingValue
            };

            return null;
        }
    }
}
