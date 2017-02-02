using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class Menu
    {
        internal int CodeMenu
        {
            get;
            private set;
        }

        //Liste de date.
        internal String Date
        {
            get;
            private set;
        }

        private List<Plat> plats = new List<Plat>();

        internal Menu(int codeMenu, String date, List<Plat> lplats)
        {
            CodeMenu = codeMenu;
            Date = date;
            plats = lplats;
        }
    }
}
