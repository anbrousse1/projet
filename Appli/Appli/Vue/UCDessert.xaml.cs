using Appli.Metier;
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
using Vue;

namespace Appli.Vue
{
    /// <summary>
    /// Logique d'interaction pour UCDessert.xaml
    /// </summary>
    public partial class UCDessert : UserControl
    {
        private MainWindow parent;

        public UCDessert(MainWindow m)
        {
            parent = m;
            InitializeComponent();
        }

        private void ClickValider(object sender, RoutedEventArgs e)
        {
            parent.setUC(new Caisse(parent));
        }

        private void ClickAnnuler(object sender, RoutedEventArgs e)
        {
            parent.setUC(new Caisse(parent));
        }
    }
}
