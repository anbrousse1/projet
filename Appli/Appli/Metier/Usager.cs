using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class Usager
    {
        internal String Matricule { get; private set; }
        internal DateTime DateEntree { get; private set; }
        internal DateTime DateSortie { get; private set; }
        internal String Titre { get; private set; }
        internal String Nom { get; private set; }
        internal String Prenom { get; private set; }
        internal int CodeFonction { get; private set; }
        internal String Service { get; private set; }
        internal Paiement algoDePaiement;
        internal double Solde { get; set; }
        internal List<PlatChoisis> historiquePlatChoisi;
        internal Carte carte;

        internal Usager(String matricule, DateTime de, DateTime ds, String titre, String nom, String prenom, int cfonction, String service, int codePaiement, long solde, int numCarte)
        {
            Matricule = matricule;
            DateEntree = de;
            DateSortie = ds;
            Titre = titre;
            Nom = nom;
            Prenom = prenom;
            CodeFonction = cfonction;
            Service = service;
            Solde = solde;
            carte = new Carte(numCarte);
            if (codePaiement == 1)
            {
                algoDePaiement = new PreAlimente();
            }else
            {
                algoDePaiement = new RetenueSalaire();
            }
        }

        //methode qui appelle un algo permetant d'incrementer la retenue sur salaire ou de décrementer la solde de l'usager
        internal void payer(double prix)
        {
            algoDePaiement.algoPaiment(this, prix);
        }

    }
}
