using VakantieVerblijven.Domain.Classes;
using VakantieVerblijven.Domain.Model;

namespace VakantieVerblijven.XUnitTests
{
    public class ListConverterTests
    {
        [Fact]
        public void LijstTestMetAlleenTrueWaardes()
        {
            // Arrange: Maak een dictionary waarin alle waarden op true staan
            Dictionary<Faciliteit,bool> faciliteitenStatus = new Dictionary<Faciliteit, bool>
            {
                { new Faciliteit(1, "Zwembad"), true },
                { new Faciliteit(2, "Sauna"), true },
                { new Faciliteit(3, "Speeltuin"), true }
            };

            // Act: Roep de methode aan
            List<Faciliteit> result = ListConverter.ConvertFaciliteitDictionaryToList(faciliteitenStatus);

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
            Dictionary<Faciliteit, bool> faciliteitenStatus = new Dictionary<Faciliteit, bool>
            {
                { new Faciliteit(1, "Zwembad"), true },
                { new Faciliteit(2, "Sauna"), false },
                { new Faciliteit(3, "Speeltuin"), true }
            };

            // Act: Roep de methode aan
            List<Faciliteit> result = ListConverter.ConvertFaciliteitDictionaryToList(faciliteitenStatus);

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
            Dictionary<Faciliteit, bool> faciliteitenStatus = new Dictionary<Faciliteit, bool>
            {
                { new Faciliteit(1, "Zwembad"), false },
                { new Faciliteit(2, "Sauna"), false },
                { new Faciliteit(3, "Speeltuin"), false }
            };

            // Act: Roep de methode aan
            List<Faciliteit> result = ListConverter.ConvertFaciliteitDictionaryToList(faciliteitenStatus);

            // Assert: Controleer dat de geretourneerde lijst leeg is
            Assert.Empty(result);
        }

        [Fact]
        public void LegeLijstTests()
        {
            // Arrange: Maak een lege dictionary
            Dictionary<Faciliteit, bool> faciliteitenStatus = new Dictionary<Faciliteit, bool>();

            // Act: Roep de methode aan
            List<Faciliteit> result = ListConverter.ConvertFaciliteitDictionaryToList(faciliteitenStatus);

            // Assert: Controleer dat de geretourneerde lijst leeg is
            Assert.Empty(result);
        }
    }
}