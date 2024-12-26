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
using VakantieVerblijven.Domain.ValueObject;
using VakantieVerblijven.Presentation.CustomEventArgs;

namespace VakantieVerblijven.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for ReservatiesWindow.xaml
    /// </summary>
    public partial class ReservatiesWindow : Window
    {
        public event EventHandler<string> NavigationButtonClicked;
        public event EventHandler<ReservatieZoekKnopEventArgs> ZoekButtonClicked;
        public ReservatiesWindow(List<ReservatieVO> reservatieList, List<ParkVO> parkLijst)
        {
            InitializeComponent();
            Stack<ParkVO> parkLijstStack = new Stack<ParkVO>(parkLijst);
            parkLijstStack.Push(new ParkVO(0, "Alle parken", "Alle locaties")); // voor de optie "Alle parken"
            ReservatieLijst.ItemsSource = reservatieList;
            parkComboBox.ItemsSource = parkLijstStack;
        }
        private void NavigateToNextWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                NavigationButtonClicked?.Invoke(this, button.Tag as string);
            }
        }

        private void ZoekButtonClick(object sender, RoutedEventArgs e)
        {
            int selectedParkId = (parkComboBox.SelectedItem as ParkVO).Id;
            DateTime? begindatum = (DateTime?)beginDatumBox.SelectedDate;
            DateTime? einddatum = (DateTime?)EinDatumBox.SelectedDate;
            string klantZoekTerm = KlantZoekBox.Text;
            ZoekButtonClicked?.Invoke(this, new ReservatieZoekKnopEventArgs(selectedParkId,begindatum,einddatum,klantZoekTerm));
        }
    }
}
