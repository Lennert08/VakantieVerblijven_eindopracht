using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Classes;
using VakantieVerblijven.Domain.Model;
using VakantieVerblijven.Domain.Repositories;
using VakantieVerblijven.Domain.ValueObject;

namespace VakantieVerblijven.Domain
{
    public class DomainManager
    {
        private IReservatieRepository _reservatieRepository;
        private IHuisRepository _huisRepository;
        private IFaciliteitRepository _faciliteitRepository;
        private IParkRepository _parkRepository;
        private IKlantRepository _klantRepository;

        public DomainManager(IReservatieRepository reservatieRepository, IHuisRepository huisRepository, IFaciliteitRepository faciliteitRepository, IParkRepository parkRepository, IKlantRepository klantRepository)
        {
            _reservatieRepository = reservatieRepository;
            _huisRepository = huisRepository;
            _faciliteitRepository = faciliteitRepository;
            _parkRepository = parkRepository;
            _klantRepository = klantRepository;
        }

        //reservaties
        public List<ReservatieVO> GetReservatiesByMonth(DateTime date)
        {
            return ValueObjectConverter.ConvertReservatieToValueObject(_reservatieRepository.GetReservatiesByMonth(date));
        }
        public bool VoegReservatieToe(KlantVO gekozenKlant, ParkVO gekozenPark, int aantalPersonen, DateTime startDatum, DateTime eindDatum, HuisVO gekozenHuis)
        {
            return _reservatieRepository.VoegReservatieToe(gekozenKlant, gekozenPark, aantalPersonen, startDatum, eindDatum, gekozenHuis);
        }
        public List<ReservatieVO> GetProbleemReservaties()
        {
            return ValueObjectConverter.ConvertReservatieToValueObject(_reservatieRepository.GetProbleemReservaties());
        }
        public List<ReservatieVO> ZoekReservaties(string klantZoekTerm, int parkId)
        {
            return ValueObjectConverter.ConvertReservatieToValueObject(_reservatieRepository.ZoekReservaties(klantZoekTerm, parkId));
        }
        public List<ReservatieVO> ZoekReservatiesMetPeriode(string klantZoekTerm, int parkId, DateTime? startDatum, DateTime? eindDatum)
        {
            return ValueObjectConverter.ConvertReservatieToValueObject(_reservatieRepository.ZoekReservatiesMetPeriode(klantZoekTerm, parkId, startDatum, eindDatum));
        }
        //huizen
        public List<HuisVO> GetAllHuizen()
        {
            return ValueObjectConverter.ConvertHuisToValueObject(_huisRepository.GetAllHuizen());
        }
        public List<string> GetPersonenOpties()
        {
            return _huisRepository.GetPersonenOpties();
        }
        public List<HuisVO> GetBeschikbareHuizen(int parkId, int aantalPersonen, DateTime beginDatum, DateTime eindDatum)
        {
            return ValueObjectConverter.ConvertHuisToValueObject(_huisRepository.GetBeschikbareHuizen(parkId, aantalPersonen, beginDatum, eindDatum));
        }
        public void ZetHuisInOnderhoud(int huisId)
        {
            _huisRepository.ZetHuisInOnderhoud(huisId);
        }

        public void HaalHuisUitOnderhoud(int huisId)
        {
            _huisRepository.HaalHuisUitOnderhoud(huisId);
        }
        //faciliteiten
        public List<FaciliteitVO> GetAlleFaciliteiten()
        {
            return ValueObjectConverter.ConvertFaciliteitToValueObject(_faciliteitRepository.GetAlleFaciliteiten());
        }
        //parken
        public List<ParkVO> GetAllParken()
        {
            return ValueObjectConverter.ConvertParkToValueObject(_parkRepository.GetAllParks());
        }
        public List<ParkVO> GetParkenByFaciliteiten(List<FaciliteitVO> faciliteiten)
        {
            return ValueObjectConverter.ConvertParkToValueObject(_parkRepository.GetParksByFacilities(faciliteiten));
        }
        //klanten
        public List<KlantVO> ZoekKlant(string zoekterm)
        {
            return ValueObjectConverter.ConvertKlantToValueObject(_klantRepository.ZoekKlant(zoekterm));
        }
    }
}
