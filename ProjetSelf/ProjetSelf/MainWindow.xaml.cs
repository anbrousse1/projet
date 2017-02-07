using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Metier;

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
           image.Source = new BitmapImage(new Uri("Images/fourchette.jpg", UriKind.Relative));

            try
            {
               // this.self = new Self();
            }
            catch (Exception e)
            {
                MessageBox.Show("Aucun menu trouvé pour la date du jour!!!");
            }
            mGridCentre.Children.Add(new ModifierDatePlatEtProduit());
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
