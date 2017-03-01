using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class AbsRepas
    {
        internal List<AbsPlatChoisis> plats = new List<AbsPlatChoisis>();
        public double Prix {get; private set; }
        public DateTime Date { get; private set; }

        internal void AddPlat(AbsPlat p)
        {
            plats.Add(new PlatChoisis(DateTime.Today, p.ID));
            Prix = Prix + p.Tarif;
        }

    }
}
