﻿using System;
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
        public int CodePaiement { get; set; }
        public AbsPaiement algoDePaiement;
        public double Solde { get; set; }
        
        /*private List<AbsRepas> historiquePlatChoisi = new List<AbsRepas>();
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsRepas> histoRepasROC
        { 
            get;
            private set;
        }*/
        public int NumCarte { get; set; }
        public String Fonction { get; set; }

        public override string ToString()
        {
            String m = "id : " + ID + " " + Titre + " " + Nom + " " + Prenom + " carte numéro : " + NumCarte;
            return m;
        }

        internal void payer(double prix)
        {
            if (CodePaiement == 0)
            {
                algoDePaiement = new RetenueSalaire();
            }else { algoDePaiement = new PreAlimente(); }

            algoDePaiement.algoPaiment(this, prix);
            //Effectuer changement solde dans BDD
        }

        /*/// <summary>
        /// Permet D'ajouter un plat choisi
        /// </summary>
        internal void AddPlatChoisis(AbsPlat p)
        {
            foreach (AbsRepas r in historiquePlatChoisi)
            {
                if (r.Date.Equals(DateTime.Today))
                {
                    r.AddPlat(p);
                    return;
                }
            }
            AbsRepas re = new Repas();
            re.AddPlat(p);
            historiquePlatChoisi.Add(re);
        }

        internal void lierList()
        {
            histoRepasROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsRepas>(historiquePlatChoisi);
        }*/
    }
}