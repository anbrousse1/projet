using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal abstract class AbsProduit
    {
        internal int CodeProduit { get; set; }
        internal DateTime DateEffet { get; set; }
        internal DateTime DateFin { get; set; }
        internal String Nom { get; set; }
        internal String Observation { get; set; }
        internal CategorieProduit Categorie { get; set; }

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
