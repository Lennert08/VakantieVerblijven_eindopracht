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

namespace VakantieVerblijven.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for ReservatieAanmaakWindow.xaml
    /// </summary>
    public partial class ReservatieAanmaakWindow : Window
    {
        public event EventHandler<string> NavigationButtonClicked;
        public ReservatieAanmaakWindow()
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
    }
}
