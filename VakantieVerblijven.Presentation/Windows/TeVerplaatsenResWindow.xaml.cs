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
    /// Interaction logic for TeVerplaatsenResWindow.xaml
    /// </summary>
    public partial class TeVerplaatsenResWindow : Window
    {
        public event EventHandler<string> NavigationButtonClicked;
        public TeVerplaatsenResWindow(List<ReservatieVO> probleemReservaties)
        {
            InitializeComponent();
            ReservatieLijst.ItemsSource = probleemReservaties;
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
