using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.Presentation.CustomEventArgs
{
    public class ReservatieZoekKnopEventArgs : EventArgs
    {
        public int ParkId { get; set; }
        public DateTime? StartDatum { get; set; }
        public DateTime? EindDatum { get; set; }
        public string KlantNaam { get; set; }

        public ReservatieZoekKnopEventArgs(int parkId, DateTime? startDatum, DateTime? eindDatum, string klantNaam)
        {
            ParkId = parkId;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            KlantNaam = klantNaam;
        }

    }
}
