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

            foreach (var u in self.usagerROC)
            {
                WriteLine(u.ToString());
            }

            PlatChoisis pc1 = new PlatChoisis { CodePlat = 1, Date = DateTime.Today };
            PlatChoisis pc2 = new PlatChoisis { CodePlat = 2, Date = DateTime.Today };
            PlatChoisis pc3 = new PlatChoisis { CodePlat = 3, Date = DateTime.Today };
            PlatChoisis pc4 = new PlatChoisis { CodePlat = 4, Date = DateTime.Today };
            List<AbsPlatChoisis> lpc = new List<AbsPlatChoisis>();
            lpc.Add(pc1);
            lpc.Add(pc2);
            lpc.Add(pc3);
            lpc.Add(pc4);
            bdd.ajouterRepas(new Repas { Date = DateTime.Today, IdUsager = 1, IdCaissier = 1, Prix = 15},lpc);
            bdd.ajouterRepas(new Repas { Date = DateTime.Today, IdUsager = 2, IdCaissier = 1, Prix = 20 }, lpc);
            bdd.ajouterRepas(new Repas { Date = DateTime.Today, IdUsager = 2, IdCaissier = 1, Prix = 5 }, lpc);
            bdd.ajouterRepas(new Repas { Date = DateTime.Today, IdUsager = 1, IdCaissier = 1, Prix = 6 }, lpc);

            WriteLine(bdd.chiffreDAffaire());
            WriteLine(bdd.prixMoyen());
            WriteLine(bdd.frequentation());

            /*foreach(var r in bdd.getRepasUsager(self.usagerROC.ToList().Find(a => a.ID == 1)))
            {
                WriteLine(r.ToString());
            }*/
            /*using (EntityUtilisateur db = new EntityUtilisateur())
            {
                foreach (var u in db.UtilisateurSet)
                {
                    WriteLine(u.Password);
                }
            }

            AbsUtilisateur ut = self.utilisateurROC.ToList().Find(a => a.ID == 1);
            bdd.modifMdp(ut, "Bonjour");

            using (EntityUtilisateur db = new EntityUtilisateur())
            {
                foreach (var u in db.UtilisateurSet)
                {
                    WriteLine(u.Password);
                }
            }*/

            Read();
            /*
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
