using System;
using VakantieVerblijven.Domain.Classes;
using Xunit;

namespace VakantieVerblijven.XUnitTests
{
    public class ReservatieDatumsCheckerTests
    {
        [Fact]
        public void ReservatieDatumsValidatie_BeginDatumInHetVerleden_ThrowArgumentException()
        {
            // Arrange
            DateTime startDate = DateTime.Now.AddDays(-1);
            DateTime endDate = DateTime.Now.AddDays(1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ReservatieDatumsChecker.ReservatieDatumsValidatie(startDate, endDate));
            Assert.Equal("De begindatum mag niet in het verleden liggen.", exception.Message);
        }

        [Fact]
        public void ReservatieDatumsValidatie_EindDatumInHetVerleden_ThrowArgumentException()
        {
            // Arrange
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = DateTime.Now.AddDays(-1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ReservatieDatumsChecker.ReservatieDatumsValidatie(startDate, endDate));
            Assert.Equal("De einddatum mag niet in het verleden liggen.", exception.Message);
        }

        [Fact]
        public void ReservatieDatumsValidatie_BeginDatumNaEindDatum_ThrowArgumentException()
        {
            // Arrange
            DateTime startDate = DateTime.Now.AddDays(5);
            DateTime endDate = DateTime.Now.AddDays(3);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ReservatieDatumsChecker.ReservatieDatumsValidatie(startDate, endDate));
            Assert.Equal("De begindatum mag niet na de einddatum liggen.", exception.Message);
        }

        [Fact]
        public void ReservatieDatumsValidatie_ReservatieTeLang_ThrowArgumentException()
        {
            // Arrange
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(366);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ReservatieDatumsChecker.ReservatieDatumsValidatie(startDate, endDate));
            Assert.Equal("De reservatie mag niet langer dan 1 jaar zijn.", exception.Message);
        }

        [Fact]
        public void ReservatieDatumsValidatie_BeginDatumTeVerInDeToekomst_ThrowArgumentException()
        {
            // Arrange
            DateTime startDate = DateTime.Now.AddYears(11);
            DateTime endDate = startDate.AddDays(1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ReservatieDatumsChecker.ReservatieDatumsValidatie(startDate, endDate));
            Assert.Equal("De begindatum is te ver in de toekomst.", exception.Message);
        }

        [Fact]
        public void ReservatieDatumsValidatie_EindDatumTeVerInDeToekomst_ThrowArgumentException()
        {
            // Arrange
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddYears(11);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ReservatieDatumsChecker.ReservatieDatumsValidatie(startDate, endDate));
            Assert.Equal("De einddatum is te ver in de toekomst.", exception.Message);
        }

        [Fact]
        public void ReservatieDatumsValidatie_ValidDatums_DoesNotThrowException()
        {
            // Arrange
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = DateTime.Now.AddDays(10);

            // Act & Assert
            var exception = Record.Exception(() => ReservatieDatumsChecker.ReservatieDatumsValidatie(startDate, endDate));
            Assert.Null(exception); // Geen uitzondering verwacht
        }

        [Fact]
        public void ReservatieDatumsValidatie_BeginEnEindDatumZelfdeDag_ThrowArgumentException()
        {
            // Arrange
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = startDate;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => ReservatieDatumsChecker.ReservatieDatumsValidatie(startDate, endDate));
            Assert.Equal("De einddatum moet minstens één dag na de begindatum liggen.", exception.Message);
        }
    }
}
