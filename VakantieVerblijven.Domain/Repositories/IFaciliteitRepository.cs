using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;

namespace VakantieVerblijven.Domain.Repositories
{
    public interface IFaciliteitRepository
    {
        List<Faciliteit> GetAlleFaciliteiten();
    }
}
