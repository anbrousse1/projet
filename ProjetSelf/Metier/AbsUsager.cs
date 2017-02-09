using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    internal abstract class AbsUsager
    {
        internal String Matricule { get; set; }
        internal DateTime DateEntree { get; set; }
        internal DateTime DateSortie { get; set; }
        internal String Titre { get; set; }
        internal String Nom { get; set; }
        internal String Prenom { get; set; }
        internal int CodeFonction { get; set; }
        internal String Service { get; set; }
        internal AbsPaiement algoDePaiement;
        internal double Solde { get; set; }
        internal List<AbsRepas> historiquePlatChoisi = new List<AbsRepas>();
        internal Carte carte;
        internal String fonction;


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