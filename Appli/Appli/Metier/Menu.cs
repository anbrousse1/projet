using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    class Menu
    {
        internal int CodeMenu
        {
            get;
            private set;
        }

        internal String Date
        {
            get;
            private set;
        }

        private List<Plat> plats = new List<Plat>();

        public Menu(int codeMenu, String date, List<Plat> lplats)
        {
            CodeMenu = codeMenu;
            Date = date;
            plats = lplats;
        }
    }
}
