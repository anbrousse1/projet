﻿using Metier;
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
    /// Logique d'interaction pour ModifierTicket.xaml
    /// </summary>
    public partial class ModifierTicket : UserControl
    {
        MainWindow parent;
        AbsRepas repas;
        AbsUsager client;
        double solde;
        public ModifierTicket(MainWindow m, AbsRepas r,AbsUsager c)
        {
            parent = m;
            repas = r;
            client = c;
            solde = client.Solde;
            //Charger liste plats dans Plats choisis ROC
            parent.self.chargePlatRepas(repas);
            InitializeComponent();
            mgrid.Children.Add(new Recapitulatif(parent, true,r.Prix,c));
            
        }

        private void annuler(object sender, RoutedEventArgs e)
        {
            parent.self.chargePlatRepas(repas);
            client.Solde = solde;
            parent.setUC(new UCListRepas(parent));
        }

        private void confirmer(object sender, RoutedEventArgs e)
        {
            //Changer la date a ajouter ...
            //probleme avec le solde
            parent.self.changeRepas(repas);
            parent.self.client.Solde = parent.self.solde;
            EcrireTicketFichier.modifTicket(client,parent.self.caissier, parent.self.platsChoisisROC, parent.self.prixAPayer, DateTime.Now);
            parent.self.supprimerAllPlatsChoisis();
            parent.setUC(new Caisse(parent));
        }
    }
}
