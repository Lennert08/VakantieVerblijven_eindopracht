using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.Domain.Classes
{
    public static class ReservatieDatumsChecker
    {
        public static void ReservatieDatumsValidatie(DateTime startDatum, DateTime eindDatum)
        {
            // Check of de begin- en einddatum niet in het verleden liggen
            if (startDatum < DateTime.Now.Date)
            {
                throw new ArgumentException("De begindatum mag niet in het verleden liggen.");
            }

            if (eindDatum < DateTime.Now.Date)
            {
                throw new ArgumentException("De einddatum mag niet in het verleden liggen.");
            }

            // Check of de begin- en einddatum in de juiste volgorde zijn
            if (startDatum > eindDatum)
            {
                throw new ArgumentException("De begindatum mag niet na de einddatum liggen.");
            }

            // Check of er minstens één dag verschil is tussen begin- en einddatum
            if ((eindDatum - startDatum).TotalDays < 1)
            {
                throw new ArgumentException("De einddatum moet minstens één dag na de begindatum liggen.");
            }

            // Check of de begindatum te ver in de toekomst ligt
            if (startDatum > DateTime.Now.AddYears(10))
            {
                throw new ArgumentException("De begindatum is te ver in de toekomst.");
            }

            // Check of de einddatum te ver in de toekomst ligt
            if (eindDatum > DateTime.Now.AddYears(10))
            {
                throw new ArgumentException("De einddatum is te ver in de toekomst.");
            }

            // Check of de reservatie niet langer is dan een limiet (bijv. 1 jaar)
            if ((eindDatum - startDatum).TotalDays > 365)
            {
                throw new ArgumentException("De reservatie mag niet langer dan 1 jaar zijn.");
            }
        }

        public static bool ReservatieZoekenDatumsValidatie(DateTime? startDatum, DateTime? eindDatum)
        {
            // Controleer of één van de datums niet null is terwijl de andere wel null is
            if (startDatum.HasValue != eindDatum.HasValue)
            {
                throw new ArgumentException("Zorg dat allebei de datums zijn ingegeven");
            }

            // Controleer of de begindatum niet na de einddatum ligt
            if (startDatum > eindDatum)
            {
                throw new ArgumentException("De begindatum mag niet na de einddatum liggen.");
            }

            // Controleer of de datums niet op dezelfde dag liggen
            if (startDatum.HasValue && eindDatum.HasValue && startDatum.Value.Date == eindDatum.Value.Date)
            {
                throw new ArgumentException("De begindatum en einddatum mogen niet op dezelfde dag liggen.");
            }

            if (startDatum == null || eindDatum == null)
            {
                return false; //datums zijn niet ingevuld
            } else
            {
                return true; //datums zijn ingevuld
            }
        }
    }
}
