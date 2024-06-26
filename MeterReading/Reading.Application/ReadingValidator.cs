﻿namespace Reading.Application
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
                return "Expecting 3 fields in input (AccountId, MeterReadingDate, MeterReadValue";
            }

            if (!int.TryParse(values[0], out var accountId))
            {
                return $"Invalid AccountId in input {values[0]}";
            }

            if (!DateTime.TryParse(values[1], out var meterReadingDateTime))
            {
                return $"Invalid MeterReadingDateTime in input {values[1]}";
            }

            if (!int.TryParse(values[2], out var meterReadValue) || meterReadValue < 0)
            {
                return $"Invalid MeterReadValue in input {values[2]}";
            }

            reading = new Entity.Reading(accountId, meterReadingDateTime, meterReadValue);

            return null;
        }

        public bool NewReadingIsValid(Entity.Reading newReading, Entity.Reading lastReading)
        {
            if (DateTime.Compare(newReading.MeterReadingDateTime, lastReading.MeterReadingDateTime) < 0)
            {
                return false;
            }

            return newReading.MeterReadValue >= lastReading.MeterReadValue;
        }
    }
}
