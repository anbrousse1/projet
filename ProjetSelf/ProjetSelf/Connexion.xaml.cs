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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class Connexion : UserControl
    {

        private MainWindow parent;
        /// <summary>
        /// constructeur du user Controle Connexion 
        /// </summary>
        /// <param name="m"></param>
        public Connexion(MainWindow m)
        {
            parent = m;
            InitializeComponent();
        }

        /// <summary>
        /// méthode appelé lorsqu'on clique sur le bouton connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickConnexion(object sender, RoutedEventArgs e)
        {

            if (parent.self.connexion(log.Text, mdp.Password))
            {
                
                int fonction = parent.self.DroitUtilisateur;
                if (fonction==001)
                {
                    parent.setUC(new Caisse(parent));
                }
                else if (fonction==002)
                {
                    parent.setUC(new AccueilGerant(parent));
                }
                else
                {
                    parent.setUC(new AccueilGerant(parent));
                }
            }else
            {
                MessageBox.Show("Identifiant érronés");
            }
        }


    }
}
