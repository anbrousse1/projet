using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class AbsRepas
    {
        public int ID { get; set; }
        public List<AbsPlatChoisis> plats = new List<AbsPlatChoisis>();
        public double Prix {get; set; }
        public DateTime Date { get; set; }
        public int idUsager { get; set; }

        internal void AddPlat(AbsPlat p)
        {
            plats.Add(new PlatChoisis{ Date = DateTime.Today, CodePlat = p.ID });
            Prix = Prix + p.Tarif;
        }
    }
}
