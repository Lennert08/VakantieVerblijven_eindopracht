using System.Windows;
using VakantieVerblijven.Domain;
using VakantieVerblijven.Domain.Classes;
using VakantieVerblijven.Domain.ValueObject;
using VakantieVerblijven.Presentation.Windows;

namespace VakantieVerblijven.Presentation
{
    public class VakantieVerblijvenApplication
    {
        #region Fields + constructor
        private DomainManager _domainManager;

        //fields
        private KlantVO _gekozenKlantVoorReservatieAanmaak; //leegmaken na reservatie aanmaak
        private ParkVO _gekozenParkVoorReservatieAanmaak; //leegmaken na reservatie aanmaak

        //windows
        private HomeWindow _homeWindow;
        private ReservatiesWindow _reservatiesWindow;
        private HuizenOverzichtWindow _huizenOverzichtWindow;
        private TeVerplaatsenResWindow _teVerplaatsenResWindow;
        private ParkSelectieScherm _parkSelectieScherm;
        private KlantSelectieScherm _klantSelectieScherm;
        private ReservatieAanmaakWindow _reservatieAanmaakWindow;

        public VakantieVerblijvenApplication(DomainManager domainManager)
        {
            _domainManager = domainManager;

            _reservatiesWindow = new ReservatiesWindow(_domainManager.GetReservatiesByMonth(DateTime.Today)); //haalt alle reseravties van de huidige maand op 
            _homeWindow = new HomeWindow();
            _huizenOverzichtWindow = new HuizenOverzichtWindow(_domainManager.GetAllHuizen());
            _teVerplaatsenResWindow = new TeVerplaatsenResWindow(_domainManager.GetProbleemReservaties());
            _parkSelectieScherm = new ParkSelectieScherm(_domainManager.GetAlleFaciliteiten(),_domainManager.GetAllParken());
            _klantSelectieScherm = new KlantSelectieScherm();
            _reservatieAanmaakWindow = new ReservatieAanmaakWindow();

            //linken van Window Navigators
            _homeWindow.NavigationButtonClicked += NavigateToNextWindow;
            _huizenOverzichtWindow.NavigationButtonClicked += NavigateToNextWindow;
            _reservatiesWindow.NavigationButtonClicked += NavigateToNextWindow;
            _teVerplaatsenResWindow.NavigationButtonClicked += NavigateToNextWindow;
            _parkSelectieScherm.NavigationButtonClicked += NavigateToNextWindow;
            _klantSelectieScherm.NavigationButtonClicked += NavigateToNextWindow;
            _reservatieAanmaakWindow.NavigationButtonClicked += NavigateToNextWindow;

            //linken van alle andere events
            _huizenOverzichtWindow.HuisSelected += UpdateOnderhoudButton;
            _parkSelectieScherm.CheckboxChecked += UpdateParkLijst;
            _klantSelectieScherm.ZoekButtonClicked += ZoekKlantOpInDatabase;
            _klantSelectieScherm.KlantGekozen += GekozenKlantOpslagen;
            _parkSelectieScherm.ParkSelected += GekozenParkOpslaan;

            _homeWindow.Show();
        }

        private void GekozenParkOpslaan(object? sender, ParkVO gekozenPark)
        {
            _gekozenParkVoorReservatieAanmaak = gekozenPark;
        }

        #endregion


        #region WindowManager
        private void NavigateToNextWindow(object? sender, string windowALsTag)
        {
           if (sender is Window teSluitenWindow)
            {
                switch (windowALsTag) {
                    case "Reservatie":
                        SchermManager.NavigateToNextWindow(teSluitenWindow, _reservatiesWindow);
                        break;
                    case "Huizen":
                        SchermManager.NavigateToNextWindow(teSluitenWindow, _huizenOverzichtWindow);
                        break;
                    case "ReservatieVerplaats":
                        SchermManager.NavigateToNextWindow(teSluitenWindow, _teVerplaatsenResWindow);
                        break;
                    case "Home":
                        SchermManager.NavigateToNextWindow(teSluitenWindow, _homeWindow);
                        break;
                    case "ParkSelectie":
                        SchermManager.NavigateToNextWindow(teSluitenWindow, _parkSelectieScherm);
                        break;
                    case "KlantSelectie":
                        SchermManager.NavigateToNextWindow(teSluitenWindow, _klantSelectieScherm);
                        break;
                    case "ReservatieAanmaak":
                        SchermManager.NavigateToNextWindow(teSluitenWindow, _reservatieAanmaakWindow);
                        break;
                }
            }
        }

        #endregion

        #region HuizenOverzichtWindow
        public void UpdateOnderhoudButton(object? sender, HuisVO huis)
        {
            if (huis.Actief)
            {
                _huizenOverzichtWindow.OnderhoudButton.Content = "Voeg toe aan onderhoud";
                _huizenOverzichtWindow.OnderhoudButton.Background = System.Windows.Media.Brushes.MidnightBlue;
                _huizenOverzichtWindow.OnderhoudButton.IsEnabled = true;
            }
            else
            {
                _huizenOverzichtWindow.OnderhoudButton.Content = "Verwijder uit onderhoud";
                _huizenOverzichtWindow.OnderhoudButton.Background =
                (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#E53935");
                _huizenOverzichtWindow.OnderhoudButton.IsEnabled = true;

            }
        }
        #endregion

        #region ReservatiesWindow

        #endregion

        #region TeVerplaatsenResWindow

        #endregion

        #region ParkSelectieScherm
        private void UpdateParkLijst(object? sender, EventArgs e)
        {
            if (_parkSelectieScherm.heeftGeenVoorkeur) // als er geen voorkeur is tonen we de standaard parken
            {
                _parkSelectieScherm.ParkenLijst.ItemsSource = _parkSelectieScherm._standaardParken;
            } else
            {
                bool isStatusLijstLeeg = !_parkSelectieScherm._faciliteitenStatus.Values.Contains(true);

                if (isStatusLijstLeeg)
                {
                    _parkSelectieScherm.ParkenLijst.ItemsSource = null; //lijst leegmaken want er is niks geselecteerd
                } else
                {
                    List<FaciliteitVO> gekozenFaciliteiten = ListConverter.ConvertFaciliteitDictionaryToList(_parkSelectieScherm._faciliteitenStatus);
                    _parkSelectieScherm.ParkenLijst.ItemsSource = _domainManager.GetParkenByFaciliteiten(gekozenFaciliteiten);
                }

            }
        }
        #endregion

        #region KlantSelectieScherm
        private void ZoekKlantOpInDatabase(object? sender, string zoekTerm)
        {
            List<KlantVO> gevondenKlanten = _domainManager.ZoekKlant(zoekTerm);

            if (gevondenKlanten.Count == 0)
            {
                MessageBox.Show("Geen klanten gevonden", "Informatie", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _klantSelectieScherm.klantListBox.ItemsSource = gevondenKlanten;
            }
        }

        private void GekozenKlantOpslagen(object? sender, KlantVO gekozenKlant)
        {
            _gekozenKlantVoorReservatieAanmaak = gekozenKlant;
        }

        #endregion

        #region ReservatieAanmaakWindow

        #endregion
    }
}
