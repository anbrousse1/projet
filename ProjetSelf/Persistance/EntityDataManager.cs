using System;
using System.Collections.Generic;
using Metier;
using System.IO;
using System.Linq;

namespace Persistance
{
    public class EntityDataManager : IDataManager
    {

        public List<Menu> chargeAllMenu()
        {

            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            Menu m = new Menu { Nom = "Menu1" };
            Menu m2 = new Menu { Nom = "Menu2" };
            List<Menu> lm = new List<Menu>();

            using (EntityMenu db = new EntityMenu())
            {
                
                if( db.MenuSet.Count() > 0)
                {
                    db.Database.Delete();
                }
                db.MenuSet.AddRange(new Menu[] { m, m2 });
                db.SaveChanges();

                foreach (var n in db.MenuSet)
                {
                    lm.Add(n);
                }
            }
            return lm;
        }

        public List<Plat> chargeAllPlatAvecIngred(List<Produit> lp)
        {
            List<Plat> lpp = new List<Plat>();
            lpp = chargeAllPlats();
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            PlatProduit carotteRape = new PlatProduit { idplat = lpp.Find(p => p.Nom == "carotteRape").ID, idproduit = lp.Find(p => p.Nom == "carotte").ID };
            PlatProduit saucisse = new PlatProduit { idplat = lpp.Find(p => p.Nom == "lentilleSauc").ID, idproduit = lp.Find(p => p.Nom == "saucisse").ID };
            PlatProduit lentille = new PlatProduit { idplat = lpp.Find(p => p.Nom == "lentilleSauc").ID, idproduit = lp.Find(p => p.Nom == "lentille").ID };
            PlatProduit saucisson = new PlatProduit { idplat = lpp.Find(p => p.Nom == "saucisson").ID, idproduit = lp.Find(p => p.Nom == "saucisson").ID };
            List<List<PlatProduit>> llpp = new List<List<PlatProduit>>();
            List<PlatProduit> PlatProd1 = new List<PlatProduit>();
            List<PlatProduit> PlatProd2 = new List<PlatProduit>();
            List<PlatProduit> PlatProd3 = new List<PlatProduit>();

            using (EntityPlatProduit db = new EntityPlatProduit())
            {
                if (db.PlatProduitSet.Count() > 0)
                {
                    db.Database.Delete();
                }
                db.PlatProduitSet.AddRange(new PlatProduit[] { carotteRape, saucisse, lentille, saucisson });
                db.SaveChanges();

                foreach (var n in db.PlatProduitSet)
                {
                    if (lpp.Find(p => p.Nom == "carotteRape").ID == n.idplat)
                    {
                        PlatProd1.Add(n);
                    }
                    if (lpp.Find(p => p.Nom == "lentilleSauc").ID == n.idplat)
                    {
                        PlatProd2.Add(n);
                    }
                    if (lpp.Find(p => p.Nom == "saucisson").ID == n.idplat)
                    {
                        PlatProd3.Add(n);
                    }
                }
                llpp.Add(PlatProd1);
                llpp.Add(PlatProd2);
                llpp.Add(PlatProd3);
                foreach (var t in lpp)
                {
                    foreach (var n in llpp)
                    {
                        foreach (var b in n)
                        {
                            if (b.idplat == t.ID)
                            {
                                foreach (var v in lp)
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
            }
            return lpp;
        }

        public List<Menu> chargeAllMenuPlat(List<Plat> lpp)
        {
            List<Menu> lm = new List<Menu>();
            lm = chargeAllMenu();
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            MenuPlat mP1 = new MenuPlat { idmenu = lm.Find(a => a.Nom == "Menu1").ID, idplat = lpp.Find(a => a.Nom == "lentilleSauc").ID, date = DateTime.Today };
            MenuPlat mP2 = new MenuPlat { idmenu = lm.Find(a => a.Nom == "Menu1").ID, idplat = lpp.Find(a => a.Nom == "carotteRape").ID, date = DateTime.Today };
            MenuPlat mP3 = new MenuPlat { idmenu = lm.Find(a => a.Nom == "Menu2").ID, idplat = lpp.Find(a => a.Nom == "saucisson").ID, date = DateTime.Today };
            MenuPlat mP4 = new MenuPlat { idmenu = lm.Find(a => a.Nom == "Menu2").ID, idplat = lpp.Find(a => a.Nom == "lentilleSauc").ID, date = DateTime.Today };
            MenuPlat mP5 = new MenuPlat { idmenu = lm.Find(a => a.Nom == "Menu1").ID, idplat = lpp.Find(a => a.Nom == "biere").ID, date = DateTime.Today };
            MenuPlat mP6 = new MenuPlat { idmenu = lm.Find(a => a.Nom == "Menu2").ID, idplat = lpp.Find(a => a.Nom == "biere").ID, date = DateTime.Today };
            List<List<MenuPlat>> llmp = new List<List<MenuPlat>>();
            List<MenuPlat> lmp = new List<MenuPlat>();
            List<MenuPlat> lmp2 = new List<MenuPlat>();

            using (EntityMenuPlat db = new EntityMenuPlat())
            {
                if (db.MenuPlatSet.Count() > 0)
                {
                    db.Database.Delete();
                }
                db.MenuPlatSet.AddRange(new MenuPlat[] { mP1, mP2, mP3,mP4,mP5,mP6 });
                db.SaveChanges();

                foreach (var n in db.MenuPlatSet)
                {
                    if (lm.Find(a => a.Nom == "Menu1").ID == n.idmenu)
                    {
                        lmp.Add(n);
                    }
                    if (lm.Find(a => a.Nom == "Menu2").ID == n.idmenu)
                    {
                        lmp2.Add(n);
                    }
                }
            }
            llmp.Add(lmp);
            llmp.Add(lmp2);
            foreach (var t in lm)
            {
                foreach (var n in llmp)
                {
                    foreach (var b in n)
                    {
                        if (b.idmenu == t.ID)
                        {
                            foreach (var v in lpp)
                            {
                                if (v.ID == b.idplat)
                                {
                                    t.plats.Add(v);
                                    t.dates.Add(v.DateEffet);
                                }
                            }
                        }
                    }
                }
            }
            return lm;
        }

        public List<Plat> chargeAllPlats()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            Plat lentilleS = new Plat { ID=1 ,Nom = "lentilleSauc", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Plat };
            Plat carotteRape = new Plat { ID = 2, Nom = "carotteRape", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Entree };
            Plat saucissonE = new Plat { ID = 3, Nom = "saucisson", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Entree };
            Plat biere = new Plat { ID = 4, Nom = "biere", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 2, Categorie = CategoriePlat.Boisson };
            List<Plat> lpp = new List<Plat>();
            using (EntityPlat db = new EntityPlat())
            {
                if (db.PlatSet.Count() > 0)
                {
                    db.Database.Delete();
                }
                db.PlatSet.AddRange(new Plat[] { lentilleS, carotteRape, saucissonE, biere });
                db.SaveChanges();

                foreach (var n in db.PlatSet)
                {
                    lpp.Add(n);
                }
            }

            return lpp;
        }

        public List<Produit> chargeAllProduits()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            Produit carotte = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "carotte", Observation = "", Categorie = CategorieProduit.Legume };
            Produit saucisse = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "saucisse", Observation = "", Categorie = CategorieProduit.Viande };
            Produit saucisson = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "saucisson", Observation = "", Categorie = CategorieProduit.Charcuterie };
            Produit lentille = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "lentille", Observation = "", Categorie = CategorieProduit.Legume };
            List<Produit> lp = new List<Produit>();

