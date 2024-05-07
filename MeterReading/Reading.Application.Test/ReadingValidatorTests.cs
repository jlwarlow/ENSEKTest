namespace Reading.Application.Test
{
    [TestClass]
    public class ReadingValidatorTests
    {
        private readonly ReadingValidator _sut = new();

        [TestMethod]
        public async Task InvalidLine_Returns_Fail()
        {
            // Arrange
            var line = "Fail";

            // Act
            var result = await _sut.Validate(line);

            // Assert
            Assert.IsFalse(result.valid);
        }

        [TestMethod]
        public async Task IncorrectNumber_Fields_Fail()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24";

            // Act
            var result = await _sut.Validate(line);

            // Assert
            Assert.IsFalse(result.valid);
        }

        [TestMethod]
        public async Task Invalid_MeterReading_Fail()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24,12T";

            // Act
            var result = await _sut.Validate(line);

            // Assert
            Assert.IsFalse(result.valid);
        }

        [TestMethod]
        public async Task Negative_MeterReading_Fail()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24,-12";

            // Act
            var result = await _sut.Validate(line);

            // Assert
            Assert.IsFalse(result.valid);
        }

        [TestMethod]
        public async Task Valid_MeterReading_Succeeds()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24,-12";

            // Act
            var result = await _sut.Validate(line);

            // Assert
            Assert.IsTrue(result.valid);
            Assert.IsNotNull(result.reading);
        }
    }
}