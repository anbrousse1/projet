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
            foreach(var u in self.usagerROC)
            {
                WriteLine(u.ToString());
            }

            /*
            foreach (var l in self.menusROC)
            {
                WriteLine(l.ToString());
            }*/
            /*
            
            List<Usager> lu = new List<Usager>();

            Usager Bastien = new Usager { Nom = "Gandboeuf", Prenom = "Bastien", CodeFonction = 1, DateEntree = new DateTime(11, 02, 15), Service = "Restaurant", Titre = "Monsieur", algoDePaiement = new PreAlimente(), Solde = 25, carte = new Carte(12), Fonction = "Caissier" };
            Usager Leandre = new Usager { Nom = "Perrot", Prenom = "Leandre", CodeFonction = 2, DateEntree = new DateTime(14, 07, 16), Service = "Restaurant", Titre = "Monsieur", algoDePaiement = new PreAlimente(), Solde = 78, carte = new Carte(15), Fonction = "Gérant" };

            lu.Add(Bastien);
            lu.Add(Leandre);

            //lu = bdd.chargeAllUsager();
            
            foreach (var l in lu)
            {
                WriteLine(l.ToString());
            }*/


            Read();
            
        }
    }
}
