using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class AbsPlat
    {
        public int ID { get; set; }
        public DateTime DateEffet { get; set; }
        public DateTime DateFin { get; set; }
        public String Nom { get; set; }
        public double Tarif { get; set; }
        public CategoriePlat Categorie { get; set; }
        public List<Produit> ingredients = new List<Produit>();

        public override string ToString()
        {
            string mess =  $"{ID}: {Nom} ({DateEffet:dd/MM/yyyy},{Categorie})\n";
            int i = 0;
            foreach (var p in ingredients)
            {
                i++;
                mess+= "Produit "+ i + " : "+ p.ToString() + "\n";
            }
            return mess;

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

