using API.Extension;
using Xunit;

namespace UnitTest.Extension
{
    public class StringExtensionTest
    {
        [Theory]
        [InlineData("(86) 8370-9831", "+558683709831")]
        [InlineData("(11) 97134-0111", "+5511971340111")]
        [InlineData("", "")]
        public void E164(string phone, string response)
        {
            // Act
            var result = phone.E164();

            // Assert
            Assert.Equal(response, result);
        }

        [Theory]
        [InlineData("female", "F")]
        [InlineData("male", "M")]
        [InlineData("", "")]
        public void UpperFirst(string text, string response)
        {
            // Act
            var result = text.UpperFirst();

            // Assert
            Assert.Equal(response, result);
        }
    }
}
