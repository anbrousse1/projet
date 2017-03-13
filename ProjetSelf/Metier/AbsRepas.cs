using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class AbsRepas
    {
        public int ID { get; set; }
        public List<AbsPlatChoisis> plats = new List<AbsPlatChoisis>();
        public double Prix {get; set; }
        public DateTime Date { get; set; }
        public int IdUsager { get; set; }
        public int IdCaissier { get; set; }


        public void AddPlat(AbsPlat p)
        {
            plats.Add(new PlatChoisis{ Date = DateTime.Today, CodePlat = p.ID });
            Prix = Prix + p.Tarif;
        }

        override
        public String ToString()
        {
            String s;
            s = "Repas n° " + ID + " Date : " + Date + " au prix de " + Prix + " pour l'usager n° " + IdUsager + " codes Plats : ";
            foreach(var v in plats)
            {
                s += v.CodePlat + " ";
            }
            s += "N° Caissier " + IdCaissier;
            s += ".";
            return s;
        }
    }
}
