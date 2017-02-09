using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    class Repas : AbsRepas
    {
        internal Repas()
        {
            date = DateTime.Now;
            prix = 0;
            plats = new List<AbsPlatChoisis>();
        }
    }
}
