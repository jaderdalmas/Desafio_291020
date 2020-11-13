using API.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Service
{
    public class JuntosSomosMaisServiceTest
    {
        [Fact]
        public async Task GetJson_Empty()
        {
            var log = new LoggerFactory().CreateLogger<JuntosSomosMaisService>();

            // Arrange
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty) };
            var handler = new Mock<HttpMessageHandler>();
            handler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(response);

            var config = new Mock<IConfiguration>();
            config.Setup(x => x["JSM:JsonCsv_Repos"]).Returns("http://localhost");
            var service = new JuntosSomosMaisService(config.Object, log, new HttpClient(handler.Object));

            // Act
            var result = await service.GetJson().ConfigureAwait(false);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetCSV_Empty()
        {
            var log = new LoggerFactory().CreateLogger<JuntosSomosMaisService>();

            // Arrange
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty) };
            var handler = new Mock<HttpMessageHandler>();
            handler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(response);

            var config = new Mock<IConfiguration>();
            config.Setup(x => x["JSM:JsonCsv_Repos"]).Returns("http://localhost");
            var service = new JuntosSomosMaisService(config.Object, log, new HttpClient(handler.Object));

            // Act
            var result = await service.GetCSV().ConfigureAwait(false);

            // Assert
            Assert.Empty(result);
        }
    }
}