            using (EntityProduit db = new EntityProduit())
            {
                if (db.ProduitSet.Count() > 0)
                {
                    db.Database.Delete();
                }
                db.ProduitSet.AddRange(new Produit[] { carotte, saucisse, saucisson, lentille });
                db.SaveChanges();

                foreach (var n in db.ProduitSet)
                {
                    lp.Add(n);

                }
            }
            return lp;
        }

        public List<Usager> chargeAllUsager()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            Usager bastien = new Usager {Nom = "Gandboeuf", Prenom = "Bastien", CodeFonction = 1,
                DateEntree = DateTime.Today, Service = "Restaurant", Titre = "Monsieur", algoDePaiement = new PreAlimente(),
                Solde = 25, carte = new Carte(12), Fonction = "Caissier"};
            Usager leandre = new Usager {Nom = "Perrot", Prenom = "Leandre", CodeFonction = 2,
                DateEntree = DateTime.Today, Service = "Restaurant", Titre = "Monsieur", algoDePaiement = new PreAlimente(),
                Solde = 78, carte = new Carte(15), Fonction = "Gérant" };

            List<Usager> lu = new List<Usager>();

            using (EntityUsager db = new EntityUsager())
            {
                if (db.UsagerSet.Count() > 0)
                {
                    db.Database.Delete();
                }

                db.UsagerSet.AddRange(new Usager[] {bastien,leandre});
                try
                {
                    db.SaveChanges();
                }catch(Exception e)
                {
                    e.GetBaseException();
                }
                

                foreach (var n in db.UsagerSet)
                {
                    lu.Add(n);

                }
            }
            return lu;
        }

        public List<Utilisateur> chargeAllUtilisateur()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            Utilisateur bastien = new Utilisateur {Login = "bagandboeu", Password = "1234" };
            Utilisateur leandre = new Utilisateur {Login = "leperrot", Password = "1234" };

            List<Utilisateur> lu = new List<Utilisateur>();

            using (EntityUtilisateur db = new EntityUtilisateur())
            {
                if (db.UtilisateurSet.Count() > 0)
                {
                    db.Database.Delete();
                }
                
                db.UtilisateurSet.AddRange(new Utilisateur[] { bastien, leandre });
                db.SaveChanges();
                
                foreach (var n in db.UtilisateurSet)
                {
                    lu.Add(n);

                }
            }
            return lu;
        }
        
        public void ajouterProduit(Produit p)
        {
            using (EntityProduit db = new EntityProduit())
            {
                db.ProduitSet.Add(p);
                db.SaveChanges();
            }
        }

        public void ajouterPlat(Plat p, List<Produit> lp)
        {
            using (EntityPlat db = new EntityPlat())
            {
                db.PlatSet.Add(p);
                db.SaveChanges();
            }

            using(EntityPlatProduit db = new EntityPlatProduit())
            {
                foreach (var s in lp)
                {
                    db.PlatProduitSet.Add(new PlatProduit { idplat = p.ID, idproduit = s.ID });
                }
                db.SaveChanges();
            }
        }

        public void ajouterMenu(Menu p, List<Plat> lp)
        {
            using (EntityMenu db = new EntityMenu())
            {
                db.MenuSet.Add(p);
                db.SaveChanges();
            }

            using (EntityMenuPlat db = new EntityMenuPlat())
            {
                foreach (var s in lp)
                {
                    db.MenuPlatSet.Add(new MenuPlat { idmenu = p.ID , idplat = s.ID });
                }
                //exception bizarre ici...
                try
                {
                    db.SaveChanges();
                }catch(Exception e)
                {
                    e.GetBaseException();
                }
                
            }
        }

        public void ajouterUtilisateur(Utilisateur p)
        {
            using (EntityUtilisateur db = new EntityUtilisateur())
            {
                db.UtilisateurSet.Add(p);
                db.SaveChanges();
            }
        }

        public void ajouterUsager(Usager p)
        {
            using (EntityUsager db = new EntityUsager())
            {
                db.UsagerSet.Add(p);
                db.SaveChanges();
            }
        }
    }
}
