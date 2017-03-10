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
    /// Logique d'interaction pour UCVisualiserUtilisateur.xaml
    /// </summary>
    public partial class UCVisualiserUtilisateur : UserControl
    {
        public UCVisualiserUtilisateur()
        {
            InitializeComponent();
        }



        public string TitreUtilisateur
        {
            get { return (string)GetValue(TitreUtilisateurProperty); }
            set { SetValue(TitreUtilisateurProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitreUtilisateur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitreUtilisateurProperty =
            DependencyProperty.Register("TitreUtilisateur", typeof(string), typeof(UCVisualiserUtilisateur), new PropertyMetadata("aucun"));



        public string NomUtilisateur
        {
            get { return (string)GetValue(NomUtilisateurProperty); }
            set { SetValue(NomUtilisateurProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NomUtilisateur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomUtilisateurProperty =
            DependencyProperty.Register("NomUtilisateur", typeof(string), typeof(UCVisualiserUtilisateur), new PropertyMetadata("rien"));



        public string PrenomUtilisateur
        {
            get { return (string)GetValue(PrenomUtilisateurProperty); }
            set { SetValue(PrenomUtilisateurProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PrenomUtilisateur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PrenomUtilisateurProperty =
            DependencyProperty.Register("PrenomUtilisateur", typeof(string), typeof(UCVisualiserUtilisateur), new PropertyMetadata("rien"));



        public string ServiceUtilisateur
        {
            get { return (string)GetValue(ServiceUtilisateurProperty); }
            set { SetValue(ServiceUtilisateurProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ServiceUtilisateur.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ServiceUtilisateurProperty =
            DependencyProperty.Register("ServiceUtilisateur", typeof(string), typeof(UCVisualiserUtilisateur), new PropertyMetadata("aucun"));

        /*

        public event EventHandler<PlatCEventArgs> c;

        void OnClicked(PlatCEventArgs args)
        {
            c?.Invoke(this, args);       }


       

        private void modifier(object sender, RoutedEventArgs e)
        {
            OnClicked(new PlatCEventArgs(1));
        }*/


    }
}
