using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VakantieVerblijven.Domain.Model;

namespace VakantieVerblijven.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for ParkSelectieScherm.xaml
    /// </summary>
    public partial class ParkSelectieScherm : Window
    {
        public event EventHandler<string> NavigationButtonClicked;
        internal bool heeftGeenVoorkeur = true; // hier hou ik de status bij over een voorkeur is of niet
        internal Dictionary<Faciliteit, bool> _faciliteitenStatus; // hier bijhouden wat gecheckt is en wat niet
        internal List<Park> _standaardParken;
        public event EventHandler CheckboxChecked;
        public ParkSelectieScherm(List<Faciliteit> faciliteiten, List<Park> standaardParken)
        {
            InitializeComponent();
            _standaardParken = standaardParken;
            ParkenLijst.ItemsSource = _standaardParken;
            FaciliteitLijst.ItemsSource = faciliteiten;
            _faciliteitenStatus = faciliteiten.ToDictionary(faciliteit => faciliteit, _ => false);
        }

        private void NavigateToNextWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                NavigationButtonClicked?.Invoke(this, button.Tag as string);
            }
        }

        private void VoorkeurCheckboxVeranderd(object sender, RoutedEventArgs e)
        {
            if (FaciliteitLijst != null)
            {
                // Draai de huidige staat van _isVoorkeurChecked om
                heeftGeenVoorkeur = !heeftGeenVoorkeur;

                // Stel de IsEnabled-eigenschap in op het omgekeerde van _isVoorkeurChecked
                FaciliteitLijst.IsEnabled = !heeftGeenVoorkeur;

                // Trigger het CheckboxChecked-event
                CheckboxChecked?.Invoke(this, EventArgs.Empty);
            }
        }

        private void UpdateFaciliteitStatusLijst(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.DataContext is Faciliteit faciliteit)
            {
                //hier veranderen we de bool status van false naar true of true naar false
                _faciliteitenStatus[faciliteit] = !_faciliteitenStatus[faciliteit];

                CheckboxChecked?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
