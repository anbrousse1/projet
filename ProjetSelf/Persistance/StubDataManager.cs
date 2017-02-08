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
        
        public void getAllMenu()
        {
            listPlat.Add(new Plat(001, DateTime.Today, DateTime.Today, "la maman de yohann", 100000, null, CategoriePlat.Entree));
            Menu m1 = new Menu(0001, listPlat);
        }
    }
}
