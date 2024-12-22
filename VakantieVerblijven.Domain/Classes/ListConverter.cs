using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;

namespace VakantieVerblijven.Domain.Classes
{
    public static class ListConverter
    {
        public static List<Faciliteit> ConvertFaciliteitDictionaryToList(Dictionary<Faciliteit, bool> faciliteitenStatus)
        {
            List<Faciliteit> result = new List<Faciliteit>(); // Correct type gebruikt
            foreach (KeyValuePair<Faciliteit, bool> kvp in faciliteitenStatus)
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
