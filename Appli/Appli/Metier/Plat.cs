using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class Plat
    {
        internal int CodePlat
        {
            get;
            private set;
        }

        //Type Date
        internal DateTime DateEffet
        {
            get;
            private set;
        }

        //Type date
        internal DateTime DateFin
        {
            get;
            private set;
        }

        internal String Nom
        {
            get;
            private set;
        }

        internal double Tarif
        {
            get;
            private set;
        }

        internal enum CategoriePlat
        {
            Entree,
            Plat,
            Dessert
        };

        internal CategoriePlat Categorie
        {
            get;
            private set;
        }

        private List<Produit> ingrediants = new List<Produit>();

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
    }
}
