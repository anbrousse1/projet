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
        public System.Collections.ObjectModel.ReadOnlyCollection<Menu> menusROC
        {
            get;
            private set;
        } 
        /// <summary>
        /// Liste des menus
        /// </summary>                       
        private List<Menu> menus = new List<Menu>();

        /// <summary>
        /// ReadOnlyCollection des plats de l'application qui encapsule la liste plats
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<Plat> platROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des plats
        /// </summary>
        private List<Plat> plats = new List<Plat>();

        /// <summary>
        /// ReadOnlyCollection des produits de l'application qui encapsule la liste produits
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<Produit> produitsROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des plats
        /// </summary>
        private List<Produit> produits = new List<Produit>();

        /// <summary>
        /// ReadOnlyCollection des usagers de l'application qui encapsule la liste usagers
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<Usager> usagerROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des usagers
        /// </summary>
        private List<Usager> usager = new List<Usager>();


        /// <summary>
        /// ReadOnlyCollection des utilisateur de l'application qui encapsule la liste utilisateur
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<Utilisateur> utilisateurROC
        {
            get;
            private set;
        }
        /// <summary>
        /// Liste des utilisateurs
        /// </summary>
        private List<Utilisateur> utilisateur = new List<Utilisateur>();



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


        private DateTime dateDuJour = DateTime.Today;
        public String DroitUtilisateur { get; private set; }
        private AbsUsager client;
        public AbsMenu menuDuJour;
        public double prixAPayer;
        public IDataManager data;


        /// <summary>
        /// Constructeur de Self avec un IDataManager en paramètre
        /// </summary>
        /// <param name="stub"></param>
        public Self(IDataManager stub)
        {
            data = stub;
            menusROC = new System.Collections.ObjectModel.ReadOnlyCollection<Menu>(menus);
            platROC = new System.Collections.ObjectModel.ReadOnlyCollection<Plat>(plats);
            produitsROC = new System.Collections.ObjectModel.ReadOnlyCollection<Produit>(produits);
            usagerROC = new System.Collections.ObjectModel.ReadOnlyCollection<Usager>(usager);
            utilisateurROC = new System.Collections.ObjectModel.ReadOnlyCollection<Utilisateur>(utilisateur);
            entreeROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(entrees);
            platsDuJourROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(platsJour);
            dessertROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(desserts);
            boissonROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(boissons);
            platsChoisisROC = new System.Collections.ObjectModel.ReadOnlyDictionary<AbsPlat,int>(platsChoisis);
            DroitUtilisateur = null;

            chargeAll();

            dateDuJour = DateTime.Today;
            menuDuJour = getMenu(dateDuJour);

            if (menuDuJour != null)
            {
                chargeBoisson();
                chargeDesserts();
                chargeEntrees();
                chargePlatsResistance();
            }

        }




        /// <summary>
        /// Méthode pour tout charger
        /// </summary>
        public void chargeAll()
        {
            getAllUsager();
            getAllUtilisateur();
            getAllProduit();
            getAllPlats();
            List<Plat> lp = data.chargeAllPlatAvecIngred(plats, produits);
            plats.Clear();
            plats.AddRange(lp);

            getAllMenus();
            List<Menu> lm = data.chargeAllMenuPlat(menus, plats);
            menus.Clear();
            menus.AddRange(menus);

        }

        /// <summary>
        /// Retourne le menu correspondant à la date passé en paramètre
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private AbsMenu getMenu(DateTime d)
        {
            if (menus != null)
            {
                foreach (Menu m in menus)
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
        /// Charge la liste de menus à partir des élements de la BDD
        /// </summary>
        public void getAllMenus()
        {
            menus.Clear();
            menus.AddRange(data.chargeAllMenu());
        }


        /// <summary>
        /// Charge la liste de plats à partir des élements de la BDD
        /// </summary>
        public void getAllPlats()
        {
            plats.Clear();
            plats.AddRange(data.chargeAllPlats());
        }

        /// <summary>
        /// Charge la liste de produits à partir des élements de la BDD
        /// </summary>
        public void getAllProduit()
        {
            //recuperer dans BDD
            produits.Clear();
            produits.AddRange(data.chargeAllProduits());
        }

        /// <summary>
        /// Charge la liste des usagers.
        /// </summary>
        public void getAllUsager()
        {
            //recuperer dans BDD
            usager.Clear();
            usager.AddRange(data.chargeAllUsager());
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
        /// méthode permettant à un utilisateur de se connecter
        /// </summary>
        /// <param name="login"></param>
        /// <param name="mdp"></param>
        public Boolean connexion(String login, String mdp)
        {
            foreach(AbsUtilisateur u in utilisateur)
            {
                Console.WriteLine("self "+u.Login + " " + u.Password);
                if(login.Equals(u.Login)&& mdp.Equals(u.Password))
                {
                    foreach(AbsUsager usa in usager)
                    {
                        if (usa.ID == u.ID)
                        {
                            DroitUtilisateur = usa.Fonction;
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
            DroitUtilisateur = null;
        }



        /// <summary>
        /// Permet d'identifier un usager avec son numéro de carte
        /// </summary>
        private void FindUsager(int numeroCarte)
        {
            foreach(AbsUsager u in usager)
            {
                if (u.carte.Numero == numeroCarte)
                {
                   client= u;
                }
            }
        }



        /// <summary>
        /// Permet de recuperer la liste des entrees 
        /// </summary>
        /// <returns></returns>
        private void chargeEntrees()
        {
            foreach (AbsPlat p in menuDuJour.plats)
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
            foreach (AbsPlat p in menuDuJour.plats)
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
                foreach (AbsPlat p in menuDuJour.plats)
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
        public void Paiement()
        {
            client.payer(prixAPayer);
            //Modif BDD
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
                default: return CategorieProduit.Boisson;
            }
        }

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
        }


        /// <summary>
        /// Permet à partir d'un string d'obtenir un produit
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        private AbsProduit FindProduit(String prod)
        {
            foreach (AbsProduit p in produits)
            {
                if (p.Nom.Equals(prod))
                {
                    return p;
                }
            }
            return null;
        }

        /// <summary>
        /// Permet à partir d'un string d'obtenir un plat
        /// </summary>
        /// <param name="plat"></param>
        /// <returns></returns>
        private AbsPlat FindPlat(String plat)
        {
            foreach (AbsPlat p in plats)
            {
                if (p.Nom.Equals(plat))
                {
                    return p;
                }
            }
            return null;
        }

        //Permet à partir d'une liste de string d'obtenir une liste de plats
        private List<AbsPlat> FindPlats(List<String> plats)
        {
            List<AbsPlat> platsMenu = new List<AbsPlat>();
            foreach (String s in plats)
            {
                platsMenu.Add(FindPlat(s));
            }
            return platsMenu;
        }

        //Permet d'ajouter un Plat
        private void Addplat(DateTime debut, DateTime fin, String nom, Double tarif, List<String> ingredientString, String cate)
        {
            //plats.Add(new Plat(plats.Count + 1, debut, fin, nom, tarif, FindProduits(ingredientString), FindCategoriePlat(cate)));
            //Ajouter dans BDD
        }

        //Permet d'ajouter un Produit
        private void AddProduit(int code, DateTime deb, DateTime fin, String nom, String observation, String cate)
        {
           // produits.Add(new Produit(code, deb, fin, nom, observation, FindCategorieProduit(cate)));
            //Ajouter dans BDD
        }

        //Permet d'ajouter un menu
        private void AddMenu(int code, List<String> plats)
        {
            //menus.Add(new Menu(code, FindPlats(plats)));
            //Ajouter dans BDD
        }

        //Permet d'jouter un plat choisis
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

        //Permet de modifier le prix d'un plat
        private void SetPrixPlat(String plat, double nouveauTarif)
        {
            FindPlat(plat).changerTarif(nouveauTarif);
        }

        //methode pour modifier la date d'effet d'un plat
        private void setDateEffetPlat(String plat, DateTime newDateEffet)
        {
            FindPlat(plat).ChangerDateEffet(newDateEffet);
        }

        //methode pour modifier la date de fin d'un plat
        private void setDateFinPlat(String plat, DateTime newDateFin)
        {
            FindPlat(plat).ChangerDateFin(newDateFin);
        }

        //methode pour modifier la date d'effet d'un produit 
        private void setDateEffetProduit(String produit, DateTime newDateEffet)
        {
            FindProduit(produit).ChangerDateEffet(newDateEffet);
        }

        //methode pour modifier la date de fin d'un produit
        private void setDateFinProduit(String produit, DateTime newDateFin)
        {
            FindProduit(produit).ChangerDateFin(newDateFin);
        }


        //methode qui retourne la liste des plats dispo à la date du jour
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


        //methode qui retourne la liste des produits dispo à la date du jour
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
        private Boolean DateMenuDispo(DateTime d)
        {
            foreach(Menu m in menus)
            {
                foreach(DateTime da in m.dates)
                {
                    if (d.Equals(da))
                    {
                        return true;
                    }
                }
            }
            return false;
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

    }
}


