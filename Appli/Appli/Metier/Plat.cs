using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class Plat : AbsPlat
    {



        //Constructeur de plat
        internal Plat(int codePlat, DateTime dateEffet, DateTime dateFin, String nom, double tarif, List<AbsProduit> lingredients, CategoriePlat categorie)
        {
            CodePlat = codePlat;
            DateEffet = dateEffet;
            DateFin = dateFin;
            Nom = nom;
            Tarif = tarif;
            ingredients = lingredients;
            Categorie = categorie;
        }


    }
}
