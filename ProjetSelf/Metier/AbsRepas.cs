using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    internal class AbsRepas
    {
        internal List<AbsPlatChoisis> plats;
        internal double prix;
        internal DateTime date;

        internal void AddPlat(AbsPlat p)
        {
            plats.Add(new PlatChoisis(DateTime.Now, p.ID));
            prix = prix + p.Tarif;
        }
    }
}
