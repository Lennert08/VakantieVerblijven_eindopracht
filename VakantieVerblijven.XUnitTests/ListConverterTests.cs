using VakantieVerblijven.Domain.Classes;
using VakantieVerblijven.Domain.Model;
using VakantieVerblijven.Domain.ValueObject;

namespace VakantieVerblijven.XUnitTests
{
    public class ListConverterTests
    {
        [Fact]
        public void LijstTestMetAlleenTrueWaardes()
        {
            // Arrange: Maak een dictionary waarin alle waarden op true staan
            Dictionary<FaciliteitVO, bool> faciliteitenStatus = new Dictionary<FaciliteitVO, bool>
            {
                { new FaciliteitVO(1, "Zwembad"), true },
                { new FaciliteitVO(2, "Sauna"), true },
                { new FaciliteitVO(3, "Speeltuin"), true }
            };

            // Act: Roep de methode aan
            List<FaciliteitVO> result = ListConverter.ConvertFaciliteitDictionaryToList(faciliteitenStatus);

            // Assert: Controleer dat alle faciliteiten aanwezig zijn in de geretourneerde lijst
            Assert.Equal(3, result.Count);
            Assert.Contains(result, f => f.Beschrijving == "Zwembad");
            Assert.Contains(result, f => f.Beschrijving == "Sauna");
            Assert.Contains(result, f => f.Beschrijving == "Speeltuin");
        }

        [Fact]
        public void LijstTestMetAlleenGemixedeBools()
        {
            // Arrange: Maak een dictionary met een mix van true en false waarden
            Dictionary<FaciliteitVO, bool> faciliteitenStatus = new Dictionary<FaciliteitVO, bool>
            {
                { new FaciliteitVO(1, "Zwembad"), true },
                { new FaciliteitVO(2, "Sauna"), false },
                { new FaciliteitVO(3, "Speeltuin"), true }
            };

            // Act: Roep de methode aan
            List<FaciliteitVO> result = ListConverter.ConvertFaciliteitDictionaryToList(faciliteitenStatus);

            // Assert: Controleer dat alleen de faciliteiten met true worden geretourneerd
            Assert.Equal(2, result.Count);
            Assert.Contains(result, f => f.Beschrijving == "Zwembad");
            Assert.Contains(result, f => f.Beschrijving == "Speeltuin");
            Assert.DoesNotContain(result, f => f.Beschrijving == "Sauna");
        }

        [Fact]
        public void LijstTestMetAlleenFalseWaardes()
        {
            // Arrange: Maak een dictionary waarin alle waarden op false staan
            Dictionary<FaciliteitVO, bool> faciliteitenStatus = new Dictionary<FaciliteitVO, bool>
            {
                { new FaciliteitVO(1, "Zwembad"), false },
                { new FaciliteitVO(2, "Sauna"), false },
                { new FaciliteitVO(3, "Speeltuin"), false }
            };

            // Act: Roep de methode aan
            List<FaciliteitVO> result = ListConverter.ConvertFaciliteitDictionaryToList(faciliteitenStatus);

            // Assert: Controleer dat de geretourneerde lijst leeg is
            Assert.Empty(result);
        }

        [Fact]
        public void LegeLijstTests()
        {
            // Arrange: Maak een lege dictionary
            Dictionary<FaciliteitVO, bool> faciliteitenStatus = new Dictionary<FaciliteitVO, bool>();

            // Act: Roep de methode aan
            List<FaciliteitVO> result = ListConverter.ConvertFaciliteitDictionaryToList(faciliteitenStatus);

            // Assert: Controleer dat de geretourneerde lijst leeg is
            Assert.Empty(result);
        }
    }
}