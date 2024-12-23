using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.Domain.ValueObject
{
    public class KlantVO
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }

        public KlantVO(int id, string naam, string adres)
        {
            Id = id;
            Naam = naam;
            Adres = adres;
        }

        public override string? ToString()
        {
            return $"{Naam} ({Adres})";
        }
    }
}
