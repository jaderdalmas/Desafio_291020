using API;
using API.Extension;
using API.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest.Controller
{
    public class UsersControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UsersControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetNoUsers()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new UserRequest();
            Assert.False(request.IsValid());

            // Act
            var response = await client.PostAsync("Users", request.AsContent());

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetUsers()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new UserRequest()
            {
                Classification = EClassification.LABORIOUS,
                Region = "Norte"
            };
            Assert.True(request.IsValid());

            // Act
            var response = await client.PostAsync("Users", request.AsContent());

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.NotEmpty(result);

            var userResponse = JsonSerializer.Deserialize<UserResponse>(result);
            Assert.NotEmpty(userResponse.Users);
        }

        [Fact]
        public async Task GetUsers_Empty()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new UserRequest()
            {
                Classification = EClassification.LABORIOUS,
                Region = "Norte",
                PageNumber = 999
            };
            Assert.True(request.IsValid());

            // Act
            var response = await client.PostAsync("Users", request.AsContent());

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.NotEmpty(result);

            var userResponse = JsonSerializer.Deserialize<UserResponse>(result);
            Assert.Empty(userResponse.Users);
        }
    }
}
