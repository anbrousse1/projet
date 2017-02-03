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
    /// Logique d'interaction pour Caisse.xaml
    /// </summary>
    public partial class Caisse : UserControl
    {
        private MainWindow parent;

        public Caisse(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            IdUsager.Children.Add(new IdUsager());
            recap.Children.Add(new Recapitulatif());
        }

        public void ClickEntree(object sender, RoutedEventArgs e)
        {
            this.parent.mGridCentre.Children.Add(new UCEntree(parent));
        }

    }

    
}
