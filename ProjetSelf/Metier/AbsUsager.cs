using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class AbsUsager
    {
        public String ID { get; set; }
        public DateTime DateEntree { get; set; }
        public DateTime DateSortie { get; set; }
        public String Titre { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public int CodeFonction { get; set; }
        public String Service { get; set; }
        public AbsPaiement algoDePaiement;
        public double Solde { get; set; }
        public List<AbsRepas> historiquePlatChoisi = new List<AbsRepas>();
        public Carte carte;
        public String fonction;


        internal void payer(double prix)
        {
            algoDePaiement.algoPaiment(this, prix);
            //Effectuer changement solde dans BDD
        }


        //Permet D'ajouter un plat choisi
        internal void AddPlatChoisis(AbsPlat p)
        {
            foreach (AbsRepas r in historiquePlatChoisi)
            {
                if (r.date.Equals(DateTime.Now))
                {
                    r.AddPlat(p);
                    return;
                }
            }
            new Repas().AddPlat(p);
        }
    }
}