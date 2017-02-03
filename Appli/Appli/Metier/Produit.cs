using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class Produit
    {
        internal int CodeProduit{get;private set;}
        internal DateTime DateEffet {get;private set;}
        internal DateTime DateFin{get; private set;}
        internal String Nom{get;private set;}
        internal String Observation { get; private set;}
        internal CategorieProduit Categorie{ get;private set; }


        //Constructeur de produit
        internal Produit(int codeProduit, DateTime dateEffet, DateTime dateFin, String nom, String observation, CategorieProduit categorie)
        {
            CodeProduit = codeProduit;
            DateEffet = dateEffet;
            DateFin = dateFin;
            Nom = nom;
            Observation = observation;
            Categorie = categorie;
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
