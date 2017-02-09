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

            // Création d'une instance de self avec une persistance en brute
            EntityDataManager bdd = new EntityDataManager();
            Self self = new Self(bdd);


            


            /* // création d'une liste de menu
             List<AbsMenu> lm = new List<AbsMenu>();
             // ajout de tout les menus de la persistance
             self.getAllMenus();
             Console.WriteLine("Les menus sont : ");

             foreach(Menu m in self.menusROC)
             {
                 Console.WriteLine("Code Menu : " + m.CodeMenu);

                 foreach(AbsPlat p in m.plats)
                 {
                     Console.WriteLine("code = " + p.ID + " nom = " + p.Nom +" Tarif = " + p.Tarif);
                 }
             }
             Console.ReadLine();
             */


            //AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

           bdd.chargementProduit();
           bdd.chargementPlat();


            //self.getAllPlats();
            List<Plat> platROC = new List<Plat>();
            platROC = bdd.getAllPlats();
            foreach (var p in platROC)
            {
                foreach (var  tamere in p.ingredients)
                {
                    Write(tamere.ToString());
                }
            }

            //Produit carotte = new Produit {DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom= "carotte",Observation = "ta gueule",Categorie = CategorieProduit.Legume };
           // Produit chien = new Produit {DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "chloé", Observation = "ta gueule", Categorie = CategorieProduit.Viande };
            //Produit salope = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "Pute", Observation = "ta gueule" };

           /* List<Produit> lp = new List<Produit>();
            
            using (EntityProduit db = new EntityProduit())
            {
                
                

                WriteLine("Base après ajout des 3 nounours et sauvegarde des changements :");
                foreach (var n in db.ProduitSet)
                {
                    lp.Add(n);
                }

                foreach (var p in lp)
                {
                    Write(p.ToString() + "\n");
                }
            }
            Plat femme = new Plat { Nom = "femme", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Plat, ingredients = lp };
            Plat homme = new Plat { Nom = "homme", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Plat, ingredients = lp };

            using (EntityPlat db = new EntityPlat())
            {
                db.PlatSet.AddRange(new Plat[] { femme, homme});
                db.SaveChanges();

                foreach (var n in db.PlatSet)
                {
                    Write(n.ToString() + "\n");

                }


            }*/
            Read();

        }
    }
}
