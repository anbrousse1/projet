using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class AbsProduit
    {
        public int ID { get; set; }
        public DateTime DateEffet { get; set; }
        public DateTime DateFin { get; set; }
        public String Nom { get; set; }
        public String Observation { get; set; }
        public CategorieProduit Categorie { get; set; }

        public override string ToString()
        {
            return $"{ID}: {Nom} ({DateEffet:dd/MM/yyyy}, {Observation} , {Categorie})";
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
