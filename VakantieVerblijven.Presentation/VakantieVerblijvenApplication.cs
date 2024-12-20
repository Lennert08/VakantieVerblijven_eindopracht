using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VakantieVerblijven.Domain;
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
            _reservatiesWindow = new ReservatiesWindow();
            _homeWindow = new HomeWindow();
            _huizenOverzichtWindow = new HuizenOverzichtWindow();
            _teVerplaatsenResWindow = new TeVerplaatsenResWindow();

            //linken van Window Navigators
            _homeWindow.NavigationButtonClicked += NavigateToNextWindow;
            _huizenOverzichtWindow.NavigationButtonClicked += NavigateToNextWindow;
            _reservatiesWindow.NavigationButtonClicked += NavigateToNextWindow;
            _teVerplaatsenResWindow.NavigationButtonClicked += NavigateToNextWindow;

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


    }
}
