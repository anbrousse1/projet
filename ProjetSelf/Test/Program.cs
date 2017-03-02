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
<<<<<<< HEAD
            /* Usager bastien = new Usager
             {
                 Nom = "Gandboeuf",
                 Prenom = "Bastien",
                 CodeFonction = 1,
                 DateEntree = DateTime.Today,
                 Service = "Restaurant",
                 Titre = "Monsieur",
                 algoDePaiement = new PreAlimente(),
                 Solde = 25,
                 carte = new Carte(12),
                 Fonction = "Caissier"
             };*/
            // EcrireTicketFichier.ecrireTicket(bastien);

            Console.Write(DateTime.Now.Year);
            Read();
=======
>>>>>>> 4e25d4915c28b29fa72934d8cef3b057b2f0b8c2
            
            EntityDataManager bdd = new EntityDataManager();
            Self self = new Self(bdd);

            /*self.addProduit(DateTime.Today, DateTime.Today, "test", "testestest", "Poisson");

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
            */
            foreach(var u in self.menusROC)
            {
                 WriteLine(u.ToString());
            }

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
