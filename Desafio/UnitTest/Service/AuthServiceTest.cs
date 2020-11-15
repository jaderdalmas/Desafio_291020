using API.Models;
using API.Repository;
using API.Service;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Service
{
    public class AuthServiceTest
    {
        [Fact]
        public async Task Authenticate_Null()
        {
            // Arrange
            var repos = new Mock<IAuthRepository>();
            var service = new AuthService(repos.Object);

            // Act
            var result = await service.Authenticate(null, null).ConfigureAwait(false);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Authenticate_Empty()
        {
            // Arrange
            var repos = new Mock<IAuthRepository>();
            var service = new AuthService(repos.Object);

            // Act
            var result = await service.Authenticate(string.Empty, string.Empty).ConfigureAwait(false);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Authenticate()
        {
            // Arrange
            var repos = new Mock<IAuthRepository>();
            repos.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(new Authenticate());
            var service = new AuthService(repos.Object);

            // Act
            var result = await service.Authenticate("test", "test").ConfigureAwait(false);

            // Assert
            Assert.NotNull(result);
        }
    }
}
