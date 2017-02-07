using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    internal class Menu : AbsMenu
    {


        //Constructeur de menu
        internal Menu(int codeMenu, List<AbsPlat> lplats)
        {
            CodeMenu = codeMenu;
            plats = lplats;
        }


    }
}
