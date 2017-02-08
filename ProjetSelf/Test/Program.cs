using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
using Persistance;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une instance de self avec une persistance en brute
            Self self = new Self(new StubDataManager());
            // création d'une liste de menu
            List<AbsMenu> lm = new List<AbsMenu>();
            // ajout de tout les menus de la persistance
            self.getAllMenus();
            Console.WriteLine("Les menus sont : ");

            foreach(Menu m in self.menusROC)
            {
                Console.WriteLine("Code Menu : " + m.CodeMenu);
                
                foreach(AbsPlat p in m.plats)
                {
                    Console.WriteLine("code = " + p.CodePlat + " nom = " + p.Nom +" Tarif = " + p.Tarif);
                }
            }
            Console.ReadLine();

        }
    }
}
