using System;
using System.Collections.Generic;
using Metier;
using System.IO;
using System.Linq;

namespace Persistance
{
    public class EntityDataManager : IDataManager
    {

        public List<AbsMenu> chargeAllMenu()
        {

            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            Menu m = new Menu { Nom = "Menu1" };
            Menu m2 = new Menu { Nom = "Menu2" };
            List<AbsMenu> lm = new List<AbsMenu>();

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

        public List<AbsPlat> chargeAllPlatAvecIngred(List<AbsProduit> lp)
        {
            List<AbsPlat> lpp = new List<AbsPlat>();
            lpp = chargeAllPlats();
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            PlatProduit carotteRape = new PlatProduit { idplat = lpp.Find(p => p.Nom == "carotteRape").ID, idproduit = lp.Find(p => p.Nom == "carotte").ID };
            PlatProduit saucisse = new PlatProduit { idplat = lpp.Find(p => p.Nom == "lentilleSauc").ID, idproduit = lp.Find(p => p.Nom == "saucisse").ID };
            PlatProduit lentille = new PlatProduit { idplat = lpp.Find(p => p.Nom == "lentilleSauc").ID, idproduit = lp.Find(p => p.Nom == "lentille").ID };
            PlatProduit saucisson = new PlatProduit { idplat = lpp.Find(p => p.Nom == "saucisson").ID, idproduit = lp.Find(p => p.Nom == "saucisson").ID };
            List<List<PlatProduit>> llpp = new List<List<PlatProduit>>();
            List<PlatProduit> PlatProd = new List<PlatProduit>();

            using (EntityPlatProduit db = new EntityPlatProduit())
            {
                if (db.PlatProduitSet.Count() > 0)
                {
                    db.Database.Delete();
                }
                db.PlatProduitSet.AddRange(new PlatProduit[] { carotteRape, saucisse, lentille, saucisson });
                db.SaveChanges();

                foreach (var p in lpp)
                {
                    foreach (var n in db.PlatProduitSet)
                    {
                        if (p.ID == n.idplat)
                        {
                            PlatProd.Add(n);
                        }
                    }
                    llpp.Add(new List<PlatProduit>(PlatProd));
                    PlatProd.Clear();
                }
            }
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
            return lpp;
        }

        public List<AbsMenu> chargeAllMenuPlat(List<AbsPlat> lpp)
        {
            List<AbsMenu> lm = new List<AbsMenu>();
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

            using (EntityMenuPlat db = new EntityMenuPlat())
            {
                if (db.MenuPlatSet.Count() > 0)
                {
                    db.Database.Delete();
                }
                db.MenuPlatSet.AddRange(new MenuPlat[] { mP1, mP2, mP3, mP4, mP5, mP6 });
                db.SaveChanges();

                foreach (var m in lm)
                {
                    foreach (var n in db.MenuPlatSet)
                    {
                        if(m.ID == n.idmenu)
                        {
                            lmp.Add(n);
                        }
                    }
                    llmp.Add(new List<MenuPlat>(lmp));
                    lmp.Clear();
                }
            }
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
                                    //t.dates.Add(v.DateEffet);
                                }
                            }
                        }
                    }
                }
            }
            return lm;
        }

        public List<AbsPlat> chargeAllPlats()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            Plat lentilleS = new Plat { ID=1 ,Nom = "lentilleSauc", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Plat };
            Plat carotteRape = new Plat { ID = 2, Nom = "carotteRape", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Entree };
            Plat saucissonE = new Plat { ID = 3, Nom = "saucisson", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 10000, Categorie = CategoriePlat.Entree };
            Plat biere = new Plat { ID = 4, Nom = "biere", DateEffet = DateTime.Today, DateFin = DateTime.Today, Tarif = 2, Categorie = CategoriePlat.Boisson };
            List<AbsPlat> lpp = new List<AbsPlat>();
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

        public List<AbsProduit> chargeAllProduits()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            Produit carotte = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "carotte", Observation = "Ca fait grandir", Categorie = CategorieProduit.Legume };
            Produit saucisse = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "saucisse", Observation = "Ca fait grossir", Categorie = CategorieProduit.Viande };
            Produit saucisson = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "saucisson", Observation = "Ca fait grossir", Categorie = CategorieProduit.Charcuterie };
            Produit lentille = new Produit { DateEffet = DateTime.Today, DateFin = DateTime.Today, Nom = "lentille", Observation = "La maman de Yohann", Categorie = CategorieProduit.Legume };
            List<AbsProduit> lp = new List<AbsProduit>();

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

        public List<AbsUsager> chargeAllUsager()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            Usager bastien = new Usager { Nom = "Gandboeuf", Prenom = "Bastien", CodeFonction = 1,
                DateEntree = DateTime.Today, DateSortie = DateTime.Today, Service = "Restaurant", Titre = "Monsieur", codePaiement = 0,
                Solde = 25, numCarte = 1, Fonction = "Caissier"};
            Usager leandre = new Usager {Nom = "Perrot", Prenom = "Leandre", CodeFonction = 2,
                DateEntree = DateTime.Today, DateSortie = DateTime.Today, Service = "Restaurant", Titre = "Monsieur", codePaiement = 1,
                Solde = 78, numCarte = 2, Fonction = "Gérant" };

            List<AbsUsager> lu = new List<AbsUsager>();

            using (EntityUsager db = new EntityUsager())
            {
                if (db.UsagerSet.Count() > 0)
                {
                    db.Database.Delete();
                }

                db.UsagerSet.AddRange(new Usager[] {bastien,leandre});
                db.SaveChanges();
                
                foreach (var n in db.UsagerSet)
                {
                    lu.Add(n);

                }
            }
            return lu;
        }

        public List<AbsUtilisateur> chargeAllUtilisateur()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory());

            Utilisateur bastien = new Utilisateur {Login = "bagandboeu", Password = "1234" };
            Utilisateur leandre = new Utilisateur {Login = "leperrot", Password = "1234" };

            List<AbsUtilisateur> lu = new List<AbsUtilisateur>();

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

        public void ajouterPlat(Plat p, List<AbsProduit> lp)
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

        public void ajouterMenu(Menu p, List<AbsPlat> lp)
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
                    db.MenuPlatSet.Add(new MenuPlat { idmenu = p.ID, idplat = s.ID, date = DateTime.Today });
                }
                db.SaveChanges();
                
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
