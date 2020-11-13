using API.Models;
using API.Repository;
using API.Service;
using Moq;
using Xunit;

namespace UnitTest.Repository
{
    public class UserRepositoryTest
    {
        [Fact]
        public void Add_Output_Null()
        {
            // Arrange
            var jsm = new Mock<IJuntosSomosMaisService>();
            var repos = new UserMemory(jsm.Object);
            UserOutput user = null;

            // Act
            var result = repos.Add(user);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Add_Output_Empty()
        {
            // Arrange
            var jsm = new Mock<IJuntosSomosMaisService>();
            var repos = new UserMemory(jsm.Object);
            var user = new UserOutput();

            // Act
            var result = repos.Add(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Get_Empty()
        {
            // Arrange
            var jsm = new Mock<IJuntosSomosMaisService>();
            var repos = new UserMemory(jsm.Object);

            // Act
            var result = repos.GetUsers("Outro", EClassification.LABORIOUS);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Get_NotEmpty()
        {
            // Arrange
            var user = new UserOutput()
            {
                Type = EClassification.LABORIOUS.ToString(),
                Location = new Location() { Region = string.Empty }
            };

            var jsm = new Mock<IJuntosSomosMaisService>();
            var repos = new UserMemory(jsm.Object);
            repos.Add(user);

            // Act
            var result = repos.GetUsers(string.Empty, EClassification.LABORIOUS);

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
