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
        string child = "";

        public MainWindow()
        {

            InitializeComponent();
            image.Source = new BitmapImage(new Uri("Images/fourchette.jpg", UriKind.Relative));
            try
            {
                self = new Self(new StubDataManager());

            }
            catch
            {
                MessageBox.Show("Pas de menu programmé pour aujourd'hui");
            }

            setUC(new Connexion(this));
        }

        internal void quitter_Click(object sender, RoutedEventArgs e)
        {
            new ValidationQuitter(this).Show();
        }

        internal void setUC(UserControl uc)
        {
            child = uc.ToString();
            this.mGridCentre.Children.Clear();
            this.mGridCentre.Children.Add(uc);
        }

        private void Aide(object sender, RoutedEventArgs e)
        {
            new Aide(child).Show();
        }
    }
}
