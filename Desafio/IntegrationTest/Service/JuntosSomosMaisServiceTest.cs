using API.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest.Service
{
    public class JuntosSomosMaisServiceTest
    {
        [Fact]
        public async Task GetJson()
        {
            var log = new LoggerFactory().CreateLogger<JuntosSomosMaisService>();

            // Arrange
            var config = new Mock<IConfiguration>();
            config.Setup(x => x["JSM:JsonCsv_Repos"]).Returns("https://storage.googleapis.com/juntossomosmais-code-challenge");
            var service = new JuntosSomosMaisService(config.Object, log, new HttpClient());

            // Act
            var result = await service.GetJson().ConfigureAwait(false);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1000, result.Count());
        }

        [Fact]
        public async Task GetCSV()
        {
            var log = new LoggerFactory().CreateLogger<JuntosSomosMaisService>();

            // Arrange
            var config = new Mock<IConfiguration>();
            config.Setup(x => x["JSM:JsonCsv_Repos"]).Returns("https://storage.googleapis.com/juntossomosmais-code-challenge");
            var service = new JuntosSomosMaisService(config.Object, log, new HttpClient());

            // Act
            var result = await service.GetCSV().ConfigureAwait(false);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1000, result.Count());
        }
    }
}
