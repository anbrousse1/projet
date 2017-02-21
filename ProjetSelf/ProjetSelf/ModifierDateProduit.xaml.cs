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

        private void clickAnnuler(object sender, RoutedEventArgs e)
        {
            parent.setUC(new UCModifProd(parent));
        }

        private void clickValider(object sender, RoutedEventArgs e)
        {

            DateTime effet = (DateTime)dateEffet.SelectedDate;
            DateTime fin = (DateTime)dateFin.SelectedDate;
            String obser = obs.Text;
            //parent.self.
            Console.WriteLine(effet + " " + fin + " " + obser);
            MessageBox.Show("Modifier avec succès !!!");
            parent.setUC(new UCModifProd(parent));
        }
    }
}
