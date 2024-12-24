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

        //fields voor het aanmaken van een reservatie
        private KlantVO _gekozenKlant; //leegmaken na reservatie aanmaak
        private ParkVO _gekozenPark; //leegmaken na reservatie aanmaak
        private int _aantalPersonen; //leegmaken na reservatie aanmaak
        private DateTime _startDatum; //leegmaken na reservatie aanmaak
        private DateTime _eindDatum; //leegmaken na reservatie aanmaak
        private HuisVO _gekozenHuis; //leegmaken na reservatie aanmaak
        //windows
        private HomeWindow _homeWindow;
        private ReservatiesWindow _reservatiesWindow;
        private HuizenOverzichtWindow _huizenOverzichtWindow;
        private TeVerplaatsenResWindow _teVerplaatsenResWindow;
        private ParkSelectieScherm _parkSelectieScherm;
        private KlantSelectieScherm _klantSelectieScherm;
        private ReservatieAanmaakWindow _reservatieAanmaakWindow;
        private ReservatieAanmaakOverzicht _reservatieAanmaakOverzicht;

        public VakantieVerblijvenApplication(DomainManager domainManager)
        {
            _domainManager = domainManager;

            _reservatiesWindow = new ReservatiesWindow(_domainManager.GetReservatiesByMonth(DateTime.Today)); //haalt alle reseravties van de huidige maand op 
            _homeWindow = new HomeWindow();
            _huizenOverzichtWindow = new HuizenOverzichtWindow(_domainManager.GetAllHuizen());
            _teVerplaatsenResWindow = new TeVerplaatsenResWindow(_domainManager.GetProbleemReservaties());
            _parkSelectieScherm = new ParkSelectieScherm(_domainManager.GetAlleFaciliteiten(),_domainManager.GetAllParken());
            _klantSelectieScherm = new KlantSelectieScherm();
            _reservatieAanmaakWindow = new ReservatieAanmaakWindow(_domainManager.GetPersonenOpties());

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
            _reservatieAanmaakWindow.ZoekKnopSelected += BeschikBareHuizenZoeken;
            _reservatieAanmaakWindow.huisGekozen += GaNaarReservatieAanmaakOvericht;

            _homeWindow.Show();
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

        private void GekozenParkOpslaan(object? sender, ParkVO gekozenPark)
        {
            _gekozenPark = gekozenPark;
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
            _gekozenKlant = gekozenKlant;
        }

        #endregion

        #region ReservatieAanmaakWindow
        private void BeschikBareHuizenZoeken(object? sender, CustomEventArgs.ZoekKnopEventArgs e)
        {
            try
            {
                ReservatieDatumsChecker.ReservatieDatumsValidatie(e.StartDatum, e.EindDatum);
                List<HuisVO> beschikbareHuizen = new List<HuisVO>();
                beschikbareHuizen = _domainManager.GetBeschikbareHuizen(_gekozenPark.Id, e.AantalPersonen, e.StartDatum, e.EindDatum);

                _aantalPersonen = e.AantalPersonen;
                _startDatum = e.StartDatum;
                _eindDatum = e.EindDatum;

                _reservatieAanmaakWindow.HuisLijst.ItemsSource = beschikbareHuizen;
            } catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GaNaarReservatieAanmaakOvericht(object? sender, HuisVO gekozenHuis)
        {
            _gekozenHuis = gekozenHuis;
            _reservatieAanmaakOverzicht = new ReservatieAanmaakOverzicht(_gekozenKlant, _gekozenPark, _aantalPersonen, _startDatum, _eindDatum, _gekozenHuis);
            _reservatieAanmaakOverzicht.NavigationButtonClicked += NavigateToNextWindow;
            _reservatieAanmaakOverzicht.ReservatieVastLegButtonClicked += ReservatieAanmaken;
            SchermManager.NavigateToNextWindow(_reservatieAanmaakWindow, _reservatieAanmaakOverzicht);

        }

        #endregion

        #region ReservatieAanmaakOverzicht
        private void ReservatieAanmaken(object? sender, EventArgs e)
        {
            try
            {
                bool reservatieToegevoegd =  _domainManager.VoegReservatieToe(_gekozenKlant, _gekozenPark, _aantalPersonen, _startDatum, _eindDatum, _gekozenHuis);
                if (reservatieToegevoegd)
                {
                    MessageBox.Show("Reservatie toegevoegd", "Informatie", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigateToNextWindow(_reservatieAanmaakOverzicht, "Home");

                    // hier onder heel het aanmaakproces resetten
                    _gekozenKlant = null;
                    _gekozenPark = null;
                    _aantalPersonen = 0;
                    _startDatum = DateTime.MinValue;
                    _eindDatum = DateTime.MinValue;
                    _gekozenHuis = null;

                    _klantSelectieScherm = new KlantSelectieScherm();
                    _parkSelectieScherm = new ParkSelectieScherm(_domainManager.GetAlleFaciliteiten(), _domainManager.GetAllParken());
                    _reservatieAanmaakWindow = new ReservatieAanmaakWindow(_domainManager.GetPersonenOpties());
                    LinkEventsNaReservatieAanmaak();
                }
                else
                {
                    MessageBox.Show("Reservatie niet toegevoegd", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fout bij het toevoegen van de reservatie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        public void LinkEventsNaReservatieAanmaak()
        {
            //navigatie
            _parkSelectieScherm.NavigationButtonClicked += NavigateToNextWindow;
            _klantSelectieScherm.NavigationButtonClicked += NavigateToNextWindow;
            _reservatieAanmaakWindow.NavigationButtonClicked += NavigateToNextWindow;

            //andere events
            _parkSelectieScherm.CheckboxChecked += UpdateParkLijst;
            _klantSelectieScherm.ZoekButtonClicked += ZoekKlantOpInDatabase;
            _klantSelectieScherm.KlantGekozen += GekozenKlantOpslagen;
            _parkSelectieScherm.ParkSelected += GekozenParkOpslaan;
            _reservatieAanmaakWindow.ZoekKnopSelected += BeschikBareHuizenZoeken;
            _reservatieAanmaakWindow.huisGekozen += GaNaarReservatieAanmaakOvericht;
        }
    }
}
