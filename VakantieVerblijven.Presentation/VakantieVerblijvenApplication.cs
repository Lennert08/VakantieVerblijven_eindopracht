using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VakantieVerblijven.Domain;
using VakantieVerblijven.Presentation.Windows;

namespace VakantieVerblijven.Presentation
{
    public class VakantieVerblijvenApplication
    {
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
            _reservatiesWindow.Show();
        }

     

        #region Window1


        #endregion
    }
}
