using Microsoft.Extensions.Logging;
using Moq;
using Reading.Entity;
using Reading.Infrastructure;

namespace Reading.Application.Test
{
    [TestClass]
    public class AccountProcessorTests
    {
        private Mock<IAccountRepository> _mockAccountRepository = null!;
        private Mock<IAccountValidator> _mockAccountValidator = null!;
        private Mock<ILogger<AccountProcessor>> _mockLogger = null!;

        private IAccountProcessor _sut = null!;

        [TestInitialize]
        public void Initialise()
        {
            _mockLogger = new Mock<ILogger<AccountProcessor>>();
            _mockAccountValidator = new Mock<IAccountValidator>();
            _mockAccountRepository = new Mock<IAccountRepository>();

            _sut = new AccountProcessor(_mockAccountRepository.Object, _mockAccountValidator.Object, _mockLogger.Object);
        }

        [TestMethod]
        public async Task Seed_Valid_CSV_Should_Call_Add()
        {
            // Arrange
            const string csv = "1,John,Doe";
            Account? inserted = null;
            _mockAccountRepository.Setup(x => x.Add(It.IsAny<Account>())).Callback<Account>(y => inserted = y);
            var validAccount = new Account(accountId: 1, firstName: "John", lastName: "Doe");
            _mockAccountValidator.Setup(x => x.Validate(It.IsAny<string>(), out validAccount)).Returns((string?)null);

            // Act
            await _sut.Seed(csv);

            _mockAccountRepository.Verify(x => x.Add(It.IsAny<Account>()), Times.Once);
            Assert.AreEqual(validAccount, inserted);
        }
    }
}
