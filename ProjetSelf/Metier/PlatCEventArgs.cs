using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class PlatCEventArgs :EventArgs
    {
        public int Num { get; set; }

        public PlatCEventArgs(int num)
        {
            Num = num;
        }
        
    } 

     
}
