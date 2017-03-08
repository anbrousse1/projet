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
    /// Logique d'interaction pour GestionPlat.xaml
    /// </summary>
    public partial class GestionPlat : UserControl
    {
        MainWindow parent;
        public GestionPlat(MainWindow m)
        {
            InitializeComponent();
            parent = m;
        }

        private void ClickRetour(object sender, RoutedEventArgs e)
        {
            parent.setUC(new AccueilGerant(parent));
        }

        private void ajouterClick(object sender, RoutedEventArgs e)
        {
            parent.setUC(new AjouterPlat(parent));
        }

        private void visualiser(object sender, RoutedEventArgs e)
        {
            parent.setUC(new VisualisationPlat(parent));

        }
    }
}
