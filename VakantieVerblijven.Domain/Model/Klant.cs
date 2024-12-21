using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.Domain.Model
{
    public class Klant
    {
        private int _id;
        private string _naam;
        private string _adres;

        public int Id
        {
            get => _id;
            init
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _id = value;
            }
        }
        public string Naam
        {
            get => _naam;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _naam = value;
            }
        }
        public string Adres
        {
            get => _adres;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _adres = value;
            }
        }

        public Klant(int id, string naam, string adres)
        {
            Id = id;
            Naam = naam;
            Adres = adres;
        }

        public override bool Equals(object? obj)
        {
            return obj is Klant klant &&
                   Id == klant.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
