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
using Metier;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour UCPlatC.xaml
    /// </summary>
    public partial class UCPlatC : UserControl
    {
        public UCPlatC()
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
            DependencyProperty.Register("NomPlat", typeof(string), typeof(UCPlatC), new PropertyMetadata("pas de plats"));



        public double TarifPlat
        {
            get { return (double)GetValue(TarifPlatProperty); }
            set { SetValue(TarifPlatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TarifPlat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TarifPlatProperty =
            DependencyProperty.Register("TarifPlat", typeof(double), typeof(UCPlatC), new PropertyMetadata(0.0));
            


        public int QtePlat
        {
            get { return (int)GetValue(QtePlatProperty); }
            set { SetValue(QtePlatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for QtePlat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty QtePlatProperty =
            DependencyProperty.Register("QtePlat", typeof(int), typeof(UCPlatC), new PropertyMetadata(1));

        public event EventHandler<PlatCEventArgs> Clicked;

        void OnClicked(PlatCEventArgs args)
        {
            Clicked?.Invoke(this, args);
        }

        /// <summary>
        /// Méthode appelé lorqu'on clique sur un "-" dans la liste des plats choisis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButtonMoins(object sender, RoutedEventArgs e)
        {
            OnClicked(new PlatCEventArgs(1));
        }

        /// <summary>
        /// Méthode appelé lorqu'on clique sur un "+" dans la liste des plats choisis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButtonPlus(object sender, RoutedEventArgs e)
        {
            OnClicked(new PlatCEventArgs(0));
        }

        /// <summary>
        /// Méthode appelé lorqu'on clique sur un "X" dans la liste des plats choisis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButtonSupprimer(object sender, RoutedEventArgs e)
        {
            OnClicked(new PlatCEventArgs(2));
        }

    }
}
