using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class AbsMenu
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public DateTime Effet { get; set; }
        public DateTime Fin { get; set; }
        public List<DateTime> dates = new List<DateTime>();
        private List<AbsPlat> plats = new List<AbsPlat>();

        public override string ToString()
        {
            string mess = $"{ID}: {Nom} \n";
            int i = 0;
            foreach (var p in dates)
            {
                i++;
                mess += "date " + i + " : " + p.ToString() + "\n";
            }
            foreach (var p in plats)
            {
                i++;
                mess += "Plat " + i + " : " + p.ToString() + "\n";
            }
            return mess;
        }

        /// <summary>
        /// Permet d'ajouter un date à un menu
        /// </summary>
        /// <param name="d"></param>
        internal void addDate(DateTime d)
        {
            dates.Add(d);
        }



        /// <summary>
        /// Permet d'ajouter un plat au menu
        /// </summary>
        /// <param name="p"></param>
        internal void addPlat(AbsPlat p)
        {
            if (plats.Count == 0)
            {
                Effet = p.DateEffet;
                Fin = p.DateFin;
            }else
            {
                if (Effet.CompareTo(p.DateEffet) > 0) { Effet = p.DateEffet; }
                if (Fin.CompareTo(p.DateFin) < 0) { Fin = p.DateFin; }
            }
            plats.Add(p);
        }


        /// <summary>
        /// permet d'obtenir la liste des plats d'un menu
        /// </summary>
        /// <returns></returns>
        public List<AbsPlat> getPlats()
        {
            return plats;
        }

        /// <summary>
        /// permet de modifier la liste des plats du menu 
        /// </summary>
        /// <param name="nPlats"></param>
        internal void modifierPlats(List<AbsPlat> nPlats)
        {
            plats.Clear();
            plats.AddRange(nPlats);
        }
    }
}
