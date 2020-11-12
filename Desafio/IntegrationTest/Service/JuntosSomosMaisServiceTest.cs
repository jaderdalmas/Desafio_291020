using API.Service;
using Microsoft.Extensions.Configuration;
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
            // Arrange
            var config = new Mock<IConfiguration>();
            config.Setup(x => x["JSM:JsonCsv_Repos"]).Returns("https://storage.googleapis.com/juntossomosmais-code-challenge");
            var service = new JuntosSomosMaisService(config.Object, new HttpClient());

            // Act
            var result = await service.GetJson().ConfigureAwait(false);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1000, result.Count());
        }

        [Fact]
        public async Task GetCSV()
        {
            // Arrange
            var config = new Mock<IConfiguration>();
            config.Setup(x => x["JSM:JsonCsv_Repos"]).Returns("https://storage.googleapis.com/juntossomosmais-code-challenge");
            var service = new JuntosSomosMaisService(config.Object, new HttpClient());

            // Act
            var result = await service.GetCSV().ConfigureAwait(false);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1000, result.Count());
        }
    }
}
