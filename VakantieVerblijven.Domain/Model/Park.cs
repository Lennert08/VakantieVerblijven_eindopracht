using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.Domain.Model
{
    public class Park
    {
        private int _id;
        private string _naam;
        private string _locatie;

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
        public string Locatie
        {
            get => _locatie;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _locatie = value;
            }
        }

        public Park(int id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }
        public override string ToString()
        {
            return $"{Naam} ({Locatie})";
        }

        public override bool Equals(object? obj)
        {
            return obj is Park park &&
                   Id == park.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
