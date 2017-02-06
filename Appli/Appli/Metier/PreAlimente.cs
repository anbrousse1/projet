using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class PreAlimente : AbsPaiement
    {
        internal override void algoPaiment(AbsUsager u, double montantAPayer)
        {
            u.Solde = u.Solde - montantAPayer;
        }
    }
}
