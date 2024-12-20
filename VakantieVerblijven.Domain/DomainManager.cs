using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;
using VakantieVerblijven.Domain.Repositories;

namespace VakantieVerblijven.Domain
{
    public class DomainManager
    {
        private IReservatieRepository _reservatieRepository;
        public DomainManager(IReservatieRepository reservatieRepository)
        {
            _reservatieRepository = reservatieRepository;
        }

        public List<Reservatie> GetReservatiesByMonth(DateTime date)
        {
            return _reservatieRepository.GetReservatiesByMonth(date);
        }
    }
}
