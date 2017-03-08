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
    /// Logique d'interaction pour UCVisualiserMenu.xaml
    /// </summary>
    public partial class UCVisualiserMenu : UserControl
    {
        public UCVisualiserMenu()
        {
            InitializeComponent();
        }





        public string NomMenu
        {
            get { return (string)GetValue(NomMenuProperty); }
            set { SetValue(NomMenuProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NomMenu.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomMenuProperty =
            DependencyProperty.Register("NomMenu", typeof(string), typeof(UCVisualiserMenu), new PropertyMetadata("rien"));




        public DateTime DateEffet
        {
            get { return (DateTime)GetValue(DateEffetProperty); }
            set { SetValue(DateEffetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DateEffet.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateEffetProperty =
            DependencyProperty.Register("DateEffet", typeof(DateTime), typeof(UCVisualiserMenu), new PropertyMetadata(DateTime.Today));



        public DateTime DateFin
        {
            get { return (DateTime)GetValue(DateFinProperty); }
            set { SetValue(DateFinProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DateFin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateFinProperty =
            DependencyProperty.Register("DateFin", typeof(DateTime), typeof(UCVisualiserMenu), new PropertyMetadata(DateTime.Today));


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
