using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;

namespace Persistance
{
    public class StubDataManager : IDataManager
    {
        List<AbsPlat> listPlat = new List<AbsPlat>();
        List<AbsMenu> listMenu = new List<AbsMenu>();

        public List<AbsMenu> getAllMenu()
        {
            listPlat.Add(new Plat(001, DateTime.Today, DateTime.Today, "la maman de yohann", 100000, null, CategoriePlat.Entree));
            listPlat.Add(new Plat(002, DateTime.Today, DateTime.Today, "Chloé", -100, null, CategoriePlat.Plat));
            Menu m1 = new Menu(0001, listPlat);
            
            listMenu.Add(m1);

            return listMenu;
        }
    }
}
