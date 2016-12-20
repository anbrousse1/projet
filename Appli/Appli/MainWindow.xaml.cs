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

namespace Appli
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mGridCentre.Children.Add(new Paiement());
        }

        private void quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void quitter_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
