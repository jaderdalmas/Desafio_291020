using API;
using API.Extension;
using API.Models;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest.Controller
{
    public class UsersControllerTest : IClassFixture<TestApplicationFactory<Startup>>
    {
        private readonly TestApplicationFactory<Startup> _factory;

        public UsersControllerTest(TestApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetUsers_BadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            client.AddAuthHeader();

            // Act
            var response = await client.GetAsync("Users");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetUsers()
        {
            // Arrange
            var client = _factory.CreateClient();
            client.AddAuthHeader();

            // Act
            var response = await client.GetAsync("Users?region=Norte&classification=2");

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
            client.AddAuthHeader();

            // Act
            var response = await client.GetAsync("Users?region=Norte&classification=2&pageNumber=999");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.NotEmpty(result);

            var userResponse = JsonSerializer.Deserialize<UserResponse>(result);
            Assert.Empty(userResponse.Users);
        }

        [Fact]
        public async Task PostUsers_BadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            client.AddAuthHeader();
            List<UserInput> request = null;

            // Act
            var response = await client.PostAsync("Users", request.AsContent());

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostUsers_False()
        {
            // Arrange
            var client = _factory.CreateClient();
            client.AddAuthHeader();
            var request = new List<UserInput>();

            // Act
            var response = await client.PostAsync("Users", request.AsContent());

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.NotEmpty(result);

            var objResult = JsonSerializer.Deserialize<bool>(result);
            Assert.False(objResult);
        }

        [Fact]
        public async Task PostUsers_True()
        {
            // Arrange
            var client = _factory.CreateClient();
            client.AddAuthHeader();
            var request = new List<UserInput>() { new UserInput() };

            // Act
            var response = await client.PostAsync("Users", request.AsContent());

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.NotEmpty(result);

            var objResult = JsonSerializer.Deserialize<bool>(result);
            Assert.True(objResult);
        }
    }
}
