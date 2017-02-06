using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal abstract class Utilisateur : AbsUsager
    {

        internal Utilisateur(String matricule, DateTime de, DateTime ds, String titre, String nom, String prenom, int cfonction, String service, int codePaiement, long solde, int numCarte)
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
            }
            else
            {
                algoDePaiement = new RetenueSalaire();
            }
        }
            

        internal Utilisateur (String matricule, DateTime de, DateTime ds, String titre, String nom, String prenom, int cfonction, String service, int codePaiement, long solde, int numCarte, List<AbsPlatChoisis> histo)
        {
            Matricule = matricule;
            DateEntree = de;
            DateSortie = ds;
            Titre = titre;
            Nom = nom;
            Prenom = prenom;
            CodeFonction = cfonction;
            if(CodeFonction == 001)
            {
                fonction = "Caissier";
            }else if (CodeFonction == 002)
            {
                fonction = "Cuisinier";
            }else
            {
                fonction = "Gerant";
            }
            Service = service;
            Solde = solde;
            carte = new Carte(numCarte);
            if (codePaiement == 1)
            {
                algoDePaiement = new PreAlimente();
            }
            else
            {
                algoDePaiement = new RetenueSalaire();
            }
            historiquePlatChoisi.AddRange(histo);
        }

    }
}
