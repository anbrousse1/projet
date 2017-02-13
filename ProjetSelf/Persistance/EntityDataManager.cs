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
            Menu m = new Menu { Nom = "Menu1" };
            Menu m2 = new Menu { Nom = "Menu2" };
            List<Menu> lm = new List<Menu>();

            using (EntityMenu db = new EntityMenu())
            {
                db.Database.Delete();
                db.MenuSet.AddRange(new Menu[] { m, m2 });
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
            PlatProduit carotteRape = new PlatProduit { idplat = lpp.Find(p => p.Nom == "carotteRapée").ID, idproduit = lp.Find(p => p.Nom == "carotte").ID };
            PlatProduit saucisse = new PlatProduit { idplat = lpp.Find(p => p.Nom == "lentilleSauc").ID, idproduit = lp.Find(p => p.Nom == "saucisse").ID };
            PlatProduit lentille = new PlatProduit { idplat = lpp.Find(p => p.Nom == "lentilleSauc").ID, idproduit = lp.Find(p => p.Nom == "lentille").ID };
            PlatProduit saucisson = new PlatProduit { idplat = lpp.Find(p => p.Nom == "saucisson").ID, idproduit = lp.Find(p => p.Nom == "saucisson").ID };
            List<List<PlatProduit>> llpp = new List<List<PlatProduit>>();
            List<PlatProduit> PlatProd1 = new List<PlatProduit>();
            List<PlatProduit> PlatProd2 = new List<PlatProduit>();
            List<PlatProduit> PlatProd3 = new List<PlatProduit>();

            using (EntityPlatProduit db = new EntityPlatProduit())
            {
                db.Database.Delete();
                db.PlatProduitSet.AddRange(new PlatProduit[] { carotteRape, saucisse, lentille, saucisson });
                db.SaveChanges();

                foreach (var n in db.PlatProduitSet)
                {
                    if (lpp.Find(p => p.Nom == "carotteRapée").ID == n.idplat)
                    {
                        PlatProd1.Add(n);
                        //WriteLine(n.ToString());
                    }
                    if (lpp.Find(p => p.Nom == "lentilleSauc").ID == n.idplat)
                    {
                        PlatProd2.Add(n);
                        //WriteLine(n.ToString());
                    }
                    if (lpp.Find(p => p.Nom == "saucisson").ID == n.idplat)
                    {
                        PlatProd3.Add(n);
                        //WriteLine(n.ToString());
                    }
                }
                llpp.Add(PlatProd1);
                llpp.Add(PlatProd2);
                llpp.Add(PlatProd3);
                return llpp;
            }
        }

        public List<List<MenuPlat>> chargeAllMenuPlat(List<Menu> lm, List<Plat> lpp)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            //WriteLine("MenuPlat :");
            MenuPlat mP1 = new MenuPlat { idmenu = lm.Find(a => a.Nom=="Menu1").ID, idplat = lpp.Find(a => a.Nom== "lentilleSauc").ID, date = DateTime.Today };
            MenuPlat mP2 = new MenuPlat { idmenu = lm.Find(a => a.Nom == "Menu2").ID, idplat = lpp.Find(a => a.Nom == "carotteRapée").ID, date = DateTime.Today };
            MenuPlat mP3 = new MenuPlat { idmenu = lm.Find(a => a.Nom == "Menu3").ID, idplat = lpp.Find(a => a.Nom == "saucisson").ID, date = DateTime.Today };
            List<List<MenuPlat>> llmp = new List<List<MenuPlat>>();
            List<MenuPlat> lmp = new List<MenuPlat>();
            List<MenuPlat> lmp2 = new List<MenuPlat>();

            using (EntityMenuPlat db = new EntityMenuPlat())
            {
                db.Database.Delete();
                db.MenuPlatSet.AddRange(new MenuPlat[] { mP1, mP2, mP3 });
                db.SaveChanges();

                foreach (var n in db.MenuPlatSet)
                {
                    if (lm.Find(a => a.Nom == "Menu1").ID == n.idmenu)
                    {
                        lmp.Add(n);
                    }
                    if (lm.Find(a => a.Nom == "Menu2").ID == n.idmenu)
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
            Plat lentilleS = new Plat { Nom = "lentilleSauc", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Plat };
            Plat carotteRape = new Plat { Nom = "carotteRapée", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Entree };
            Plat saucissonE = new Plat { Nom = "saucisson", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Entree };
            List<Plat> lpp = new List<Plat>();
            using (EntityPlat db = new EntityPlat())
            {
                db.Database.Delete();
                db.PlatSet.AddRange(new Plat[] { lentilleS, carotteRape });
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
            Produit carotte = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "carotte", Observation = "", Categorie = CategorieProduit.Legume };
            Produit saucisse = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "saucisse", Observation = "", Categorie = CategorieProduit.Viande };
            Produit saucisson = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "saucisson", Observation = "", Categorie = CategorieProduit.Charcuterie };
            Produit lentille = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "lentille", Observation = "", Categorie = CategorieProduit.Legume };
            List<Produit> lp = new List<Produit>();

            using (EntityProduit db = new EntityProduit())
            {
                db.Database.Delete();
                db.ProduitSet.AddRange(new Produit[] { carotte, saucisse, saucisson, lentille });
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
