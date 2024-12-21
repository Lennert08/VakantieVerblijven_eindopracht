using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.Domain.Model
{
    public class Reservatie
    {
        private int _id;
        public int Id
        {
            get => _id;
            init
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _id = value;
            }
        }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public Klant Klant { get; set; }
        public Huis Huis { get; set; }
        public string FormattedStartDatum => StartDatum.ToString("dd/MM/yyyy");
        public string FormattedEindDatum => EindDatum.ToString("dd/MM/yyyy");

        public Reservatie(int id, DateTime startDatum, DateTime eindDatum, Klant klant, Huis huis)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Klant = klant;
            Huis = huis;
        }

        public override bool Equals(object? obj)
        {
            return obj is Reservatie reservatie &&
                   Id == reservatie.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
