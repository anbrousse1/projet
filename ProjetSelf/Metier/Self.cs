using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Self
    {
        /// <summary>
        /// ReadOnlyCollection des menus de l'application qui encapsule la liste menus
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsMenu> menusROC
        {
            get;
            private set;
        } 
        /// <summary>
        /// Liste des menus
        /// </summary>                       
        private List<AbsMenu> menus = new List<AbsMenu>();

        /// <summary>
        /// ReadOnlyCollection des plats de l'application qui encapsule la liste plats
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat> platROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des plats
        /// </summary>
        private List<AbsPlat> plats = new List<AbsPlat>();

        /// <summary>
        /// ReadOnlyCollection des produits de l'application qui encapsule la liste produits
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsProduit> produitsROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des plats
        /// </summary>
        private List<AbsProduit> produits = new List<AbsProduit>();

        /// <summary>
        /// ReadOnlyCollection des usagers de l'application qui encapsule la liste usagers
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsUsager> usagerROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des usagers
        /// </summary>
       private List<AbsUsager> usager = new List<AbsUsager>();

        /// <summary>
        /// ReadOnlyCollection des usagers qui sont aussi utilisateur de l'application qui encapsule la liste usagers utilisateurs
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsUsager> usagerUtilisateurROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des usagers utilisateur
        /// </summary>
        private List<AbsUsager> usagerUtilisateur = new List<AbsUsager>();


        /// <summary>
        /// ReadOnlyCollection des utilisateur de l'application qui encapsule la liste utilisateur
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsUtilisateur> utilisateurROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des utilisateurs
        /// </summary>
        private List<AbsUtilisateur> utilisateur = new List<AbsUtilisateur>();



        /// <summary>
        /// ReadOnlyCollection des Entree du menu du jour qui encapsule la liste des entrées du jour
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat> entreeROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des entrées
        /// </summary>
        private List<AbsPlat> entrees = new List<AbsPlat>();


        /// <summary>
        /// ReadOnlyCollection des Entree du menu du jour qui encapsule la liste des entrées du jour
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat> dessertROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des entrées
        /// </summary>
        private List<AbsPlat> desserts = new List<AbsPlat>();


        /// <summary>
        /// ReadOnlyCollection des Plats du menu du jour qui encapsule la liste des plats du jour
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat> platsDuJourROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des entrées
        /// </summary>
        private List<AbsPlat> platsJour = new List<AbsPlat>();


        /// <summary>
        /// ReadOnlyCollection des Entree du menu du jour qui encapsule la liste des entrées du jour
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat> boissonROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des entrées
        /// </summary>
        private List<AbsPlat> boissons = new List<AbsPlat>();

        /// <summary>
        /// ReadOnlyCollections de plats choisis qui encapsule une liste de plats choisis par le client
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyDictionary<AbsPlat,int> platsChoisisROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste de plats choisis
        /// </summary>
        private Dictionary<AbsPlat,int> platsChoisis = new Dictionary<AbsPlat, int>();

        /// <summary>
        /// ReadOnlyCollection de date qui encapsule la liste des 2O prochaines dates disponible pour programmer un menu
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<DateTime> dateDispoROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Listes des 20 prochaines dates dispo
        /// </summary>
        private List<DateTime> dateDispo = new List<DateTime>();

        public System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat> allEntreesROC
        {
            get;
            private set;
        }
        private List<AbsPlat> allEntrees = new List<AbsPlat>();

        public System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat> allPlatsResROC
        {
            get;
            private set;
        }
        private List<AbsPlat> allPlatsRes = new List<AbsPlat>();

        public System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat> allDessertsROC
        {
            get;
            private set;
        }
        private List<AbsPlat> allDesserts = new List<AbsPlat>();

        public System.Collections.ObjectModel.ReadOnlyCollection<AbsRepas> histoRepasROC
        {
            get;
            private set;
        }
        
        private List<AbsRepas> histoRepas = new List<AbsRepas>();

        /// <summary>
        /// Liste qui encapsule repas
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsRepas> repasROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Cette liste est chargée des repas d'un usager
        /// </summary>
        private List<AbsRepas> repas = new List<AbsRepas>();

        private DateTime dateDuJour = DateTime.Today;
        public int DroitUtilisateur { get; private set; }
        public AbsUsager client;
        public AbsUsager caissier;
        public AbsMenu menuDuJour;
        public double prixAPayer;
        public IDataManager data;
        public string log;


        /// <summary>
        /// Constructeur de Self avec un IDataManager en paramètre
        /// </summary>
        /// <param name="stub"></param>
        public Self(IDataManager stub)
        {
            data = stub;
            menusROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsMenu>(menus);
            platROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(plats);
            produitsROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsProduit>(produits);
            usagerROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsUsager>(usager);
            usagerUtilisateurROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsUsager>(usagerUtilisateur);
            utilisateurROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsUtilisateur>(utilisateur);
            entreeROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(entrees);
            platsDuJourROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(platsJour);
            dessertROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(desserts);
            boissonROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(boissons);
            platsChoisisROC = new System.Collections.ObjectModel.ReadOnlyDictionary<AbsPlat,int>(platsChoisis);
            dateDispoROC = new System.Collections.ObjectModel.ReadOnlyCollection<DateTime>(dateDispo);
            allEntreesROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(allEntrees);
            allPlatsResROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(allPlatsRes);
            allDessertsROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(allDesserts);
            histoRepasROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsRepas>(histoRepas);
            repasROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsRepas>(repas);


            DroitUtilisateur = 0;

            chargeAll();

            dateDuJour = DateTime.Today;
           

            chargeBoisson();

            chargePlatJour();

        }

        /// <summary>
        /// Méthode pour tout charger
        /// </summary>
        public void chargeAll()
        {
            getAllUsager();
            getAllUtilisateur();
            getAllUsagerUtilisateur();
            getAllProduit();

            getAllPlatsIngre();
            getAllMenusPlats();
            

        }


        //Permet de modifier le tarif d'un plat
        public void modifierTarifPlat(AbsPlat p,double tarif)
        {
            p.modifierTarif(tarif);
        }


        /// <summary>
        /// Permet de modifier la liste des produits d'un plat
        /// </summary>
        /// <param name="p"></param>
        /// <param name="prods"></param>
        public void modifierProduitsPlat(AbsPlat p, List<AbsProduit> prods)
        {

            p.modifProduits(prods);
        }

        /// <summary>
        /// Permet de modifier les plats d'un menu
        /// </summary>
        /// <param name="m"></param>
        /// <param name="plats"></param>
        public void modifierPlatsMenu(AbsMenu m, List<AbsPlat> plats)
        {

            m.modifierPlats(plats);
        }



        /// <summary>
        /// Permet de changer la date de fin d'effet d'un produit
        /// </summary>
        /// <param name="prod"></param>
        /// <param name="fin"></param>
        public void changeDateFinProd(AbsProduit prod, DateTime fin)
        {
            prod.ChangerDateFin(fin);
            //BDD
        }

        /// <summary>
        /// Permet de changer la date départ d'effet d'un produit
        /// </summary>
        /// <param name="prod"></param>
        /// <param name="effet"></param>
        public void changeDateEffetProd(AbsProduit prod,DateTime effet){
            prod.ChangerDateEffet(effet);
            //BDD
        }

        /// <summary>
        /// Met à jour les dates d'effets des menus
        /// </summary>
        private void mAJDateMenus()
        {
            foreach(AbsMenu m in menus)
            {
                m.initDateEffet();
            }
        }


        /// <summary>
        /// Met à jour les dates d'effets des plats
        /// </summary>
        private void mAJDatePlat()
        {
            foreach (AbsPlat p in plats)
            {
                p.initDateEffet();
            }
        }

        /// <summary>
        /// Appel les méthodes qui mettent à jour les dates des menus et des plats 
        /// </summary>
        public void mAJDatePlatsEtMenu()
        {
            mAJDateMenus();
            mAJDatePlat();
        }


        /// <summary>
        /// Charge le plat du jour si il y en a un
        /// </summary>
        private void chargePlatJour()
        {
            menuDuJour = getMenu(dateDuJour);
            if (menuDuJour != null)
            {
                chargeDesserts();
                chargeEntrees();
                chargePlatsResistance();
            }
        }


        /// <summary>
        /// Ajoute un plat à la liste des plats choisis
        /// </summary>
        /// <param name="p"></param>
        public void AddPlatChoisis(AbsPlat p)
        {
            foreach (AbsRepas r in histoRepas)
            {
                if (r.Date.Date.CompareTo(DateTime.Now.Date)==0 && r.Date.Minute.CompareTo(DateTime.Now.Minute)==0 && r.Date.Second.CompareTo(DateTime.Now.Second) == 0)
                {
                    r.AddPlat(p);
                    return;
                }
            }
            AbsRepas re = new Repas();
            re.IdUsager = client.ID;
            re.IdCaissier = caissier.ID;
            re.Date = DateTime.Now;
            re.AddPlat(p);
            histoRepas.Add(re);
        }

        /// <summary>
        /// charge les plat d'un repas
        /// </summary>
        /// <param name="r"></param>
        public void chargePlatRepas(AbsRepas r)
        {
            platsChoisis.Clear();
            
            foreach(AbsPlatChoisis p in r.plats)
            {
                foreach(AbsPlat pl in plats)
                {
                    if(pl.ID == p.CodePlat)
                    {
                        if (platsChoisis.ContainsKey(pl))
                        {
                            platsChoisis[pl] += 1;
                        }else
                        {
                            platsChoisis.Add(pl, 1);
                        }

                    }
                }
            }
        }

        public void changeRepas(AbsRepas r)
        {
            r.plats.Clear();
            r.Prix = 0;
            foreach (KeyValuePair<AbsPlat, int> kvp in platsChoisis)
            {
                for (int i = 1; i <= kvp.Value; i++)
                {
                    r.AddPlat(kvp.Key);
                }
            }
        }

        /*public void lierList()
        {
            histoRepasROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsRepas>(histoRepas);
        }*/

        /// <summary>
        /// Retourne le menu correspondant à la date passé en paramètre
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private AbsMenu getMenu(DateTime d)
        {
            if (menus != null)
            {
                foreach (AbsMenu m in menus)
                {
                    if (m.dates.Contains(d))
                    {
                        return m;
                    }
                }
            }

            return null;
        }


        /// <summary>
        /// Charge tous les repas
        /// </summary>
        /// <returns></returns>
        public List<AbsRepas> getAllRepas()
        {
            return data.chargeAllRepasPlats();
        }

        /// <summary>
        /// 
        /// </summary>
        public void getAllMenusPlats()
        {
            menus.Clear();
            menus.AddRange(data.chargeAllMenuPlat(plats));
        }
      
        /// <summary>
        /// 
        /// </summary>
        public void getAllPlatsIngre()
        {
            plats.Clear();
            plats.AddRange(data.chargeAllPlatAvecIngred(produits));
        }

        /// <summary>
        /// Charge la liste de produits à partir des élements de la BDD
        /// </summary>
        public void getAllProduit()
        {
            produits.Clear();
            produits.AddRange(data.chargeAllProduits());
        }

        /// <summary>
        /// Charge la liste des usagers.
        /// </summary>
        public void getAllUsager()
        {
            usager.Clear();
            usager.AddRange(data.chargeAllUsager());
        }



        public void getAllUsagerUtilisateur()
        {
            usagerUtilisateur.Clear();
            foreach(AbsUsager u in usager)
            {
                foreach(AbsUtilisateur ut in utilisateur)
                {
                    if(u.ID == ut.ID)
                    {
                        usagerUtilisateur.Add(u);
                    }
                }
            }
        }

        /// <summary>
        /// Charge les utilisateurs
        /// </summary>
        public void getAllUtilisateur()
        {

            utilisateur.Clear();
            utilisateur.AddRange(data.chargeAllUtilisateur());
        }


        /// <summary>
        /// Permet d'obtenir la fonction d'un Utlisateur qui vient de se connecter
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private String getFonction(int code)
        {
            switch (code)
            {
                case 1: return "Caissier";
                case 2: return "Gerant";
                default: return "Cuisinier";
            }
        }


        /// <summary>
        /// méthode permettant à un utilisateur de se connecter
        /// </summary>
        /// <param name="login"></param>
        /// <param name="mdp"></param>
        public Boolean connexion(String login, String mdp)
        {
            foreach(AbsUtilisateur u in utilisateur)
            {
                if(login.Equals(u.Login)&& mdp.Equals(u.Password))
                {
                    foreach(AbsUsager usa in usager)
                    {
                        if (usa.ID == u.CodeUsager && usa.DateSortie.CompareTo(DateTime.Today)>=0)
                        {
                            DroitUtilisateur =usa.CodeFonction;
                            caissier = usa;
                            log = u.Login;
                            return true;
                        }
                    }
                }
            }
            return false;
        }



        /// <summary>
        /// méthode permattant à un utilisateur de se déconnecter 
        /// </summary>
        public void deconnexion()
        {
            DroitUtilisateur = 0;
        }


        /// <summary>
        /// Chnage le mot de passe d'un utilisateur
        /// </summary>
        /// <param name="mdp"></param>
        /// <param name="usa"></param>
        public void changerMdp(string mdp, AbsUsager usa)
        {
            foreach (AbsUtilisateur u in utilisateur)
            {
                if (u.CodeUsager.Equals(usa.ID))
                {
                    u.Password = mdp;
                }
            }
        }

        /// <summary>
        /// Permet de modifier la date de fin de contrat d'un Utilisateur
        /// </summary>
        /// <param name="u"></param>
        /// <param name="d"></param>
        public void modifierDateFinUtlisateur(AbsUsager u, DateTime d)
        {
            foreach(AbsUsager usa in usagerUtilisateur)
            {
                if (usa.ID.Equals(u.ID))
                {
                    usa.DateSortie = d;
                }
            }
        }

        /// <summary>
        /// Permet d'identifier un usager avec son numéro de carte
        /// </summary>
        public Boolean findUsager(string numeroCarte)
        {
            //return usager.Exists(u => u.NumCarte.ToString().Equals(numeroCarte));
            foreach (AbsUsager u in usager)
           {
                if (u.NumCarte.ToString().Equals(numeroCarte))
                {
                    client = u;
                    return true;
                }
           }
           return false;

        }


        /// <summary>
        /// Trouve un plat avec son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AbsPlat findPlatById(int id)
        {
            return plats.Find(a => a.ID == id);
        }


        /// <summary>
        /// Permet de recuperer la liste des entrees 
        /// </summary>
        /// <returns></returns>
        private void chargeEntrees()
        {
            List<AbsPlat> plats = menuDuJour.getPlats();
            foreach (AbsPlat p in plats)
            {
                if (p.Categorie.Equals(CategoriePlat.Entree))
                {
                    entrees.Add(p);
                }
            }
        }

        /// <summary>
        /// Charge boissons
        /// </summary>
       private void chargeBoisson()
        {
            foreach(AbsPlat p in plats)
            {
                if (p.Categorie.Equals(CategoriePlat.Boisson))
                {
                    boissons.Add(p);
                }
            }
        }

        /// <summary>
        /// Permet de recuperer la liste des plats de resistance
        /// </summary>
        private void chargePlatsResistance()
        {
            List<AbsPlat> plats = menuDuJour.getPlats();
            foreach (AbsPlat p in plats)
            {
                if (p.Categorie.Equals(CategoriePlat.Plat))
                {
                    platsJour.Add(p);
                }
            }
        }

        /// <summary>
        /// Permet de recuperer la liste des desserts
        /// </summary>
        private void chargeDesserts()
        {
            {
                List<AbsPlat> plats=menuDuJour.getPlats();
                foreach (AbsPlat p in plats)
                {
                    if (p.Categorie.Equals(CategoriePlat.Dessert))
                    {
                        desserts.Add(p);
                    }
                }
            }
        }



        /// <summary>
        /// Methode pour faire payer un usager
        /// </summary>
        public void paiement()
        {
          client.payer(prixAPayer);
            
        }




        /// <summary>
        /// Méthode qui permet d'obtenir la prochaine fois qu'un menu sera utlisé.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private DateTime getDatePlusProcheMenu(AbsMenu m)
        {
            DateTime d = m.dates.First();
            foreach(DateTime da in m.dates)
            {
                if (d.CompareTo(da) > 0)
                {
                    d = da;
                }
            }
            return d;
        }

        /// <summary>
        /// Méthode qui permet d'obtenir la date la plus lointaine à laquelle un menu sera utilisé.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private DateTime getDatePlusLointaineMenu(AbsMenu m)
        {
            DateTime d = m.dates.First();
            foreach (DateTime da in m.dates)
            {
                if (d.CompareTo(da) < 0)
                {
                    d = da;
                }
            }
            return d;
        }


        /// <summary>
        /// retourne à partir d'une chaine de caractère une instance de CategoriePlat
        /// </summary>
        /// <param name="cate"></param>
        /// <returns></returns>
        private CategoriePlat FindCategoriePlat(String cate)
        {
            switch (cate)
            {
                case "Entree": return CategoriePlat.Entree;
                case "Dessert": return CategoriePlat.Dessert;
                case "Boisson": return CategoriePlat.Boisson;
                default: return CategoriePlat.Plat;
            }
        }

        /// <summary>
        /// retourne à partir d'un string une instance de CategorieProduit
        /// </summary>
        /// <param name="cate"></param>
        /// <returns></returns>
        private CategorieProduit FindCategorieProduit(string cate)
        {
            switch (cate)
            {
                case "Poisson": return CategorieProduit.Poisson;
                case "Viande": return CategorieProduit.Viande;
                case "Legume": return CategorieProduit.Legume;
                case "Fruit": return CategorieProduit.Fruit;
                case "Feculent": return CategorieProduit.Feculent;
                case "Produit sucré": return CategorieProduit.ProduitSucre;
                case "Charcuterie": return CategorieProduit.Charcuterie;
                default: return CategorieProduit.Autres;
            }
        }
        /*
        /// <summary>
        /// Permet à partir d'une liste de string d'obtenir une liste de produits
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        private List<AbsProduit> FindProduits(List<String> prod)
        {
            List<AbsProduit> ingredients = new List<AbsProduit>();
            foreach (String s in prod)
            {
                ingredients.Add(FindProduit(s));
            }
            return ingredients;
        }*/


        /// <summary>
        /// Permet à partir d'un string d'obtenir un produit
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public AbsProduit findProduitByName(String prod)
        {
            //return produits.Find(p => p.Nom.Equals(prod));
            foreach (AbsProduit u in produits)
            {
                if (u.Nom.Equals(prod))
                {
                    return u;
                }
            }
            return null;
        }


        /// <summary>
        /// Permet de trouver un menu avec son nom
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public AbsMenu findMenuByName(String menu)
        {
            //return menus.Find(m => m.Nom.Equals(menu));
            foreach (AbsMenu u in menus)
            {
                if (u.Nom.Equals(menu))
                {
                    return u;
                }
            }
            return null;
        }

        /// <summary>
        /// Permet à partir d'un string d'obtenir un plat
        /// </summary>
        /// <param name="plat"></param>
        /// <returns></returns>
        public AbsPlat FindPlat(String plat)
        {
            //return plats.Find(p => p.Nom.Equals(plat));
            foreach (AbsPlat u in plats)
            {
                if (u.Nom.Equals(plat))
                {
                    return u;
                }
            }
            return null;
        }

        /// <summary>
        /// Permet à partir d'une liste de string d'obtenir une liste de plats
        /// </summary>
        /// <param name="plats"></param>
        /// <returns></returns>
        private List<AbsPlat> FindPlats(List<String> plats)
        {
            List<AbsPlat> platsMenu = new List<AbsPlat>();
            foreach (String s in plats)
            {
                platsMenu.Add(FindPlat(s));
            }
            return platsMenu;
        }


        /// <summary>
        /// Permet d'ajouter un plat
        /// </summary>
        /// <param name="effet"></param>
        /// <param name="fin"></param>
        /// <param name="nom"></param>
        /// <param name="tarif"></param>
        /// <param name="ingredients"></param>
        /// <param name="cate"></param>
        public void addplat(DateTime effet, DateTime fin,String nom, Double tarif, List<AbsProduit> ingredients, String cate)
        {

            Plat p = new Plat { Nom = nom, DateEffet = effet, DateFin = fin, Tarif = tarif, Categorie = FindCategoriePlat(cate), };
            data.ajouterPlat(p, ingredients);
            foreach(AbsProduit pro in ingredients)
            {
                p.addProduit(pro);
            }
            plats.Add(p);
        }

        /// <summary>
        /// Permet d'ajouter un Produit
        /// </summary>
        /// <param name="deb"></param>
        /// <param name="fin"></param>
        /// <param name="nom"></param>
        /// <param name="observation"></param>
        /// <param name="cate"></param>
        public void addProduit(DateTime deb, DateTime fin, String nom, String observation, String cate)
        {
            Produit p = new Produit { Nom = nom, Categorie = FindCategorieProduit(cate), DateEffet = deb, DateFin = fin, ID = produits.Count + 1, Observation = observation };
            data.ajouterProduit(p);
            produits.Add(p);
        }

        /// <summary>
        /// Permet d'ajouter un menu
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="lplats"></param>
        public void addMenu(String nom ,List<AbsPlat> lplats)
        {
            Menu m = new Menu { Nom = nom };
            data.ajouterMenu(m, lplats);
            foreach(AbsPlat p in lplats)
            {
                m.addPlat(p);
            }
            menus.Add(m);
        }

        /// <summary>
        /// Permet d'jouter un plat choisis
        /// </summary>
        /// <param name="plat"></param>
        public void AddPlatChoisi(String plat)
        {
            AbsPlat p = FindPlat(plat);
            if (p != null) {
                if (platsChoisis.ContainsKey(p))
                {
                    AugmenterQuantitePlat(p);
                }else
                {
                    platsChoisis.Add(p, 1);
                }
                
                prixAPayer = prixAPayer + p.Tarif;
                //client.AddPlatChoisis(p);
                //Ajouter à la BDD
            }
        }


        /// <summary>
        /// ajoute un plat choisi
        /// </summary>
        /// <param name="p"></param>
        public void AddPlatChoisi(AbsPlat p)
        {

            if (p != null)
            {
                if (platsChoisis.ContainsKey(p))
                {
                    AugmenterQuantitePlat(p);
                }
                else
                {
                    platsChoisis.Add(p, 1);
                }

                prixAPayer = prixAPayer + p.Tarif;
                //client.AddPlatChoisis(p);
                //Ajouter à la BDD
            }
        }
        /// <summary>
        /// Cette fonction permet de charger la liste de repas d'un usager
        /// </summary>
        /// <param name="u"></param>
        public void chargerHistoRepasUsager(AbsUsager u)
        {
            repas.Clear();
            foreach(AbsRepas r in histoRepas)
            {
                if(r.IdUsager == u.ID)
                {
                    repas.Add(r);
                }
            }
        }


        /// <summary>
        /// Permet de modifier le prix d'un plat
        /// </summary>
        /// <param name="plat"></param>
        /// <param name="nouveauTarif"></param>
        private void SetPrixPlat(String plat, double nouveauTarif)
        {
            AbsPlat p = FindPlat(plat);
            p.changerTarif(nouveauTarif);
            data.setPrixPlat(p, nouveauTarif);
        }

        /// <summary>
        /// methode pour modifier la date d'effet d'un plat
        /// </summary>
        /// <param name="plat"></param>
        /// <param name="newDateEffet"></param>
        private void setDateEffetPlat(String plat, DateTime newDateEffet)
        {
            AbsPlat p = FindPlat(plat);
            p.changerDateEffet(newDateEffet);
            data.setDateEffetPlat(p, newDateEffet);
        }

        /// <summary>
        /// methode pour modifier la date de fin d'un plat
        /// </summary>
        /// <param name="plat"></param>
        /// <param name="newDateFin"></param>
        private void setDateFinPlat(String plat, DateTime newDateFin)
        {
            AbsPlat p = FindPlat(plat);
            p.changerDateFin(newDateFin);
            data.setDateFinPlat(p, newDateFin);
        }

        /// <summary>
        /// methode pour modifier la date d'effet d'un produit 
        /// </summary>
        /// <param name="produit"></param>
        /// <param name="newDateEffet"></param>
        private void setDateEffetProduit(String produit, DateTime newDateEffet)
        {
            AbsProduit p = findProduitByName(produit);
            p.ChangerDateEffet(newDateEffet);
            data.setDateEffetProduit(p, newDateEffet);
        }

        /// <summary>
        /// methode pour modifier la date de fin d'un produit
        /// </summary>
        /// <param name="produit"></param>
        /// <param name="newDateFin"></param>
        private void setDateFinProduit(String produit, DateTime newDateFin)
        {
            AbsProduit p = findProduitByName(produit);
            p.ChangerDateFin(newDateFin);
            data.setDateFinProduit(p, newDateFin);
        }


        /// <summary>
        /// methode qui retourne la liste des plats dispo à la date du jour
        /// </summary>
        /// <returns></returns>
        private List<AbsPlat> GetPlatsDispo()
        {
            List<AbsPlat> platDispo = new List<AbsPlat>();
            foreach (AbsPlat p in plats)
            {
                if (p.DateEffet.CompareTo(DateTime.Today) >= 0 && p.DateFin.CompareTo(DateTime.Today) < 0)
                {
                    platDispo.Add(p);
                }
            }
            return platDispo;
        }


        /// <summary>
        /// methode qui retourne la liste des produits dispo à la date du jour
        /// </summary>
        /// <returns></returns>
        private List<AbsProduit> GetProduitsDispo()
        {
            List<AbsProduit> produitsDispo = new List<AbsProduit>();
            foreach (AbsProduit p in produits)
            {
                if (p.DateEffet.CompareTo(DateTime.Today) >= 0 && p.DateFin.CompareTo(DateTime.Today) < 0)
                {
                    produitsDispo.Add(p);
                }
            }
            return produitsDispo;
        }

        

        /// <summary>
        /// Methode pour connaitre les dates Dispo
        /// </summary>
        /// <param name="d">date</param>
        /// <returns>true si il y a déja un menu a la date donnée en paramètre sinon retourne faux</returns>
        public Boolean dateMenuDispo(DateTime d)
        {
            foreach(Menu m in menus)
            {
                foreach(DateTime da in m.dates)
                {
                    if (d.Equals(da))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// méthode qui supprime un plats des plats choisis par le client
        /// </summary>
        /// <param name="p"></param>
        public void supprimerPlatChoisis(AbsPlat p)
        {
            platsChoisis.Remove(p);
            prixAPayer = prixAPayer-p.Tarif;
        }


        /// <summary>
        /// supprime un plat
        /// </summary>
        /// <param name="p"></param>
        public void supprimerPlat(AbsPlat p)
        {
            plats.Remove(p);
        }


        /// <summary>
        /// Méthode qui permet d'incrementer la quantite d'nu plat choisis par le client
        /// </summary>
        /// <param name="p"></param>
        public void AugmenterQuantitePlat(AbsPlat p)
        {
            platsChoisis[p] += 1;
            prixAPayer = prixAPayer + p.Tarif;
        }


        /// <summary>
        /// Méthode qui permet de décrementer la quantité d'un plat choisis par le client
        /// </summary>
        /// <param name="p"></param>
        public void DiminuerQuantitePlat(AbsPlat p)
        {
            if(platsChoisis[p]<=1)
            {
                supprimerPlatChoisis(p);
            }
            platsChoisis[p] -= 1;
            prixAPayer = prixAPayer - p.Tarif;
        }

        /// <summary>
        /// Méthode pour supprimer tous les plats choisis
        /// </summary>
        public void supprimerAllPlatsChoisis()
        {
            platsChoisis.Clear();
            prixAPayer = 0;
        }

        /// <summary>
        /// Retourne vrai si un produit a déja ce nom sinon faux
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public Boolean produitExistant(string nom)
        {
            foreach(AbsProduit p in produits)
            {
                if (p.Nom.Equals(nom))
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Verfifie si un plat existe 
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public Boolean platExistant(String nom)
        {
            foreach(AbsPlat p in plats)
            {
                if (p.Nom.Equals(nom))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Permet de charger les 20 prochaines dates sans menu
        /// </summary>
        public void chargeDateDispo()
        {
            int i;
            for (i = 0; dateDispo.Count < 20; i++)
            { 
                if (dateMenuDispo(DateTime.Today.AddDays(i)) && !dateDispo.Contains(DateTime.Today.AddDays(i)))
                {
                    dateDispo.Add(DateTime.Today.AddDays(i));
                }
            }
        }

        /// <summary>
        /// Ajoute une date à la liste de date d'un menu
        /// </summary>
        /// <param name="m"></param>
        /// <param name="date"></param>
        public void addDateToMenu(AbsMenu m, DateTime date)
        {
            m.dates.Add(date);
            data.addDateToMenu(m, date);
            dateDispo.Remove(date);
            chargeDateDispo();
            chargePlatJour();
        }

        /// <summary>
        /// Charge liste des entrées, plats et desserts 
        /// </summary>
        public void chargeEntrPlatDes()
        {
            foreach(AbsPlat p in plats)
            {
                if (p.Categorie.Equals(CategoriePlat.Dessert))
                {
                    allDesserts.Add(p);
                }
                if (p.Categorie.Equals(CategoriePlat.Entree))
                {
                    allEntrees.Add(p);
                }
                if (p.Categorie.Equals(CategoriePlat.Plat))
                {
                    allPlatsRes.Add(p);
                }
            }
        }

      
        /// <summary>
        /// ajoute un usager
        /// </summary>
        /// <param name="titre"></param>
        /// <param name="fonction"></param>
        /// <param name="codeFonction"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="entree"></param>
        /// <param name="fin"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int addUsager(string titre, string fonction, int codeFonction, string nom, string prenom, DateTime entree, DateTime fin, int code) 
        {
            Usager u = new Usager { CodePaiement = code, Nom = nom, Prenom = prenom, CodeFonction = codeFonction, DateEntree = entree, DateSortie = fin, Titre = titre, ID = usager.Count + 1, Service = "Restaurant", Solde = 0, Fonction = fonction, NumCarte = usager.Count + 1 };
            usager.Add(u);
            usagerUtilisateur.Add(u);
            data.ajouterUsager(u);
            return usager.Count;
        }

        /// <summary>
        /// Ajoute un utilisateur
        /// </summary>
        /// <param name="mdp"></param>
        /// <param name="login"></param>
        /// <param name="id"></param>
        /// <param name="idu"></param>
        public void addUtilisateur(string mdp, string login, int id,int idu )
        {
            Utilisateur u = new Utilisateur { ID = id, Login = login, Password = mdp, CodeUsager = idu};
            utilisateur.Add(u);
            data.ajouterUtilisateur(u);
        }

        /// <summary>
        /// Appellé à la fin du passage de l'usager en caisse
        /// </summary>
        public void finPassage()
        {
            paiement();
            foreach(KeyValuePair<AbsPlat,int> kvp in platsChoisis)
            {
                for(int i = 1; i <= kvp.Value; i++)
                {
                    AddPlatChoisis(kvp.Key);
                }
            }
            prixAPayer = 0;
            client = null;
            platsChoisis.Clear();
        }


        /// <summary>
        /// charge repas dans plats choisis
        /// </summary>
        /// <param name="r"></param>
        public void chargeRepaInPlatsChoisi(AbsRepas r)
        {
            platsChoisis.Clear();
            foreach(AbsPlatChoisis pc in r.plats)
            {
                foreach(AbsPlat p in plats)
                {
                    if(p.ID== pc.CodePlat)
                    {
                        AddPlatChoisi(p);
                    }
                }
            }
        }

        /// <summary>
        /// supprime produit
        /// </summary>
        /// <param name="p"></param>
        public void supprimerProduit(AbsProduit p)
        {
            produits.Remove(p);
        }

        /// <summary>
        /// supprime un menu
        /// </summary>
        /// <param name="m"></param>
        public void supprimerMenu(AbsMenu m)
        {
            menus.Remove(m);
        }

        public Boolean menuSupprimable(AbsMenu m)
        {
            return(m.supprimable());
        }

        public Boolean platSupprimable(AbsPlat p)
        {
            foreach(AbsMenu m in menus)
            {
                if (m.containsPlat(p)) { return false; }
            }
            return true;
        }

        public Boolean produitSupprimable(AbsProduit p)
        {
            foreach(AbsPlat pl in plats)
            {
                if (pl.containsProd(p)) { return false; }
            }
            return true;
        }
    }
}


