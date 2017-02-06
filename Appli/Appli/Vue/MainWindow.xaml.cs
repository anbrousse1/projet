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
using Appli.Vue;
using Appli.Metier;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Self self;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                this.self = new Self();
            }catch(Exception e)
            {
                MessageBox.Show("Aucun menu trouvé pour la date du jour!!!");
            }
            mGridCentre.Children.Add(new Caisse(this));
            //mGridCentre.Children.Add(new Connexion(this, self));
            //Console.WriteLine(new DateTime(2017, 02, 04));
        }

        internal void quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        internal void setUC(UserControl uc)
        {
            mGridCentre.Children.Clear();
            mGridCentre.Children.Add(uc);
        }

        
    }
}
