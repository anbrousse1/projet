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
    /// Logique d'interaction pour Paiement.xaml
    /// </summary>
    public partial class Paiement : UserControl
    {
        private MainWindow parent;
        public Paiement(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            mgrid.Children.Add(new Recapitulatif(parent,false));
        }

        public void ClickContinuer(object sender, RoutedEventArgs e)
        {
            parent.self.finPassage();
            parent.setUC(new Caisse(parent));
        }

        public void clickTicket(object sender, RoutedEventArgs e)
        {
            //Enregistrer le ticket. 
            EcrireTicketFichier.ecrireTicket(parent.self.client,parent.self.caissier, parent.self.platsChoisisROC,parent.self.prixAPayer,DateTime.Now);
            parent.self.finPassage();            
            parent.setUC(new Caisse(parent));
        }
    }
}
