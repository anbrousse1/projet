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

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary>
    public partial class AccueilGerant : UserControl
    {
        private MainWindow parent;

        public AccueilGerant(MainWindow m)
        {
            InitializeComponent();
            parent = m;
        }

        private void ClickGestionPlat(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionPlat(parent));
        }

        private void ClickGestionMenu(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionMenu(parent));
        }

        private void ClickCaisse(object sender, RoutedEventArgs e)
        {
            parent.setUC(new Caisse(parent));
        }

        private void ClickGestionProduit(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionProduit(parent));
        }


        private void ClickGestionUtilisateur(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionUtilisateur(parent));
        }

        private void ClickStats(object sender, RoutedEventArgs e)
        {
            //parent.setUC(new Stats(parent));
        }
    }
}
