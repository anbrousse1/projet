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
    /// Logique d'interaction pour ModifierDatePlatEtProduit.xaml
    /// </summary>
    public partial class ModifierDatePlatEtProduit : UserControl
    {
        MainWindow parent;
        AbsProduit prod;
        public ModifierDatePlatEtProduit(MainWindow m, AbsProduit p)
        {
            parent = m;
            prod = p;
            InitializeComponent();
        }

        private void clickRetour(object sender, RoutedEventArgs e)
        {
            parent.setUC(new AccueilGerant(parent));
        }
    }
}
