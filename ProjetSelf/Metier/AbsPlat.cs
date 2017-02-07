using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    internal abstract class AbsPlat
    {
        internal int CodePlat { get; set; }
        internal DateTime DateEffet { get; set; }
        internal DateTime DateFin { get; set; }
        internal String Nom { get; set; }
        internal double Tarif { get; set; }
        internal CategoriePlat Categorie { get; set; }
        protected List<AbsProduit> ingredients = new List<AbsProduit>();

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

