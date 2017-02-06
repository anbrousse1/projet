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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class Connexion : UserControl
    {

        private MainWindow parent;
        private Self self;

        public Connexion(MainWindow m, Self s)
        {
            parent = m;
            self = s;
            InitializeComponent();
        }

        private void quitter_Click(object sender, RoutedEventArgs e)
        {
            parent.Close();
        }
    }
}
