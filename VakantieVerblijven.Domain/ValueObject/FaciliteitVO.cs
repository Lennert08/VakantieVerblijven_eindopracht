using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.Domain.ValueObject
{
    public class FaciliteitVO
    {
        public int Id { get; set; }
        public string Beschrijving { get; set; }

        public FaciliteitVO(int id, string beschrijving)
        {
            Id = id;
            Beschrijving = beschrijving;
        }
    }
}
