using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    internal abstract class AbsPaiement
    {
        abstract internal void algoPaiment(AbsUsager u, double montantAPayer);
    }
}

