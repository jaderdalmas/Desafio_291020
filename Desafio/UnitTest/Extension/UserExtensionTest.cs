using API.Extension;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Extension
{
    public class UserExtensionTest
    {
        [Fact]
        public void GetInputs()
        {
            // Arrange
            var list = new List<string>
            {
                "\"gender\",\"name__title\",\"name__first\",\"name__last\",\"location__street\",\"location__city\",\"location__state\",\"location__postcode\",\"location__coordinates__latitude\",\"location__coordinates__longitude\",\"location__timezone__offset\",\"location__timezone__description\",\"email\",\"dob__date\",\"dob__age\",\"registered__date\",\"registered__age\",\"phone\",\"cell\",\"picture__large\",\"picture__medium\",\"picture__thumbnail\"",

                "\"female\", \"mrs\", \"ione\", \"da costa\", \"8614 avenida vin�cius de morais\", \"ponta grossa\", \"rond�nia\", \"97701\", \"-76.3253\", \"137.9437\", \"-1:00\", \"Azores, Cape Verde Islands\", \"ione.dacosta@example.com\", \"1968-01-24T18:03:23Z\", \"50\", \"2004-01-23T23:54:33Z\", \"14\", \"(01) 5415-5648\", \"(10) 8264-5550\", \"https://randomuser.me/api/portraits/women/46.jpg\", \"https://randomuser.me/api/portraits/med/women/46.jpg\", \"https://randomuser.me/api/portraits/thumb/women/46.jpg\""
            };

            // Act
            var result = list.GetInputs();

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
