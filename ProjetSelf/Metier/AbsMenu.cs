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
        public DateTime effet= new DateTime();
        public DateTime fin= new DateTime();
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

        //Permet d'ajouter un date à un menu
        internal void AddDate(DateTime d)
        {
            dates.Add(d);
        }


        //Permet d'ajouter une liste de  date à un menu
        internal void AddListDate(List<DateTime> d)
        {
            dates.AddRange(d);
        }


        internal void AddPlats(AbsPlat p)
        {
            if (plats.Count == 0)
            {
                effet = p.DateEffet;
                fin = p.DateFin;
            }else
            {
                if (effet.CompareTo(p.DateEffet) > 0) { effet = p.DateEffet; }
                if (fin.CompareTo(p.DateFin) < 0) { fin = p.DateFin; }
            }
            plats.Add(p);
        }

        public List<AbsPlat> getPlats()
        {
            return plats;
        }
    }
}
