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
        private IFaciliteitRepository _faciliteitRepository;
        private IParkRepository _parkRepository;

        public DomainManager(IReservatieRepository reservatieRepository, IHuisRepository huisRepository, IFaciliteitRepository faciliteitRepository, IParkRepository parkRepository)
        {
            _reservatieRepository = reservatieRepository;
            _huisRepository = huisRepository;
            _faciliteitRepository = faciliteitRepository;
            _parkRepository = parkRepository;
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

        public List<Faciliteit> GetAlleFaciliteiten()
        {
            return _faciliteitRepository.GetAlleFaciliteiten();
        }
        public List<Park> GetAllParken()
        {
            return _parkRepository.GetAllParks();
        }
        public List<Park> GetParkenByFaciliteiten(List<Faciliteit> faciliteiten)
        {
            return _parkRepository.GetParksByFacilities(faciliteiten);
        }
    }
}
