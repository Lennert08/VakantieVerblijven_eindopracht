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
    /// Interaction logic for KlantSelectieScherm.xaml
    /// </summary>
    public partial class KlantSelectieScherm : Window
    {
        public event EventHandler<string> NavigationButtonClicked;
        public event EventHandler<string> ZoekButtonClicked;
        public event EventHandler<KlantVO> KlantGekozen;
        public KlantSelectieScherm()
        {
            InitializeComponent();
        }
        private void NavigateToNextWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                NavigationButtonClicked?.Invoke(this, button.Tag as string);
            }
        }

        private void zoekButton_Click(object sender, RoutedEventArgs e)
        {
            ZoekButtonClicked?.Invoke(this, klantTextBox.Text);
        }

        private void klantListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (klantListBox.SelectedItem == null)  //niemand geselecteerd
            {
                volgendeButton.IsEnabled = false;
            }
            else // Iemaand is geselcteerd
            {
                volgendeButton.IsEnabled = true;
            }
        }

        private void VolgendeButtonClicked(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                NavigationButtonClicked?.Invoke(this, button.Tag as string);
                KlantGekozen?.Invoke(this, klantListBox.SelectedItem as KlantVO);
            }
        }
    }
}
