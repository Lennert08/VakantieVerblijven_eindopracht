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

namespace VakantieVerblijven.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for ReservatieAanmaakOverzicht.xaml
    /// </summary>
    public partial class ReservatieAanmaakOverzicht : Window
    {
        public event EventHandler<string> NavigationButtonClicked;
        public event EventHandler ReservatieVastLegButtonClicked;
        public ReservatieAanmaakOverzicht(KlantVO gekozenKlant, ParkVO gekozenPark, int aantalPersonen, DateTime startDatum, DateTime eindDatum, HuisVO gekozenHuis)
        {
            InitializeComponent();
            klantInfoText.Text = gekozenKlant.ToString();
            parkInfoText.Text = gekozenPark.ToString();
            huisInfoText.Text = gekozenHuis.VolledigAdres;
            persoonInfoText.Text = aantalPersonen.ToString();
            periodeInfoText.Text = $"Van {startDatum:dd-MM-yyyy} tot {eindDatum:dd-MM-yyyy}";
        }
        private void NavigateToNextWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                NavigationButtonClicked?.Invoke(this, button.Tag as string);
            }
        }

        private void ReservatieVastleggen(object sender, RoutedEventArgs e)
        {
            ReservatieVastLegButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
