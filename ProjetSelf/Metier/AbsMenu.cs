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
        public List<Plat> plats = new List<Plat>();

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
    }
}
