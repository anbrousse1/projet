using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class Carte
    {
        internal int Numero { get; private set; }

        internal Carte(int num)
        {
            Numero = num;
        }
    }
}
