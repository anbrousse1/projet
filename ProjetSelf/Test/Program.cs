using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
using Persistance;
using System.IO;

using static System.Console;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            EntityDataManager bdd = new EntityDataManager();
            Self self = new Self(bdd);

            self.chargeAll();
            
            foreach (var l in self.menusROC)
            {
                WriteLine(l.ToString());
            }
            
            Read();

        }
    }
}
