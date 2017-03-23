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

        public override int GetHashCode()
        {
            return Nom.GetHashCode() + base.GetHashCode();
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
            plats = nPlats;
            initDateEffet();
        }

        /// <summary>
        /// Remet la liste des plats à 0
        /// </summary>
        internal void clearPlats()
        {
            plats.Clear();
        }

        internal void initDateEffet()
        {
            DateTime effet = plats[0].DateEffet;
            DateTime fin = plats[0].DateFin;
            foreach (AbsPlat p in plats)
            {
                if (p.DateEffet.CompareTo(effet) > 0) { effet = p.DateEffet; }
                if (p.DateFin.CompareTo(fin) < 0) { fin = p.DateFin; }
            }
            this.Effet = effet;
            this.Fin = fin;
        }

        internal Boolean supprimable()
        {
            if (dates.Count == 0) { return true; }
            foreach(DateTime d in dates)
            {
                if (d.CompareTo(DateTime.Today) >= 0) { return false; }
            }
            return true;
        }

        internal Boolean containsPlat(AbsPlat p)
        {
            return (plats.Contains(p));
        }
    }
}
