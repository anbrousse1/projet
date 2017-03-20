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
            AbsPlat p = parent.self.FindPlat((sender as UCVisualiserPlat).NomPlat);
            if (e.Num == 0)
            {
                if (parent.self.platSupprimable(p))
                {
                    parent.self.supprimerPlat(p);
                    liste.Items.Refresh();
                }else
                {
                    MessageBox.Show("Ce plat est utlisé dans un ou des menus on ne peut donc pas le supprimer");
                }
                
            }
            else
            {
                parent.setUC(new ModifierPlat(parent, p));
            }
        }
    }
}
