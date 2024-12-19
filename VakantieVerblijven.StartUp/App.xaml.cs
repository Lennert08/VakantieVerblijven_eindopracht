using System.Configuration;
using System.Data;
using System.Windows;
using VakantieVerblijven.Domain;
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
            DomainManager domainManager = new DomainManager();
            VakantieVerblijvenApplication vakantieVerblijvenApplication = new VakantieVerblijvenApplication(domainManager); 

        }
    }

}
