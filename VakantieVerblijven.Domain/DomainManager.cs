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
        private IHuisRepository _huisRepository;

        public DomainManager(IReservatieRepository reservatieRepository, IHuisRepository huisRepository)
        {
            _reservatieRepository = reservatieRepository;
            _huisRepository = huisRepository;
        }

        public List<Reservatie> GetReservatiesByMonth(DateTime date)
        {
            return _reservatieRepository.GetReservatiesByMonth(date);
        }
        public List<Huis> GetAllHuizen()
        {
            return _huisRepository.GetAllHuizen();
        }

        public List<Reservatie> GetProbleemReservaties()
        {
            return _reservatieRepository.GetProbleemReservaties();
        }
    }
}
