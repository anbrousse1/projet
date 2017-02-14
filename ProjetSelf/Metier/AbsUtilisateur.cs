using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class AbsUtilisateur
    {
        public int ID { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }

        public override string ToString()
        {
            String m = "id : " + ID + " " + Login;
            return m;
        }
    }
}
