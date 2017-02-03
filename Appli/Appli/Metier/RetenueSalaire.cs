﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class RetenueSalaire : Paiement
    {
        internal override void algoPaiment(Usager u, double montantAPayer)
        {
            u.Solde = u.Solde + montantAPayer;
        }
    }
}
