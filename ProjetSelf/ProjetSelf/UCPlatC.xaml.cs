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
    /// Logique d'interaction pour UCPlatC.xaml
    /// </summary>
    public partial class UCPlatC : UserControl
    {
        public UCPlatC()
        {
            InitializeComponent();
        }


        public String Nom
        {
            get { return (String)GetValue(NomProperty); }
            set { SetValue(NomProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Nom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomProperty =
            DependencyProperty.Register("Nom", typeof(String), typeof(UCPlatC), new PropertyMetadata(0));


        public String Tarif
        {
            get { return (String)GetValue(TarifProperty); }
            set { SetValue(TarifProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tarif.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TarifProperty =
            DependencyProperty.Register("Tarif", typeof(String), typeof(UCPlatC), new PropertyMetadata(0));


        public int Nb
        {
            get { return (int)GetValue(NbProperty); }
            set { SetValue(NbProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Nb.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NbProperty =
            DependencyProperty.Register("Nb", typeof(int), typeof(UCPlatC), new PropertyMetadata(0));



        /// <summary>
        /// Méthode appelé lorqu'on clique sur un "-" dans la liste des plats choisis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButtonMoins(object sender, RoutedEventArgs e)
        {


        }

        /// <summary>
        /// Méthode appelé lorqu'on clique sur un "+" dans la liste des plats choisis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButtonPlus(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Méthode appelé lorqu'on clique sur un "X" dans la liste des plats choisis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButtonSupprimer(object sender, RoutedEventArgs e)
        {

        }

    }
}
