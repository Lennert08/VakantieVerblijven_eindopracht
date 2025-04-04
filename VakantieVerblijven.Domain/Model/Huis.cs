﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VakantieVerblijven.Domain.Model
{
    public class Huis
    {
        private int _id;
        private string _straat;
        private int _nummer;
        private int _aantalPersonen;

        public int Id
        {
            get => _id;
            init
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _id = value;
            }
        }
        public string Straat
        {
            get => _straat;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _straat = value;
            }
        }
        public int Nummer
        {
            get => _nummer;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                _nummer = value;
            }
        }
        public int AantalPersonen
        {
            get => _aantalPersonen;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _aantalPersonen = value;
            }
        }
        public bool Actief { get; set; }
        public Park Park { get; set; }
        public string VolledigAdres => $"{Straat} {Nummer}";
        public string OnderhoudStatus => Actief ? "Geen onderhoud" : "In onderhoud";


        public Huis(int id, string straat, int nummer, bool actief, int aantalPersonen)
        {
            Id = id;
            Straat = straat;
            Nummer = nummer;
            Actief = actief;
            AantalPersonen = aantalPersonen;
        }
        public Huis (int id, string straat, int nummer, bool actief, int aantalPersonen, Park park) : this(id, straat, nummer, actief, aantalPersonen)
        {
            Park = park;
        }
        public override bool Equals(object? obj)
        {
            return obj is Huis huis &&
                   Id == huis.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
