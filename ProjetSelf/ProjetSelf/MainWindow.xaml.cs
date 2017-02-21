using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Metier;
using Persistance;

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
                self = new Self(new StubDataManager());

            }catch(Exception e)
            {
                MessageBox.Show("Pas de menu programmé pour aujourd'hui");
            }
            
            mGridCentre.Children.Add(new Connexion(this));
        }

        internal void quitter_Click(object sender, RoutedEventArgs e)
        {
            new ValidationQuitter(this).Show();
        }

        internal void setUC(UserControl uc)
        {
            this.mGridCentre.Children.Clear();
            this.mGridCentre.Children.Add(uc);
        }


    }
}
