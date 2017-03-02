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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AbsProduit prod = ((sender as ListBox).SelectedItem as AbsProduit);
            parent.setUC(new ModifierDatePlatEtProduit(parent, prod));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionProduit(parent));
        }

        private void UCModifProd_Clicked(object sender, ModifProdEventArgs e)
        {
            AbsProduit p = parent.self.findProduitByName((sender as ModifProdUC).NomProd);
            parent.self.supprimerProduit(p);
        }
    }
}
