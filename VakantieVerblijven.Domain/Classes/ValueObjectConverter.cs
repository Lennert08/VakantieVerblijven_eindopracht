using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;
using VakantieVerblijven.Domain.Repositories;
using VakantieVerblijven.Domain.ValueObject;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VakantieVerblijven.Domain.Classes
{
    internal static  class ValueObjectConverter
    {
        public static List<ReservatieVO> ConvertReservatieToValueObject (List<Reservatie> reservaties)
        {
            return reservaties.Select(r =>
                new ReservatieVO(
                    r.Id,
                    r.StartDatum,
                    r.EindDatum,
                    new KlantVO(r.Klant.Id, r.Klant.Naam, r.Klant.Adres),
                    new HuisVO(
                        r.Huis.Id,
                        r.Huis.Straat,
                        r.Huis.Nummer,
                        r.Huis.Actief,
                        r.Huis.AantalPersonen
                    )
                )
            ).ToList();
        }

        public static List<HuisVO> ConvertHuisToValueObject(List<Huis> huizen)
        {
            return huizen.Select(h =>
                new HuisVO(
                    h.Id,
                    h.Straat,
                    h.Nummer,
                    h.Actief,
                    h.AantalPersonen,
                    new ParkVO(h.Park.Id, h.Park.Naam, h.Park.Locatie)
                )
            ).ToList();
        }

        public static List<ParkVO> ConvertParkToValueObject(List<Park> parken)
        {
            return parken.Select(p => new ParkVO(p.Id, p.Naam, p.Locatie)).ToList();
        }

        public static List<FaciliteitVO> ConvertFaciliteitToValueObject(List<Faciliteit> faciliteiten)
        {
            return faciliteiten.Select(f => new FaciliteitVO(f.Id, f.Beschrijving)).ToList();
        }

        public static List<KlantVO> ConvertKlantToValueObject(List<Klant> klanten)
        {
            return klanten.Select(k => new KlantVO(k.Id, k.Naam, k.Adres)).ToList();
        }
    }
}
