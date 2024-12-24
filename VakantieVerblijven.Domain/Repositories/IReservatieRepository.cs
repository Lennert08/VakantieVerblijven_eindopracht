using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;
using VakantieVerblijven.Domain.ValueObject;

namespace VakantieVerblijven.Domain.Repositories
{
    public interface IReservatieRepository
    {
        List<Reservatie> GetProbleemReservaties();
        List<Reservatie> GetReservatiesByMonth(DateTime date);
        bool VoegReservatieToe(KlantVO gekozenKlant, ParkVO gekozenPark, int aantalPersonen, DateTime startDatum, DateTime eindDatum, HuisVO gekozenHuis);
    }
}
