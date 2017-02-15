using Metier;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ClickButtonMoins(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            AbsPlat p= (AbsPlat)b.DataContext;
        }


        private void ClickButtonPlus(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            AbsPlat p = (AbsPlat)b.DataContext;
        }
    }
}
