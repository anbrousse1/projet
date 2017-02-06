using Appli.Metier;
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
using Vue;

namespace Appli.Vue
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class Connexion : UserControl
    {

        private MainWindow parent;

        public Connexion(MainWindow m)
        {
            parent = m;
            InitializeComponent();
        }

        private void quitter_Click(object sender, RoutedEventArgs e)
        {
            parent.Close();
        }

        private void ClickConnexion(object sender, RoutedEventArgs e)
        {
            parent.self.connexion(this.log.Text, this.mdp.Text);
            String fonction = parent.self.droitUtilisateur;
            if (fonction != null)
            {
                if (fonction.Equals("Caissier"))
                {
                    parent.setUC(new Caisse(parent));
                }else if (fonction.Equals("Gerant"))
                {
                    parent.setUC(new AccueilGerant(parent));
                }else
                {
                    parent.setUC(new Caisse(parent));
                }
            }
        }


    }
}
