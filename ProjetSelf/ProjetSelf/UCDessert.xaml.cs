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
    /// Logique d'interaction pour UCDessert.xaml
    /// </summary>
    public partial class UCDessert : UserControl
    {
        private MainWindow parent;

        public UCDessert(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            this.recap.Children.Add(new Recapitulatif());
        }

        private void ClickValider(object sender, RoutedEventArgs e)
        {
            parent.setUC(new Caisse(parent));
        }

        private void ClickAnnuler(object sender, RoutedEventArgs e)
        {
            parent.setUC(new Caisse(parent));
        }


        private void ClickButton1(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(button1.Content.ToString());
        }

        private void ClickButton2(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(button2.Content.ToString());
        }

        private void ClickButton3(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(button3.Content.ToString());
        }

        private void ClickButton4(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(button4.Content.ToString());
        }

        private void ClickButton5(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(button5.Content.ToString());
        }

        private void ClickButton6(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(button6.Content.ToString());
        }
    }
}
