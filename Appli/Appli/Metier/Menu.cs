using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class Menu
    {
        internal int CodeMenu{get;private set;}
        internal List<DateTime> dates= new List<DateTime>();
        internal List<Plat> plats = new List<Plat>();

        //Constructeur de menu
        internal Menu(int codeMenu, List<Plat> lplats)
        {
            CodeMenu = codeMenu;
            plats = lplats;
        }


        //Permet d'ajouter un date à un menu
        internal void AddDate(DateTime d)
        {
            dates.Add(d);
        }


        //Permet d'ajouter une liste de  date à un menu
        internal void AddListDate(List<DateTime> d)
        {
            dates.AddRange(d);
        }

    }
}
