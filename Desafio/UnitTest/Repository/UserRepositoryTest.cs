using API.Models;
using API.Repository;
using System.Linq;
using Xunit;

namespace UnitTest.Repository
{
    public static partial class IoC
    {
        public static IUserRepository UserRepos => new UserRepository(Service.IoC.JsmService);
    }

    public class UserRepositoryTest
    {
        [Fact]
        public void Add_Output_Null()
        {
            // Arrange
            UserOutput user = null;

            // Act
            var result = IoC.UserRepos.Add(user);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Add_Output_Empty()
        {
            // Arrange
            var user = new UserOutput();

            // Act
            var result = IoC.UserRepos.Add(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Get_Empty()
        {
            // Act
            var result = IoC.UserRepos.GetUsers(string.Empty, EClassification.LABORIOUS);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Get_NotEmpty()
        {
            // Act
            var result = IoC.UserRepos.GetUsers("Norte", EClassification.LABORIOUS);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void InsumoResponse_0_50()
        {
            // Arrange
            var result = IoC.UserRepos.GetUsers("Norte", EClassification.LABORIOUS);

            // Act
            var response = new UserResponse(result, 0, 50);

            // Assert
            Assert.NotEmpty(response.Users);
            Assert.Equal(50, response.Users.Count());
        }

        [Fact]
        public void InsumoResponse_10_50()
        {
            // Arrange
            var result = IoC.UserRepos.GetUsers("Norte", EClassification.LABORIOUS);

            // Act
            var response = new UserResponse(result, 10, 50);

            // Assert
            Assert.NotEmpty(response.Users);
            Assert.Equal(6, response.Users.Count());
        }

        [Fact]
        public void InsumoResponse_11_50()
        {
            // Arrange
            var result = IoC.UserRepos.GetUsers("Norte", EClassification.LABORIOUS);

            // Act
            var response = new UserResponse(result, 11, 50);

            // Assert
            Assert.Empty(response.Users);
        }
    }
}
