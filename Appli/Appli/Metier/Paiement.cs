using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal abstract class Paiement
    {
         abstract internal void algoPaiment(Usager u, double montantAPayer);
    }
}
