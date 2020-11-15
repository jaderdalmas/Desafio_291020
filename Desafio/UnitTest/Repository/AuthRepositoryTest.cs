using API.Repository;
using Xunit;

namespace UnitTest.Repository
{
    public class AuthRepositoryTest
    {
        [Fact]
        public void Authenticate_Null()
        {
            // Arrange
            var repos = new AuthRepository();

            // Act
            var result = repos.Authenticate(null, null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Authenticate_Empty()
        {
            // Arrange
            var repos = new AuthRepository();

            // Act
            var result = repos.Authenticate(string.Empty, string.Empty);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Authenticate()
        {
            // Arrange
            var repos = new AuthRepository();

            // Act
            var result = repos.Authenticate("test", "test");

            // Assert
            Assert.NotNull(result);
        }
    }
}
