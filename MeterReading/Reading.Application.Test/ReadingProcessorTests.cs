using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Moq;
using Reading.Entity;
using Reading.Infrastructure;

namespace Reading.Application.Test
{
    [TestClass]
    public class ReadingProcessorTests
    {
        private Mock<IAccountRepository> _mockAccountRepository = null!;
        private Mock<IReadingRepository> _mockReadingRepository = null!;
        private Mock<IReadingValidator> _mockReadingValidator = null!;
        private Mock<ILogger<ReadingProcessor>> _mockLogger = null!;

        private IReadingProcessor _sut = null!;

        [TestInitialize]
        public void Initialise()
        {
            _mockLogger = new Mock<ILogger<ReadingProcessor>>();
            _mockReadingValidator = new Mock<IReadingValidator>();
            _mockReadingRepository = new Mock<IReadingRepository>();
            _mockAccountRepository = new Mock<IAccountRepository>();

            _sut = new ReadingProcessor(_mockAccountRepository.Object, _mockReadingRepository.Object, _mockReadingValidator.Object, _mockLogger.Object);
        }

        [TestMethod]
        public async Task Process_Valid_CSV_Should_Call_Add()
        {
            // Arrange
            const string csv = "1,22/04/2019 09:24,01002";
            Entity.Reading? inserted = null;
            _mockReadingRepository.Setup(x => x.Add(It.IsAny<Entity.Reading>())).Callback<Entity.Reading>(y => inserted = y);
            var validAccount = new Account(accountId: 1, firstName: "John", lastName: "Doe");
            var validReading = new Entity.Reading(accountId: 1, meterReadingDateTime: new DateTime(2024, 1, 1),
                meterReadingValue: 1234);
            _mockReadingValidator.Setup(x => x.Validate(It.IsAny<string>(), out validReading)).Returns((string?)null);
            _mockAccountRepository.Setup(x => x.Get(It.IsAny<int>())).ReturnsAsync(validAccount);

            // Act
            await _sut.ProcessCSV(csv);

            _mockAccountRepository.Verify(x => x.Add(It.IsAny<Account>()), Times.Once);
            Assert.AreEqual(validReading, inserted);
        }
    }
}
