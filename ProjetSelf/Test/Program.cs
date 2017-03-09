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

            EntityDataManager bdd = new EntityDataManager();
            Self self = new Self(bdd);

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
