using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.Presentation.CustomEventArgs
{
    public class ZoekKnopEventArgs : EventArgs
    {
        public int AantalPersonen { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }

        public ZoekKnopEventArgs(int aantalPersonen, DateTime startDatum, DateTime eindDatum)
        {
            this.AantalPersonen = aantalPersonen;
            StartDatum = startDatum;
            EindDatum = eindDatum;
        }
    }
}
