namespace Reading.Application.Test
{
    [TestClass]
    public class ValidatorTests
    {
        private readonly Validator _sut = new();

        [TestMethod]
        public void InvalidLine_Returns_Fail()
        {
            // Arrange
            var line = "Fail";

            // Act
            var result = _sut.Validate(line, out _);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IncorrectNumber_Fields_Fail()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24";

            // Act
            var result = _sut.Validate(line, out _);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Invalid_MeterReading_Fail()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24,12T";

            // Act
            var result = _sut.Validate(line, out _);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Negative_MeterReading_Fail()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24,-12";

            // Act
            var result = _sut.Validate(line, out _);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Valid_MeterReading_Succedes()
        {
            // Arrange
            var line = "2344,22/04/2019 09:24,-12";

            // Act
            var result = _sut.Validate(line, out var reading);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(reading);
        }
    }
}