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

            
            System.Windows.Controls.ContentPresenter s = (System.Windows.Controls.ContentPresenter)b.TemplatedParent;
            ListViewItem l=(ListViewItem)s.TemplatedParent;
            ListView lv=(ListView)l.Parent;
            
            //Console.WriteLine(((Grid)b.TemplatedParent).TemplatedParent);
            //Grid g=(Grid)b.TemplatedParent;
            //Recapitulatif r = (Recapitulatif)g.TemplatedParent;

        }


        private void ClickButtonPlus(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            AbsPlat p = (AbsPlat)b.DataContext;
            System.Windows.Controls.ContentPresenter s = (System.Windows.Controls.ContentPresenter)b.TemplatedParent;
            ListViewItem l = (ListViewItem)s.TemplatedParent;
            ListView lv = (ListView)l.Parent;
        }
    }
}
