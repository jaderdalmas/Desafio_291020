using API.Models;
using API.Repository;
using API.Service;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Service
{
    public class UserServiceTest
    {
        [Fact]
        public void Add_Input_Null()
        {
            // Arrange
            var repos = new Mock<IUserRepository>();
            var service = new UserService(null, repos.Object);
            List<UserInput> users = null;

            // Act
            var result = service.Add(users);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Add_Input_Empty()
        {
            // Arrange
            var repos = new Mock<IUserRepository>();
            var service = new UserService(null, repos.Object);
            var users = new List<UserInput>();

            // Act
            var result = service.Add(users);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Add_Input_Single()
        {
            // Arrange
            var repos = new Mock<IUserRepository>();
            repos.Setup(m => m.Add(It.IsAny<UserOutput>())).Returns(true);
            var service = new UserService(null, repos.Object);

            var users = new List<UserInput>() { new UserInput() };

            // Act
            var result = service.Add(users);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Add_Output_Null()
        {
            // Arrange
            var repos = new Mock<IUserRepository>();
            var service = new UserService(null, repos.Object);
            UserOutput user = null;

            // Act
            var result = service.Add(user);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Add_Output_Empty()
        {
            // Arrange
            var repos = new Mock<IUserRepository>();
            var service = new UserService(null, repos.Object);
            repos.Setup(m => m.Add(It.IsAny<UserOutput>())).Returns(true);
            var user = new UserOutput();

            // Act
            var result = service.Add(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Get_Empty()
        {
            // Arrange
            var repos = new Mock<IUserRepository>();
            var service = new UserService(null, repos.Object);

            // Act
            var result = service.GetUsers("Outro", EClassification.LABORIOUS);

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

            var repos = new Mock<IUserRepository>();
            repos.Setup(m => m.GetUsers(It.IsAny<string>(), It.IsAny<EClassification>())).Returns(new List<UserOutput>() { user });
            var service = new UserService(null, repos.Object);

            // Act
            var result = service.GetUsers(string.Empty, EClassification.LABORIOUS);

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
