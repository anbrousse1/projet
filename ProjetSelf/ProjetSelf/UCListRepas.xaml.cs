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
    /// Logique d'interaction pour UCListRepas.xaml
    /// </summary>
    public partial class UCListRepas : UserControl
    {
        private MainWindow parent;
        public UCListRepas(MainWindow m)
        {
            parent = m;
            parent.self.chargeListRepas();
            InitializeComponent();
            repas.ItemsSource = parent.self.client.histoRepasROC;
            DataContext = parent.self.client;
            
        }


        public void clickRetour(object sender, RoutedEventArgs e)
        {
            parent.setUC(new Caisse(parent));
        }

        private void repas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AbsRepas r = (AbsRepas)((ListView)sender).SelectedItem;
            parent.setUC(new ModifierTicket( parent, r));
        }
    }
}
