using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
using System.IO;

namespace Persistance
{
    class EntityDataManager : IDataManager
    {

        public List<AbsMenu> getAllMenu()
        {
            throw new NotImplementedException();
        }

        public List<Plat> getAllPlats()
        {
            List<Plat> lp = new List<Plat>();

            using (EntityPlat db = new EntityPlat())
            {
                foreach (var n in db.PlatSet)
                {
                    lp.Add(n);
                }
            }
            return lp;
        }


        public List<Produit> getAllProduits()
        {
            List<Produit> lp = new List<Produit>();

            using (EntityProduit db = new EntityProduit())
            {
                foreach (var n in db.ProduitSet)
                {
                    lp.Add(n);
                }
            }
            return lp;
        }
        

        /// <summary>
        /// Charge les produits 
        /// </summary>
        public void chargementProduit()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            Produit carotte = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "carotte", Observation = "ta gueule", Categorie = CategorieProduit.Legume };
            Produit chien = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "chloé", Observation = "ta gueule", Categorie = CategorieProduit.Viande };
            Produit salope = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "Pute", Observation = "ta gueule" };

            using (EntityProduit db = new EntityProduit())
            {
                if (db.ProduitSet.Count() > 0)
                {
                    foreach (var n in db.ProduitSet.ToArray())
                    {
                        db.ProduitSet.Remove(n);
                    }
                }

                db.ProduitSet.AddRange(new Produit[] { carotte, chien, salope });
                db.SaveChanges();
            }

        }

       

        public void chargementPlat()
        {
            
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());
            List<Produit> lp = new List<Produit>();
            lp.Add(new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "Pute", Observation = "ta gueule" });

            Plat femme = new Plat { Nom = "femme", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Plat, ingredients = lp };
            Plat homme = new Plat { Nom = "homme", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Plat, ingredients = lp };

            using (EntityPlat db = new EntityPlat())
            {
                if (db.PlatSet.Count() > 0)
                {
                    foreach (var n in db.PlatSet.ToArray())
                    {
                        db.PlatSet.Remove(n);
                    }
                }

                db.PlatSet.AddRange(new Plat[] { femme, homme});
                db.SaveChanges();
            }

        }
    }
}
