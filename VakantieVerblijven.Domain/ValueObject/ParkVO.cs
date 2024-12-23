using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.Domain.ValueObject
{
    public class ParkVO
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Locatie { get; set; }

        public ParkVO(int id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }
        public override string ToString()
        {
            return $"{Naam} ({Locatie})";
        }
    }
}
