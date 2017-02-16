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
        /// <summary>
        /// Méthode appelé lorqu'on clique sur un "-" dans la liste des plats choisis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButtonMoins(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            KeyValuePair<AbsPlat,int> kvp = (KeyValuePair<AbsPlat, int>)b.DataContext;
            AbsPlat p = kvp.Key;
            System.Windows.Controls.ContentPresenter s = (System.Windows.Controls.ContentPresenter)b.TemplatedParent;
            ListViewItem l=(ListViewItem)s.TemplatedParent;
            ListView lv=(ListView)l.Parent;
            
            //Console.WriteLine(((Grid)b.TemplatedParent).TemplatedParent);
            //Grid g=(Grid)b.TemplatedParent;
            //Recapitulatif r = (Recapitulatif)g.TemplatedParent;

        }

        /// <summary>
        /// Méthode appelé lorqu'on clique sur un "+" dans la liste des plats choisis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButtonPlus(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            KeyValuePair<AbsPlat, int> kvp = (KeyValuePair<AbsPlat, int>)b.DataContext;
            AbsPlat p = kvp.Key;
            System.Windows.Controls.ContentPresenter s = (System.Windows.Controls.ContentPresenter)b.TemplatedParent;
            ListViewItem l = (ListViewItem)s.TemplatedParent;
            ListView lv = (ListView)l.Parent;
        }

        /// <summary>
        /// Méthode appelé lorqu'on clique sur un "X" dans la liste des plats choisis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButtonSupprimer(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            KeyValuePair<AbsPlat, int> kvp = (KeyValuePair<AbsPlat, int>)b.DataContext;
            AbsPlat p = kvp.Key;
            System.Windows.Controls.ContentPresenter s = (System.Windows.Controls.ContentPresenter)b.TemplatedParent;
            ListViewItem l = (ListViewItem)s.TemplatedParent;
            ListView lv = (ListView)l.Parent;
        }
    }
}
