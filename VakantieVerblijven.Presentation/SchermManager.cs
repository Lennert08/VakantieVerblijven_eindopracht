using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VakantieVerblijven.Presentation
{
    static class SchermManager
    {
        //deze klas word gebruikt om de grote en positie van de windows juist te zetten en de oude window te sluiten
        public static void NavigateToNextWindow(Window TeSluitenWindow, Window TeOpenenWindow)
        {
            // Kopieer de positie en grootte alleen als het venster niet gemaximaliseerd is
            if (TeSluitenWindow.WindowState == WindowState.Maximized)
            {
                TeOpenenWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                TeOpenenWindow.WindowState = WindowState.Normal; // Reset naar normale staat
                TeOpenenWindow.Left = TeSluitenWindow.Left;
                TeOpenenWindow.Top = TeSluitenWindow.Top;
                TeOpenenWindow.Width = TeSluitenWindow.Width;
                TeOpenenWindow.Height = TeSluitenWindow.Height;
            }

            // Nieuw venster openen
            TeOpenenWindow.Show();

            // Oud venster verbergen
            TeSluitenWindow.Hide();
        }
    }
}
