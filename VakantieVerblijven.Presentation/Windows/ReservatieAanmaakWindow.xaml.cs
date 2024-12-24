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
using VakantieVerblijven.Domain.ValueObject;
using VakantieVerblijven.Presentation.CustomEventArgs;

namespace VakantieVerblijven.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for ReservatieAanmaakWindow.xaml
    /// </summary>
    public partial class ReservatieAanmaakWindow : Window
    {
        public event EventHandler<string> NavigationButtonClicked;
        public event EventHandler<ZoekKnopEventArgs> ZoekKnopSelected;
        public event EventHandler<HuisVO> huisGekozen;
        public ReservatieAanmaakWindow(List<string> maxPersonenOpties)
        {
            InitializeComponent();
            PersonenComboBox.ItemsSource = maxPersonenOpties;
            PersonenComboBox.SelectedItem = PersonenComboBox.Items[0]; // Selecteert "Optie 1 automatic"
        }

        private void NavigateToNextWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                NavigationButtonClicked?.Invoke(this, button.Tag as string);
            }
        }

        private void ZoekKnopClicked(object sender, RoutedEventArgs e)
        {
            if (!BeginDatumBox.SelectedDate.HasValue || !EindDatumBox.SelectedDate.HasValue)
            {
                MessageBox.Show("Zorg ervoor dat zowel de begin- als einddatum zijn geselecteerd.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return; //breekt de method af
            }
            int aantalPersonen = PersonenComboBox.SelectedIndex + 1;
            DateTime startDatum = BeginDatumBox.SelectedDate.Value;
            DateTime eindDatum = EindDatumBox.SelectedDate.Value;
            ZoekKnopSelected?.Invoke(this, new ZoekKnopEventArgs(aantalPersonen, startDatum, eindDatum));
        }

        private void HuisLijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HuisLijst.SelectedItem == null)  //Geen park geselecteerd
            {
                volgendeKnop.IsEnabled = false;
            }
            else // een park geselcteerd
            {
                volgendeKnop.IsEnabled = true;
            }
        }

        private void volgendeKnopClicked(object sender, RoutedEventArgs e)
        {
            huisGekozen?.Invoke(this, HuisLijst.SelectedItem as HuisVO);
        }
    }
}
