using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    class Produit: AbsProduit
    {
        internal Produit(int codeProduit, DateTime dateEffet, DateTime dateFin, String nom, String observation, CategorieProduit categorie)
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
