namespace Reading.Application.Test
{
    [TestClass]
    public class AccountValidatorTests
    {
        private readonly AccountValidator _sut = new();

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
            const string line = "2344,John";

            // Act
            var error = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(error!.Contains("Expecting 3 fields in input"));
        }

        [TestMethod]
        public void Invalid_AccountId_Fail()
        {
            // Arrange
            const string line = "A,John";

            // Act
            var error = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(error!.Contains("Invalid AccountId in input"));
        }

        [TestMethod]
        public void Invalid_FirstName_Fail()
        {
            // Arrange
            const string line = "1,,12";

            // Act
            var error = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(error!.Contains($"Invalid FirstName in input ({error})"));
        }

        [TestMethod]
        public void Invalid_LastName_Fail()
        {
            // Arrange
            const string line = "2344,John,";

            // Act
            var error = _sut.Validate(line, out _);

            // Assert
            Assert.IsTrue(error!.Contains("Invalid LastName in input"));
        }

        [TestMethod]
        public void Valid_Account_Succeeds()
        {
            // Arrange
            const string line = "2344,John,Doe";

            // Act
            var error = _sut.Validate(line, out var account);

            // Assert
            Assert.IsNull(error);
            Assert.IsNotNull(account);
        }
    }
}
