using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;
using VakantieVerblijven.Domain.ValueObject;

namespace VakantieVerblijven.Domain.Classes
{
    public static class ListConverter
    {
        public static List<FaciliteitVO> ConvertFaciliteitDictionaryToList(Dictionary<FaciliteitVO, bool> faciliteitenStatus)
        {
            List<FaciliteitVO> result = new List<FaciliteitVO>(); // Correct type gebruikt
            foreach (KeyValuePair<FaciliteitVO, bool> kvp in faciliteitenStatus)
            {
                if (kvp.Value) // Check of de waarde true is
                {
                    result.Add(kvp.Key); // Voeg de faciliteit toe aan de lijst
                }
            }
            return result; // Retourneer de lijst
        }
    }
}
