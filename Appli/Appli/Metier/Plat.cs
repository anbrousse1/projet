using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    class Plat
    {
        internal int CodePlat
        {
            get;
            private set;
        }

        internal String DateEffet
        {
            get;
            private set;
        }

        internal String DateFin
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

        public enum CategoriePlat
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

        public Plat(int codePlat, String dateEffet, String dateFin, String nom, double tarif, List<Produit> lingrediants, CategoriePlat categorie)
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
