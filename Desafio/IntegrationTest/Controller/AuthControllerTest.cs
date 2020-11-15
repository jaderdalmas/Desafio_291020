using API;
using API.Extension;
using API.Models;
using IntegrationTest.Model;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest.Controller
{
    public class AuthControllerTest : IClassFixture<TestApplicationFactory<Startup>>
    {
        private readonly TestApplicationFactory<Startup> _factory;

        public AuthControllerTest(TestApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Authenticate_Empty()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new AuthenticateRequest() { UserName = string.Empty, Password = string.Empty };

            // Act
            var response = await client.PostAsync("/Auth", request.AsContent());

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.NotEmpty(result);

            var badResponse = JsonSerializer.Deserialize<BadRequestMessage>(result);
            Assert.Equal("Username or password is incorrect", badResponse.Message);
        }

        [Fact]
        public async Task Authenticate()
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new AuthenticateRequest() { UserName = "test", Password = "test" };

            // Act
            var response = await client.PostAsync("/Auth", request.AsContent());

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.NotEmpty(result);

            var authResponse = JsonSerializer.Deserialize<AuthenticateResponse>(result);
            Assert.NotEmpty(authResponse.UserName);
        }
    }
}
