using API.Extension;
using Xunit;

namespace UnitTest.Extension
{
    public class RegionExtensionTest
    {
        [Theory]
        [InlineData("PARAN�", "Sul")]
        [InlineData("s�o paulo", "Sudeste")]
        [InlineData("alagoas", "Nordeste")]
        [InlineData("", "")]
        public void Region(string state, string response)
        {
            // Act
            var result = state.Region();

            // Assert
            Assert.Equal(response, result);
        }
    }
}
