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
    /// Logique d'interaction pour AjouterPlat.xaml
    /// </summary>
    public partial class AjouterPlat : UserControl
    {
        private MainWindow parent;
        public AjouterPlat(MainWindow m)
        {
            parent = m;
            InitializeComponent();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

