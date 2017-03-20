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
    /// Logique d'interaction pour UCModifProd.xaml
    /// </summary>
    public partial class UCModifProd : UserControl
    {
        MainWindow parent;
        public UCModifProd(MainWindow m)
        {
            InitializeComponent();
            parent = m;
            DataContext=parent.self;
        }

    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionProduit(parent));
        }

        private void UCModifProd_Clicked(object sender, PlatCEventArgs e)
        {
            AbsProduit p = parent.self.findProduitByName((sender as ModifProdUC).NomProd);
            if(e.Num == 0)
            {
                if (parent.self.produitSupprimable(p))
                {
                    parent.self.supprimerProduit(p);
                    liste.Items.Refresh();
                }else
                {
                    MessageBox.Show("Ce produit est utilisé dans un plat il est donc impossible de le supprimer");
                }

            }
            else
            {
                parent.setUC(new ModifierDatePlatEtProduit(parent, p));
            }
        }
    }
}
