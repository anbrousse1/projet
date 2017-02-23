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
    /// Logique d'interaction pour SimpleListeProduit.xaml
    /// </summary>
    public partial class SimpleListeProduit : UserControl
    {
        private AjouterPlat parent;
        public SimpleListeProduit(AjouterPlat p)
        {
            parent = p;
            DataContext = parent;
            InitializeComponent();
        }

        private void ListView_Selected(object sender, RoutedEventArgs e)
        {
            Produit p= (Produit)((ListView)sender).SelectedItem;
            parent.supprimerPrduit(p);
        }
    }
}
