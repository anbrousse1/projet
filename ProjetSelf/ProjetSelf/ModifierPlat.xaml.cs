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
    /// Logique d'interaction pour ModifierPlat.xaml
    /// </summary>
    public partial class ModifierPlat : UserControl
    {
        private List<AbsProduit> produits = new List<AbsProduit>();
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsProduit> prodPlatROC
        {
            get;
            private set;
        }
        private MainWindow parent;
        private AbsPlat plat;
        public ModifierPlat(MainWindow m, AbsPlat p)
        {
            parent = m;
            plat = p;
            produits = p.getProduits();
            DataContext = parent.self;
            prodPlatROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsProduit>(produits);
            InitializeComponent();
            listProd.DataContext = this;
            tarif.Text = p.Tarif.ToString();
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (cbProd.SelectedItem == null) { MessageBox.Show("Vous devez sélectionner un produit"); return; }
            else
            {
                produits.Add((AbsProduit)cbProd.SelectedItem);
                listProd.Items.Refresh();
            }
        }


        private void valider_Click(object sender, RoutedEventArgs e)
        {
            double i = 1;
            if (!double.TryParse(tarif.Text, out i))
            {
                MessageBox.Show("Valeur saisie dans tarif incorrecte");
                return;
            }
            double t = double.Parse(tarif.Text);
            if (t != plat.Tarif)
            {
                parent.self.modifierTarifPlat(plat,t);
            }
            parent.self.modifierProduitsPlat(plat, produits);
            parent.setUC(new VisualisationPlat(parent));
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new VisualisationPlat(parent));
        }

        private void listProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AbsProduit p =(AbsProduit)(sender as ListView).SelectedItem;
            produits.Remove(p);
            listProd.Items.Refresh();
        }
    }
}
