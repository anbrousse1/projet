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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vue;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour Caisse.xaml
    /// </summary>
    public partial class Caisse : UserControl
    {
        private MainWindow parent;

        public Caisse(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            IdUsager.Children.Add(new IdUsager());
            recap.Children.Add(new Recapitulatif(parent));
            if (parent.self.menuDuJour == null)
            {
                plat.IsEnabled = false;
                dessert.IsEnabled = false;
                entree.IsEnabled = false;

                MessageBox.Show("pas de menu pour aujourd'hui");
            }
        }

        private void ClickEntree(object sender, RoutedEventArgs e)
        {
            parent.setUC(new UCEntree(parent));
        }

        private void ClickPlat(object sender, RoutedEventArgs e)
        {
            parent.setUC(new UCPlat(parent));
        }

        private void ClickDessert(object sender, RoutedEventArgs e)
        {
            parent.setUC(new UCDessert(parent));
        }

        private void ClickBoisson(object sender, RoutedEventArgs e)
        {
            parent.setUC(new UCBoisson(parent));
        }

        private void ClickDeconnexion(object sender, RoutedEventArgs e)
        {
            //parent.self.deconnexion();
            parent.setUC(new Connexion(parent));
        }

        private void ClickPaiement(object sender, RoutedEventArgs e)
        {
            //parent.self.Paiement();
            parent.setUC(new Paiement(parent));

        }


    }


}
