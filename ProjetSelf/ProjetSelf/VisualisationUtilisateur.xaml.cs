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
    /// Logique d'interaction pour VisualisationUtilisateur.xaml
    /// </summary>
    public partial class VisualisationUtilisateur : UserControl
    {
        MainWindow parent;
        public VisualisationUtilisateur(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            DataContext = parent.self;
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionUtilisateur(parent));
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //vue modifier menu
        }


        /*private void UCVisualiserUtilisateur_Clicked(object sender, PlatCEventArgs e)
        {
            //AbsPlat m = parent.self.FindPlat((sender as UCVisualiserPlat).NomPlat);

            //Vue modifier menu 
            // parent.setUC(new ModifierDatePlatEtProduit(parent, m));

        }*/




    }
}
