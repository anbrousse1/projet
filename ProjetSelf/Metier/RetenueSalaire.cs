﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    class RetenueSalaire : AbsPaiement
    {
        internal override void algoPaiment(AbsUsager u, double montantAPayer)
        {
            u.Solde = u.Solde + montantAPayer;
        }
    }
}