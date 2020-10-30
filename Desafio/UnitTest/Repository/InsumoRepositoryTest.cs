using API.Models;
using API.Repository;
using API.Service;
using System.Net.Http;
using Xunit;

namespace UnitTest.Repository
{
    public class InsumoRepositoryTest
    {
        private IInsumoRepository Repo => new InsumoRepository(new JuntosSomosMaisService(new HttpClient()));

        [Fact]
        public void Add_Input_Null()
        {
            // Arrange
            InsumoInput insumo = null;

            // Act
            var result = Repo.Add(insumo);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Add_Input_Empty()
        {
            // Arrange
            var insumo = new InsumoInput();

            // Act
            var result = Repo.Add(insumo);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Add_Output_Null()
        {
            // Arrange
            InsumoOutput insumo = null;

            // Act
            var result = Repo.Add(insumo);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Add_Output_Empty()
        {
            // Arrange
            var insumo = new InsumoOutput();

            // Act
            var result = Repo.Add(insumo);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Get_Empty()
        {
            // Act
            var result = Repo.GetInsumos(string.Empty, EClassification.LABORIOUS);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Get_NotEmpty()
        {
            // Act
            var result = Repo.GetInsumos("Norte", EClassification.LABORIOUS);

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
