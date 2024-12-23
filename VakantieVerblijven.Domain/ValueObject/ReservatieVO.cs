using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;

namespace VakantieVerblijven.Domain.ValueObject
{
    public class ReservatieVO
    {
        public int Id { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public KlantVO Klant { get; set; }
        public HuisVO Huis { get; set; }
        public string FormattedStartDatum => StartDatum.ToString("dd/MM/yyyy");
        public string FormattedEindDatum => EindDatum.ToString("dd/MM/yyyy");

        public ReservatieVO(int id, DateTime startDatum, DateTime eindDatum, KlantVO klant, HuisVO huis)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Klant = klant;
            Huis = huis;
        }
    }
}
