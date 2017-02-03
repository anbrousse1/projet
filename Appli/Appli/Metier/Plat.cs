using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class Plat
    {
        internal int CodePlat { get;private set;}
        internal DateTime DateEffet {get;private set;}
        internal DateTime DateFin{get;private set;}
        internal String Nom{get;private set;}
        internal double Tarif {get;private set;}
        internal CategoriePlat Categorie {get; private set;}
        private List<Produit> ingrediants = new List<Produit>();


        //Constructeur de plat
        internal Plat(int codePlat, DateTime dateEffet, DateTime dateFin, String nom, double tarif, List<Produit> lingrediants, CategoriePlat categorie)
        {
            CodePlat = codePlat;
            DateEffet = dateEffet;
            DateFin = dateFin;
            Nom = nom;
            Tarif = tarif;
            ingrediants = lingrediants;
            Categorie = categorie;
        }


        //méthode permettant de modifier le tarif d'un plat 
        internal void changerTarif(double tarif)
        {
            Tarif = tarif;
        }

        //méthode permettant de changer la date d'effet
        internal void ChangerDateEffet(DateTime d)
        {
            DateEffet = d;
        }

        //méthode permettant de modifier la date de fin
        internal void ChangerDateFin(DateTime d)
        {
            DateFin = d;
        }



    }
}
