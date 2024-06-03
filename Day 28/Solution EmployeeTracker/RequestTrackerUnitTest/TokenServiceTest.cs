
using EmployeeTracker.Interfaces;
using EmployeeTracker.Models;
using EmployeeTracker.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace RequestTrackerUnitTest
{
    public class TokenServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void GenerateTokenSuccessTest()
        {
            //Arrange
            Mock<IConfigurationSection> configurationJWTSection = new Mock<IConfigurationSection>();
            configurationJWTSection.Setup(x => x.Value).Returns("This is the dummy key which has to be a bit long for the 512. which should be even more longer for the passing");
            Mock<IConfigurationSection> congigTokenSection = new Mock<IConfigurationSection>();
            congigTokenSection.Setup(x => x.GetSection("JWT")).Returns(configurationJWTSection.Object);
            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection("TokenKey")).Returns(congigTokenSection.Object);
            ITokenService service = new TokenService(mockConfig.Object);

            //Action
            var token = service.GenerateToken(new Employee { Id = 103 ,Role="user" });

            //Assert
            Assert.IsNotNull(token);
        }
    }
}