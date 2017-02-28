using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class AbsUsager
    {
        public int ID { get; set; }
        public DateTime DateEntree { get; set; }
        public DateTime DateSortie { get; set; }
        public String Titre { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int CodeFonction { get; set; }
        public String Service { get; set; }
        public int codePaiement;
        public AbsPaiement algoDePaiement;
        public double Solde { get; set; }
        
        private List<AbsRepas> historiquePlatChoisi = new List<AbsRepas>();
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsRepas> histoRepasROC
        { 
            get;
            private set;
        }
        public Carte carte;
        public String Fonction { get; set; }

        public override string ToString()
        {
            String m = "id : " + ID + " " + Titre + " " + Nom + " " + Prenom + " carte numéro : " + carte.Numero;
            return m;
        }

        internal void payer(double prix)
        {
            if (codePaiement == 0)
            {
                algoDePaiement = new RetenueSalaire();
            }else { algoDePaiement = new PreAlimente(); }

            algoDePaiement.algoPaiment(this, prix);
            //Effectuer changement solde dans BDD
        }

        /// <summary>
        /// Permet D'ajouter un plat choisi
        /// </summary>
        internal void AddPlatChoisis(AbsPlat p)
        {
            foreach (AbsRepas r in historiquePlatChoisi)
            {
                if (r.date.Equals(DateTime.Today))
                {
                    r.AddPlat(p);
                    return;
                }
            }
            new Repas().AddPlat(p);
        }

        internal void lierList()
        {
            histoRepasROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsRepas>(historiquePlatChoisi);
        }
    }
}