using API.Extension;
using API.Models;
using Xunit;

namespace UnitTest.Extension
{
    public class ClassificationExtensionTest
    {
        [Fact]
        public void Classification_Null()
        {
            // Arrange
            Coordinates coord = null;

            // Act
            var result = coord.Classification();

            // Assert
            Assert.Equal(EClassification.LABORIOUS, result);
        }

        [Fact]
        public void Classification_Empty()
        {
            // Arrange
            var coord = new Coordinates();

            // Act
            var result = coord.Classification();

            // Assert
            Assert.Equal(EClassification.LABORIOUS, result);
        }

        [Fact]
        public void Classification_Especial()
        {
            // Arrange
            var coord = new Coordinates()
            {
                Latitude = "-40",
                Longitude = "-10"
            };

            // Act
            var result = coord.Classification();

            // Assert
            Assert.Equal(EClassification.ESPECIAL, result);
        }

        [Fact]
        public void Classification_Normal()
        {
            // Arrange
            var coord = new Coordinates()
            {
                Latitude = "-50",
                Longitude = "-30"
            };

            // Act
            var result = coord.Classification();

            // Assert
            Assert.Equal(EClassification.NORMAL, result);
        }

        [Fact]
        public void Classification_Laborious()
        {
            // Arrange
            var coord = new Coordinates()
            {
                Latitude = "0",
                Longitude = "0"
            };

            // Act
            var result = coord.Classification();

            // Assert
            Assert.Equal(EClassification.LABORIOUS, result);
        }
    }
}
