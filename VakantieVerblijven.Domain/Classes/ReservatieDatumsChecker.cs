using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.Domain.Classes
{
    public static class ReservatieDatumsChecker
    {
        public static void ReservatieDatumsValidatie(DateTime startDate, DateTime endDate)
        {
            // Check of de begin- en einddatum niet in het verleden liggen
            if (startDate < DateTime.Now.Date)
            {
                throw new ArgumentException("De begindatum mag niet in het verleden liggen.");
            }

            if (endDate < DateTime.Now.Date)
            {
                throw new ArgumentException("De einddatum mag niet in het verleden liggen.");
            }

            // Check of de begin- en einddatum in de juiste volgorde zijn
            if (startDate > endDate)
            {
                throw new ArgumentException("De begindatum mag niet na de einddatum liggen.");
            }

            // Check of er minstens één dag verschil is tussen begin- en einddatum
            if ((endDate - startDate).TotalDays < 1)
            {
                throw new ArgumentException("De einddatum moet minstens één dag na de begindatum liggen.");
            }

            // Check of de begindatum te ver in de toekomst ligt
            if (startDate > DateTime.Now.AddYears(10))
            {
                throw new ArgumentException("De begindatum is te ver in de toekomst.");
            }

            // Check of de einddatum te ver in de toekomst ligt
            if (endDate > DateTime.Now.AddYears(10))
            {
                throw new ArgumentException("De einddatum is te ver in de toekomst.");
            }

            // Check of de reservatie niet langer is dan een limiet (bijv. 1 jaar)
            if ((endDate - startDate).TotalDays > 365)
            {
                throw new ArgumentException("De reservatie mag niet langer dan 1 jaar zijn.");
            }
        }


    }
}
