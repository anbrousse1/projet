using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class MachinTrucEventArgs : EventArgs
    {
        public string TheProut
        {
            get; private set;
        }

        public MachinTrucEventArgs(string theProut)
        {
            TheProut = theProut;
        }
    }
}
