using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
using Persistance;
using System.IO;

using static System.Console;
using Microsoft.SqlServer.Management.Smo;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            EntityDataManager bdd = new EntityDataManager();
            Self self = new Self(bdd);

            self.addProduit(DateTime.Today, DateTime.Today, "test", "testestest", "Poisson");

            foreach (var u in self.produitsROC)
            {
                WriteLine(u.ToString());
            }

            self.addplat(DateTime.Today, DateTime.Today, "plattest", 50, self.produitsROC.Where(w => w.ID > 3).ToList(), "Plat");

            foreach (var u in self.platROC)
            {
                WriteLine(u.ToString());
            }

            self.addMenu("menutest", self.platROC.Where(w => w.ID > 2).ToList());

            foreach (var u in self.menusROC)
            {
                WriteLine(u.ToString());
            }

            Read();

            /*foreach(var u in self.menusROC)
            {
                 WriteLine(u.ToString());
            }

            Read();

            BackupFile.Sauvegarde();
            // Inform the user that the backup has been completed.   
            System.Console.WriteLine("Full Backup complete.");
            /*
            BackupFile.Restore();
            // Inform the user that the restore has been completed.   
            System.Console.WriteLine("Full Restore complete.");

            /*foreach (var u in self.menusROC)
            {
                WriteLine(u.ToString());
            }

            Read();
            */
        }
    }
}
