using API.Service;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Service
{
    public class JuntosSomosMaisServiceTest
    {
        private IJuntosSomosMaisService Service => new JuntosSomosMaisService(new HttpClient());

        [Fact]
        public async Task GetJson()
        {
            // Act
            var result = await Service.GetJson().ConfigureAwait(false);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1000, result.Count());
        }

        [Fact]
        public async Task GetCSV()
        {
            // Act
            var result = await Service.GetCSV().ConfigureAwait(false);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1000, result.Count());
        }
    }
}
