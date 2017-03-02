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
    /// Logique d'interaction pour Recapitulatif.xaml
    /// </summary>
    public partial class Recapitulatif : UserControl
    {
        MainWindow parent;
        Boolean caisse;
        public Recapitulatif(MainWindow m, Boolean c)
        {
            parent = m;
            caisse = c;
            InitializeComponent();
            DataContext = parent.self;
            prixRepas.Text = parent.self.prixAPayer.ToString()+"€";
            if (parent.self.client != null)
            {
                setTextSoldeTot();
            }
            
        }

        private void UserControl1_Clicked(object sender, PlatCEventArgs e)
        {
            AbsPlat p = parent.self.FindPlat((sender as UCPlatC).NomPlat);
            if(e.Num == 0)
            {
                Incrementer(p);
            }else if(e.Num == 1)
            {
                Decrementer(p);
            }else if(e.Num == 2)
            {
                Supprimer(p);
            }
            liste.Items.Refresh();
            setTextSoldeTot();
            prixRepas.Text = parent.self.prixAPayer.ToString();
            // il faut mettre a jour le solde en appelant la methode soldeClient.Text = parent.self.client.Solde.ToString();
        }

        /// <summary>
        /// Méthode pour supprimer un plat choisis par le client
        /// </summary>
        /// <param name="p"></param>
        public void Supprimer(AbsPlat p)
        {
            parent.self.supprimerPlatChoisis(p);
        }

        /// <summary>
        /// Méthode pour incrémenter la quantité d'un plat choisis
        /// </summary>
        /// <param name="p"></param>
        public void Incrementer(AbsPlat p)
        {
            parent.self.AugmenterQuantitePlat(p);
            //refresh le recap
        }

        /// <summary>
        /// Méthode pour décrémenter la quantité d'un plat choisis
        /// </summary>
        /// <param name="p"></param>
        public void Decrementer(AbsPlat p)
        {
            if(parent.self.platsChoisisROC[p] == 1)
            {
                Supprimer(p);
            }
            else
            {
                parent.self.DiminuerQuantitePlat(p);

            }
        }

        public void setTextSoldeTot()
        { 
            if (parent.self.client.codePaiement == 0)
            {
                solde.Text = "Retenue Salaire";
                if (caisse)
                {
                    soldeClient.Text = (parent.self.client.Solde + parent.self.prixAPayer) + "€";
                }
                else
                {
                    soldeClient.Text = (parent.self.prixAPayer) + "€";
                }

            }
            else
            {
                if (caisse)
                {
                    soldeClient.Text = (parent.self.client.Solde - parent.self.prixAPayer) + "€";
                }
                else
                {
                    soldeClient.Text = (parent.self.prixAPayer) + "€";
                }
            }
        }

      
    }
}
