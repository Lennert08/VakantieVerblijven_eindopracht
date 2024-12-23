using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;

namespace VakantieVerblijven.Domain.ValueObject
{
    public class HuisVO
    {
        public int Id { get; set; } 
        public string Straat { get; set; }
        public int Nummer { get; set; }
        public int AantalPersonen { get; set; }
        public bool Actief { get; set; }
        public ParkVO Park { get; set; }
        public string VolledigAdres => $"{Straat} {Nummer}";
        public string OnderhoudStatus => Actief ? "Geen onderhoud" : "In onderhoud";


        public HuisVO(int id, string straat, int nummer, bool actief, int aantalPersonen)
        {
            Id = id;
            Straat = straat;
            Nummer = nummer;
            Actief = actief;
            AantalPersonen = aantalPersonen;
        }
        public HuisVO(int id, string straat, int nummer, bool actief, int aantalPersonen, ParkVO park) : this(id, straat, nummer, actief, aantalPersonen)
        {
            Park = park;
        }
    }
}
