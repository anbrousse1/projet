using Metier;
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
    /// Logique d'interaction pour UCVisualiserPlat.xaml
    /// </summary>
    public partial class UCVisualiserPlat : UserControl
    {
        public UCVisualiserPlat()
        {
            InitializeComponent();
        }



        public string NomPlat
        {
            get { return (string)GetValue(NomPlatProperty); }
            set { SetValue(NomPlatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NomPlat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomPlatProperty =
            DependencyProperty.Register("NomPlat", typeof(string), typeof(UCVisualiserPlat), new PropertyMetadata("rien"));



        public double Tarif
        {
            get { return (double)GetValue(TarifProperty); }
            set { SetValue(TarifProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tarif.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TarifProperty =
            DependencyProperty.Register("Tarif", typeof(double), typeof(UCVisualiserPlat), new PropertyMetadata(0.0));



        public DateTime DateEffet
        {
            get { return (DateTime)GetValue(DateEffetProperty); }
            set { SetValue(DateEffetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DateEffet.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateEffetProperty =
            DependencyProperty.Register("DateEffet", typeof(DateTime), typeof(UCVisualiserPlat), new PropertyMetadata(DateTime.Today));



        public DateTime DateFin
        {
            get { return (DateTime)GetValue(DateFinProperty); }
            set { SetValue(DateFinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DateFin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateFinProperty =
            DependencyProperty.Register("DateFin", typeof(DateTime), typeof(UCVisualiserPlat), new PropertyMetadata(DateTime.Today));

        public event EventHandler<PlatCEventArgs> c;

        void OnClicked(PlatCEventArgs args)
        {
            c?.Invoke(this, args);
        }


        private void supprimer(object sender, RoutedEventArgs e)
        {
            OnClicked(new PlatCEventArgs(0));
        }

        private void modifier(object sender, RoutedEventArgs e)
        {
            OnClicked(new PlatCEventArgs(1));
        }
    }
}
