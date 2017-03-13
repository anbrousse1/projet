using Metier;
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
    /// Logique d'interaction pour VisualisationPlat.xaml
    /// </summary>
    public partial class VisualisationPlat : UserControl
    {
        MainWindow parent;
        public VisualisationPlat(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            DataContext = parent.self;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionPlat(parent));
        }

        private void UCVisualiserPlat_Clicked(object sender, PlatCEventArgs e)
        {
            AbsPlat m = parent.self.FindPlat((sender as UCVisualiserPlat).NomPlat);
            if (e.Num == 0)
            {
                // appelle de supprimer menu
                parent.self.supprimerPlat(m);
                liste.Items.Refresh();
            }
            else
            {
                //Vue modifier menu 
                // parent.setUC(new ModifierDatePlatEtProduit(parent, m));
            }
        }
    }
}
