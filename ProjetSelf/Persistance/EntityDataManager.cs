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
        public void chargeAll(Self s)
        {
            s.getAllProduit();
            s.getAllPlats();
            List<List<PlatProduit>> llpp = this.chargeAllPlatProduit(s.platROC.ToList(), s.produitsROC.ToList());
            foreach (var t in s.platROC)
            {
                foreach (var n in llpp)
                {
                    foreach (var b in n)
                    {
                        if (b.idplat == t.ID)
                        {
                            foreach (var v in s.produitsROC)
                            {
                                if (v.ID == b.idproduit)
                                {
                                    t.ingredients.Add(v);
                                }
                            }
                        }
                    }
                }
            }
            s.getAllMenus();
            List<List<MenuPlat>> llmp = this.chargeAllMenuPlat(s.menusROC.ToList(), s.platROC.ToList());
            foreach (var t in s.menusROC)
            {
                foreach (var n in llmp)
                {
                    foreach (var b in n)
                    {
                        if (b.idmenu == t.ID)
                        {
                            foreach (var v in s.platROC)
                            {
                                if (v.ID == b.idplat)
                                {
                                    t.plats.Add(v);
                                }
                            }
                        }
                    }
                }
            }
        }

        public List<Menu> chargeAllMenu()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            //WriteLine("Menu :");
            Menu m = new Menu { Nom = "bla" };
            List<Menu> lm = new List<Menu>();
            using (EntityMenu db = new EntityMenu())
            {
                db.Database.Delete();
                db.MenuSet.AddRange(new Menu[] { m });
                db.SaveChanges();

                foreach (var n in db.MenuSet)
                {
                    lm.Add(n);
                    //WriteLine(n.ToString());
                }
            }
            return lm;
        }

        public List<List<PlatProduit>> chargeAllPlatProduit(List<Plat> lpp, List<Produit> lp)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            //WriteLine("PlatProduit :");
            PlatProduit femmeCarrote = new PlatProduit { idplat = lpp.Find(p => p.Nom == "femme").ID, idproduit = lp.Find(p => p.Nom == "carotte").ID };
            PlatProduit femmeChien = new PlatProduit { idplat = lpp.Find(p => p.Nom == "femme").ID, idproduit = lp.Find(p => p.Nom == "chloé").ID };
            PlatProduit hommeChien = new PlatProduit { idplat = lpp.Find(p => p.Nom == "homme").ID, idproduit = lp.Find(p => p.Nom == "chloé").ID };
            PlatProduit hommeSalope = new PlatProduit { idplat = lpp.Find(p => p.Nom == "homme").ID, idproduit = lp.Find(p => p.Nom == "Pute").ID };
            List<List<PlatProduit>> llpp = new List<List<PlatProduit>>();
            List<PlatProduit> femmeP = new List<PlatProduit>();
            List<PlatProduit> hommeP = new List<PlatProduit>();

            using (EntityPlatProduit db = new EntityPlatProduit())
            {
                db.Database.Delete();
                db.PlatProduitSet.AddRange(new PlatProduit[] { femmeCarrote, femmeChien, hommeChien, hommeSalope });
                db.SaveChanges();

                foreach (var n in db.PlatProduitSet)
                {
                    if (lpp.Find(p => p.Nom == "femme").ID == n.idplat)
                    {
                        femmeP.Add(n);
                        //WriteLine(n.ToString());
                    }
                    if (lpp.Find(p => p.Nom == "homme").ID == n.idplat)
                    {
                        hommeP.Add(n);
                        //WriteLine(n.ToString());
                    }
                }
                llpp.Add(femmeP);
                llpp.Add(hommeP);
                return llpp;
            }
        }

        public List<List<MenuPlat>> chargeAllMenuPlat(List<Menu> lm, List<Plat> lpp)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            //WriteLine("MenuPlat :");
            MenuPlat mP1 = new MenuPlat { idmenu = lm.Find(a => a.Nom=="bla").ID, idplat = lpp.Find(a => a.Nom=="femme").ID, date = DateTime.Today };
            MenuPlat mP2 = new MenuPlat { idmenu = lm.Find(a => a.Nom == "bla").ID, idplat = lpp.Find(a => a.Nom == "homme").ID, date = DateTime.Today };
            List<List<MenuPlat>> llmp = new List<List<MenuPlat>>();
            List<MenuPlat> lmp = new List<MenuPlat>();

            using (EntityMenuPlat db = new EntityMenuPlat())
            {
                db.Database.Delete();
                db.MenuPlatSet.AddRange(new MenuPlat[] { mP1, mP2 });
                db.SaveChanges();

                foreach (var n in db.MenuPlatSet)
                {
                    if (lm.Find(a => a.Nom == "bla").ID == n.idmenu)
                    {
                        lmp.Add(n);
                    }
                }
            }

            llmp.Add(lmp);
            return llmp;
        }

        public List<Plat> chargeAllPlats()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            //WriteLine("Plats :");
            Plat femme = new Plat { Nom = "femme", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Plat };
            Plat homme = new Plat { Nom = "homme", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Plat };
            List<Plat> lpp = new List<Plat>();
            using (EntityPlat db = new EntityPlat())
            {
                db.Database.Delete();
                db.PlatSet.AddRange(new Plat[] { femme, homme });
                db.SaveChanges();

                foreach (var n in db.PlatSet)
                {
                    lpp.Add(n);
                    //WriteLine(n.ToString());
                }
            }
            return lpp;
        }

        public List<Produit> chargeAllProduits()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            //WriteLine("Produits :");
            Produit carotte = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "carotte", Observation = "ta gueule", Categorie = CategorieProduit.Legume };
            Produit chien = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "chloé", Observation = "ta gueule", Categorie = CategorieProduit.Viande };
            Produit salope = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "Pute", Observation = "ta gueule", Categorie = CategorieProduit.Charcuterie };
            List<Produit> lp = new List<Produit>();

            using (EntityProduit db = new EntityProduit())
            {
                db.Database.Delete();
                db.ProduitSet.AddRange(new Produit[] { carotte, chien, salope });
                db.SaveChanges();

                foreach (var n in db.ProduitSet)
                {
                    lp.Add(n);
                    //WriteLine(n.ToString());

                }
            }
            return lp;
        }
 
    }
}
