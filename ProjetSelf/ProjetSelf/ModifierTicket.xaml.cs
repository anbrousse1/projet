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
    /// Logique d'interaction pour ModifierTicket.xaml
    /// </summary>
    public partial class ModifierTicket : UserControl
    {
        private MainWindow parent;
        public ModifierTicket(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            mgrid.Children.Add(new Recapitulatif(parent));

        }

        public void clickModifier(object sender, RoutedEventArgs e)
        {
            
        }

        public void clickAnnuler(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
