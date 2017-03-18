using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    abstract class AbsTarif
    {
        public double Prix { get; private set; }
        public DateTime DateEffet { get; private set; }
    }
}
