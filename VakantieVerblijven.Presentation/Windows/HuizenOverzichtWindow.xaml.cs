﻿using System;
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

namespace VakantieVerblijven.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for HuizenOverzichtWindow.xaml
    /// </summary>
    public partial class HuizenOverzichtWindow : Window
    {
        public event EventHandler<string> NavigationButtonClicked;
        public event EventHandler<HuisVO> HuisSelected;
        public event EventHandler<HuisVO> OnderhoudButtonClicked;
        public HuizenOverzichtWindow(List<HuisVO> huizen)
        {
            InitializeComponent();
            HuisDataGrid.ItemsSource = huizen;
        }

        private void NavigateToNextWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                NavigationButtonClicked?.Invoke(this, button.Tag as string);
            }
        }

        private void HuisDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                if (dataGrid.SelectedItem is HuisVO huis)
                {
                    HuisSelected?.Invoke(this, huis);
                }
            }
        }

        private void OnderhoudButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HuisDataGrid.SelectedItem is null)
                {
                    throw new Exception("U moet eerst een huis selecteren.");
                } else
                {
                    OnderhoudButtonClicked?.Invoke(this, HuisDataGrid.SelectedItem as HuisVO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Foutmelding",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }
    }
}
