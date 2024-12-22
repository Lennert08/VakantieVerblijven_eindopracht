using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VakantieVerblijven.Domain;
using VakantieVerblijven.Domain.Classes;
using VakantieVerblijven.Domain.Model;
using VakantieVerblijven.Presentation.Windows;

namespace VakantieVerblijven.Presentation
{
    public class VakantieVerblijvenApplication
    {
        #region Fields + constructor
        private DomainManager _domainManager;

        //windows
        private HomeWindow _homeWindow;
        private ReservatiesWindow _reservatiesWindow;
        private HuizenOverzichtWindow _huizenOverzichtWindow;
        private TeVerplaatsenResWindow _teVerplaatsenResWindow;
        private ParkSelectieScherm _parkSelectieScherm;

        public VakantieVerblijvenApplication(DomainManager domainManager)
        {
            _domainManager = domainManager;
            _reservatiesWindow = new ReservatiesWindow(_domainManager.GetReservatiesByMonth(DateTime.Today)); //haalt alle reseravties van de huidige maand op 
            _homeWindow = new HomeWindow();
            _huizenOverzichtWindow = new HuizenOverzichtWindow(_domainManager.GetAllHuizen());
            _teVerplaatsenResWindow = new TeVerplaatsenResWindow(_domainManager.GetProbleemReservaties());
            _parkSelectieScherm = new ParkSelectieScherm(_domainManager.GetAlleFaciliteiten(),_domainManager.GetAllParken());

            //linken van Window Navigators
            _homeWindow.NavigationButtonClicked += NavigateToNextWindow;
            _huizenOverzichtWindow.NavigationButtonClicked += NavigateToNextWindow;
            _reservatiesWindow.NavigationButtonClicked += NavigateToNextWindow;
            _teVerplaatsenResWindow.NavigationButtonClicked += NavigateToNextWindow;
            _parkSelectieScherm.NavigationButtonClicked += NavigateToNextWindow;

            //linken van alle andere events
            _huizenOverzichtWindow.HuisSelected += UpdateOnderhoudButton;
            _parkSelectieScherm.CheckboxChecked += UpdateParkLijst;

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
                }
            }
        }

        #endregion

        #region HuizenOverzichtWindow
        public void UpdateOnderhoudButton(object? sender, Huis huis)
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
                    List<Faciliteit> gekozenFaciliteiten = ListConverter.ConvertFaciliteitDictionaryToList(_parkSelectieScherm._faciliteitenStatus);
                    _parkSelectieScherm.ParkenLijst.ItemsSource = _domainManager.GetParkenByFaciliteiten(gekozenFaciliteiten);
                }

            }
        }
        #endregion


    }
}
