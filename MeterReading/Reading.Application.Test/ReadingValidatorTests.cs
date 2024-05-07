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
            var line = "Fail";

            // Act
            var result = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(result!.Contains("Expecting 3 fields in input"));
        }

        [TestMethod]
        public void IncorrectNumber_Fields_Fail()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24";

            // Act
            var result = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(result!.Contains("Expecting 3 fields in input"));
        }
        
        [TestMethod]
        public void Invalid_AccountId_Fail()
        {
            // Arrange
            var line = "A,22/04/2019 09:24,12";

            // Act
            var result = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(result!.Contains("Invalid AccountId in input"));
        }

        [TestMethod]
        public void Invalid_MeterReadingDateTime_Fail()
        {
            // Arrange
            var line = "1,Monday,12";

            // Act
            var result = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(result!.Contains("Invalid MeterReadingDateTime in input"));
        }

        [TestMethod]
        public async Task Invalid_MeterReadingValue_Fail()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24,12T";

            // Act
            var result = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(result!.Contains("Invalid MeterReadingValue in input"));
        }

        [TestMethod]
        public async Task Negative_MeterReading_Fail()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24,-12";

            // Act
            var result = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(result!.Contains("Invalid MeterReadingValue in input"));
        }

        [TestMethod]
        public async Task Valid_MeterReading_Succeeds()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24,12";

            // Act
            Entity.Reading? reading;
            var result = _sut.Validate(line, out reading);

            // Assert
            Assert.IsNull(result);
            Assert.IsNotNull(reading);
        }
    }
}