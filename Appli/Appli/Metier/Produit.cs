using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    class Produit
    {
        internal int CodeProduit
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

        internal String Observation
        {
            get;
            private set;
        }

        public enum CategorieProduit
        {
            Fruit,
            Legume,
            Viande,
            Poisson
        };

        internal CategorieProduit Categorie
        {
            get;
            private set;
        }

        public Produit(int codeProduit, String dateEffet, String dateFin, String nom, String observation, CategorieProduit categorie)
        {
            CodeProduit = codeProduit;
            DateEffet = dateEffet;
            DateFin = dateFin;
            Nom = nom;
            Observation = observation;
            Categorie = categorie;
        }
    }
}
