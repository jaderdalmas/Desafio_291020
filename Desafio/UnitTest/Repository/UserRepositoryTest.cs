using API.Models;
using API.Repository;
using API.Service;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace UnitTest.Repository
{
    public class UserRepositoryTest
    {
        private IUserRepository Repo => new UserRepository(new JuntosSomosMaisService(new HttpClient()));

        [Fact]
        public void Add_Input_Null()
        {
            // Arrange
            UserInput insumo = null;

            // Act
            var result = Repo.Add(insumo);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Add_Input_Empty()
        {
            // Arrange
            var insumo = new UserInput();

            // Act
            var result = Repo.Add(insumo);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Add_Output_Null()
        {
            // Arrange
            UserOutput insumo = null;

            // Act
            var result = Repo.Add(insumo);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Add_Output_Empty()
        {
            // Arrange
            var insumo = new UserOutput();

            // Act
            var result = Repo.Add(insumo);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Get_Empty()
        {
            // Act
            var result = Repo.GetUsers(string.Empty, EClassification.LABORIOUS);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Get_NotEmpty()
        {
            // Act
            var result = Repo.GetUsers("Norte", EClassification.LABORIOUS);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void InsumoResponse_0_50()
        {
            // Arrange
            var result = Repo.GetUsers("Norte", EClassification.LABORIOUS);

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
            var result = Repo.GetUsers("Norte", EClassification.LABORIOUS);

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
            var result = Repo.GetUsers("Norte", EClassification.LABORIOUS);

            // Act
            var response = new UserResponse(result, 11, 50);

            // Assert
            Assert.Empty(response.Users);
        }
    }
}
