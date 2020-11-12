using API.Service;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Service
{
    public static partial class IoC
    {
        public static IJuntosSomosMaisService JsmService => new JuntosSomosMaisService(null, new HttpClient());
    }

    public class JuntosSomosMaisServiceTest
    {
        [Fact]
        public async Task GetJson()
        {
            // Act
            var result = await IoC.JsmService.GetJson().ConfigureAwait(false);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1000, result.Count());
        }

        [Fact]
        public async Task GetCSV()
        {
            // Act
            var result = await IoC.JsmService.GetCSV().ConfigureAwait(false);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(1000, result.Count());
        }
    }
}
