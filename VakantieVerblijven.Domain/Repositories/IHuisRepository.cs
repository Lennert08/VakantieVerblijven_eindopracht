using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;

namespace VakantieVerblijven.Domain.Repositories
{
    public interface IHuisRepository
    {
        List<Huis> GetAllHuizen();
        List<Huis> GetBeschikbareHuizen(int parkId, int aantalPersonen, DateTime beginDatum, DateTime eindDatum);
        List<string> GetPersonenOpties();
    }
}
