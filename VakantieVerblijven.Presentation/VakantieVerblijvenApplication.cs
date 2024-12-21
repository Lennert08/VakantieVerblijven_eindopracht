using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VakantieVerblijven.Domain;
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

        public VakantieVerblijvenApplication(DomainManager domainManager)
        {
            _domainManager = domainManager;
            _reservatiesWindow = new ReservatiesWindow(_domainManager.GetReservatiesByMonth(DateTime.Today)); //haalt alle reseravties van de huidige maand op 
            _homeWindow = new HomeWindow();
            _huizenOverzichtWindow = new HuizenOverzichtWindow(_domainManager.GetAllHuizen());
            _teVerplaatsenResWindow = new TeVerplaatsenResWindow(_domainManager.GetProbleemReservaties());

            //linken van Window Navigators
            _homeWindow.NavigationButtonClicked += NavigateToNextWindow;
            _huizenOverzichtWindow.NavigationButtonClicked += NavigateToNextWindow;
            _reservatiesWindow.NavigationButtonClicked += NavigateToNextWindow;
            _teVerplaatsenResWindow.NavigationButtonClicked += NavigateToNextWindow;

            //linken van alle andere events
            _huizenOverzichtWindow.HuisSelected += UpdateOnderhoudButton;

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

    }
}
