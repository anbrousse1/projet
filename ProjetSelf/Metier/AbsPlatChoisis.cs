using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class AbsPlatChoisis
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int CodePlat { get; set; }
    }
}
