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
    /// Logique d'interaction pour GestionMenu.xaml
    /// </summary>
    public partial class GestionMenu : UserControl
    {
        private MainWindow parent;

        public GestionMenu(MainWindow m)
        {
            InitializeComponent();
            parent = m;
        }

        private void ClickRetour(object sender, RoutedEventArgs e)
        {
            parent.setUC(new AccueilGerant(parent));
        }
    }
}
