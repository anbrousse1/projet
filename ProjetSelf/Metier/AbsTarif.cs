using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    abstract class AbsTarif
    {
        public int ID { get; set; }
        public int IdPlat { get; set; }
        public double Prix { get; set; }
        public DateTime DateEffet { get; set; }
    }
}
