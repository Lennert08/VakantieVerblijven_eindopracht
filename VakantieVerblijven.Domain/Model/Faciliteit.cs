using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.Domain.Model
{
    public class Faciliteit
    {
        private int _id;
        private string _beschrijving;

        public int Id
        {
            get => _id;
            init
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _id = value;
            }
        }
        public string Beschrijving
        {
            get => _beschrijving;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _beschrijving = value;
            }
        }

        public Faciliteit(int id, string beschrijving)
        {
            Id = id;
            Beschrijving = beschrijving;
        }

        public override bool Equals(object? obj)
        {
            return obj is Faciliteit faciliteit &&
                   Id == faciliteit.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
