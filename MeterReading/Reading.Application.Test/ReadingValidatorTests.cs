namespace Reading.Application.Test
{
    [TestClass]
    public class ReadingValidatorTests
    {
        private readonly ReadingValidator _sut = new();

        [TestMethod]
        public void InvalidLine_Returns_Fail()
        {
            // Arrange
            const string line = "Fail";

            // Act
            var error = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(error!.Contains("Expecting 3 fields in input"));
        }

        [TestMethod]
        public void IncorrectNumber_Fields_Fail()
        {
            // Arrange
            const string line = "2344,22/04/2019 09:24";

            // Act
            var error = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(error!.Contains("Expecting 3 fields in input"));
        }
        
        [TestMethod]
        public void Invalid_AccountId_Fail()
        {
            // Arrange
            const string line = "A,22/04/2019 09:24,12";

            // Act
            var error = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(error!.Contains("Invalid AccountId in input"));
        }

        [TestMethod]
        public void Invalid_MeterReadingDateTime_Fail()
        {
            // Arrange
            const string line = "1,Monday,12";

            // Act
            var error = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(error!.Contains("Invalid MeterReadingDateTime in input"));
        }

        [TestMethod]
        public void Invalid_MeterReadingValue_Fail()
        {
            // Arrange
            const string line = "2344,22/04/2019 09:24,12T";

            // Act
            var error = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(error!.Contains("Invalid MeterReadingValue in input"));
        }

        [TestMethod]
        public void Negative_MeterReading_Fail()
        {
            // Arrange
            const string line = "2344,22/04/2019 09:24,-12";

            // Act
            var result = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(result!.Contains("Invalid MeterReadingValue in input"));
        }

        [TestMethod]
        public void Valid_MeterReading_Succeeds()
        {
            // Arrange
            const string line = "2344,22/04/2019 09:24,12";

            // Act
            var error = _sut.Validate(line, out var reading);

            // Assert
            Assert.IsNull(error);
            Assert.IsNotNull(reading);
        }

        [TestMethod]
        public void NewReading_Newer_Than_Old_Reading_Succeed()
        {
            // Arrange
            var oldReading = new Entity.Reading(1, new DateTime(2024, 1, 1), 12);
            var newReading = new Entity.Reading(1, new DateTime(2024, 2, 3), 24);

            // Act
            var result = _sut.NewReadingIsValid(newReading, oldReading);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NewReading_Greater_Than_Old_Reading_Succeed()
        {
            // Arrange
            var oldReading = new Entity.Reading(1, new DateTime(2024, 1, 1), 12);
            var newReading = new Entity.Reading(1, new DateTime(2024, 1, 1), 24);

            // Act
            var result = _sut.NewReadingIsValid(newReading, oldReading);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NewReading_Older_Than_Old_Reading_Rejected()
        {
            // Arrange
            var oldReading = new Entity.Reading(1, new DateTime(2024, 2, 1), 12);
            var newReading = new Entity.Reading(1, new DateTime(2024, 1, 1), 24);

            // Act
            var result = _sut.NewReadingIsValid(newReading, oldReading);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NewReading_Smaller_Than_Old_Reading_Rejected()
        {
            // Arrange
            var oldReading = new Entity.Reading(1, new DateTime(2024, 1, 1), 12);
            var newReading = new Entity.Reading(1, new DateTime(2024, 2, 1), 10);

            // Act
            var result = _sut.NewReadingIsValid(newReading, oldReading);

            // Assert
            Assert.IsFalse(result);
        }
    }
}