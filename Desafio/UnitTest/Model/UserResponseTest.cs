using API.Models;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Model
{
    public class UserResponseTest
    {
        [Fact]
        public void Response_Single()
        {
            // Arrange
            var user = new UserOutput()
            {
                Type = EClassification.LABORIOUS.ToString(),
                Location = new Location() { Region = string.Empty }
            };
            var list = new List<UserOutput>() { user }; 

            // Act
            var response = new UserResponse(list, 0, 50);

            // Assert
            Assert.NotEmpty(response.Users);
            Assert.Single(response.Users);
        }
    }
}
