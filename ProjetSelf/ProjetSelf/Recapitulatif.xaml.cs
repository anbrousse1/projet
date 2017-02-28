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
                if (parent.self.client.codePaiement == 0)
                {
                    solde.Text = "Retenue Salaire";
                    if (caisse)
                    {
                        soldeClient.Text = (parent.self.client.Solde + parent.self.prixAPayer) + "€";
                    }else
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
        }

        /// <summary>
        /// Méthode pour décrémenter la quantité d'un plat choisis
        /// </summary>
        /// <param name="p"></param>
        public void Decrementer(AbsPlat p)
        {
            parent.self.DiminuerQuantitePlat(p);
        }
    }
}
