using System.Configuration;
using System.Data;
using System.Windows;
using VakantieVerblijven.Domain;
using VakantieVerblijven.Domain.Repositories;
using VakantieVerblijven.Persistence.Mappers;
using VakantieVerblijven.Presentation;

namespace VakantieVerblijven.StartUp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ReservatieMapper reservatieMapper = new ReservatieMapper();
            HuisMapper huisMapper = new HuisMapper();
            FaciliteitMapper faciliteitMapper = new FaciliteitMapper();
            ParkMapper parkMapper = new ParkMapper();
            KlantMapper klantMapper = new KlantMapper();

            DomainManager domainManager = new DomainManager(reservatieMapper, huisMapper, faciliteitMapper, parkMapper, klantMapper);
            VakantieVerblijvenApplication vakantieVerblijvenApplication = new VakantieVerblijvenApplication(domainManager); 
        }
    }

}
