using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Self
    {
        
        private DateTime dateDuJour = DateTime.Today;
        private List<AbsMenu> menus;
        private List<AbsPlat> plats;
        private List<AbsProduit> produits;
        public String droitUtilisateur;
        private AbsUsager client;
        private AbsMenu menuDuJour;
        public double prixAPayer;
        private IDataManager data;

        public Self(IDataManager stub)
        {
            droitUtilisateur = null;
            dateDuJour = DateTime.Today;
            menus = getAllMenus();
            menuDuJour = getMenu(dateDuJour);
            data = stub;
            /*if (menuDuJour == null)
            {
                throw new Exception();
            }*/
        }
    

        //Retourne le menu correspondant à la date passé en paramètre
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


        //Charge la liste de menus à partir des élements de la BDD
        private List<AbsMenu> getAllMenus()
        {
            //recuperer dans BDD
            return null;
        }


        //Charge la liste de plats à partir des élements de la BDD
        private List<AbsPlat> getAllPlats()
        {
            //recuperer dans BDD
            return null;
        }

        //Charge la liste de produits à partir des élements de la BDD
        private List<AbsProduit> getAllProduit()
        {
            //recuperer dans BDD
            return null;
        }




        //méthode permettant à un utilisateur de se connecter
        public void connexion(String login, String mdp)
        {
            //BDD
            //on mettra dans droitUtilisateur si c'est un gérant, un caissier ou un cuisinier et on chargera user.

        }


        //méthode permattant à un utilisateur de se déconnecter 
        public void deconnexion()
        {
            droitUtilisateur = null;
        }

        //Charge liste des usagers à partir des éléments de,la BDD
        private List<AbsUsager> getAllUsager()
        {
            //BDD
            return null;
        }


        //Permet d'identifier un usager avec son numéro de carte
        private void FindUsager(int numeroCarte)
        {
            //recuperer dans BDD
        }

        //Permet de recuperer la liste des entrees 
        private List<String> GetEntrees()
        {
            List<String> entrees = new List<String>();
            foreach (AbsPlat p in menuDuJour.plats)
            {
                if (p.Categorie.Equals(CategoriePlat.Entree))
                {
                    entrees.Add(p.Nom);
                }
            }
            return entrees;
        }

        //Permet de recuperer la liste des plats de resistance
        private List<String> GetPlatsResistance()
        {
            List<String> plats = new List<String>();
            foreach (AbsPlat p in menuDuJour.plats)
            {
                if (p.Categorie.Equals(CategoriePlat.Plat))
                {
                    plats.Add(p.Nom);
                }
            }
            return plats;
        }

        //Permet de recuperer la liste des desserts
        private List<String> GetDesserts()
        {
            {
                List<String> desserts = new List<String>();
                foreach (AbsPlat p in menuDuJour.plats)
                {
                    if (p.Categorie.Equals(CategoriePlat.Dessert))
                    {
                        desserts.Add(p.Nom);
                    }
                }
                return desserts;
            }
        }

        //Methode pour faire payer un usager
        public void Paiement()
        {
            client.payer(prixAPayer);
            //Modif BDD
        }




        //retourne à partir d'une chaine de caractère une instance de CategoriePlat
        private CategoriePlat FindCategoriePlat(String cate)
        {
            switch (cate)
            {
                case "Entree": return CategoriePlat.Entree;
                case "Dessert": return CategoriePlat.Dessert;
                default: return CategoriePlat.Plat;
            }
        }

        //retourne à partir d'un string une instance de CategorieProduit
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

        //Permet à partir d'une liste de string d'obtenir une liste de produits
        private List<AbsProduit> FindProduits(List<String> prod)
        {
            List<AbsProduit> ingredients = new List<AbsProduit>();
            foreach (String s in prod)
            {
                ingredients.Add(FindProduit(s));
            }
            return ingredients;
        }

        //Permet à partir d'un string d'obtenir un produit
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

        //Permet à partir d'un string d'obtenir un plat
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
            plats.Add(new Plat(plats.Count + 1, debut, fin, nom, tarif, FindProduits(ingredientString), FindCategoriePlat(cate)));
            //Ajouter dans BDD
        }

        //Permet d'ajouter un Produit
        private void AddProduit(int code, DateTime deb, DateTime fin, String nom, String observation, String cate)
        {
            produits.Add(new Produit(code, deb, fin, nom, observation, FindCategorieProduit(cate)));
            //Ajouter dans BDD
        }

        //Permet d'ajouter un menu
        private void AddMenu(int code, List<String> plats)
        {
            menus.Add(new Menu(code, FindPlats(plats)));
            //Ajouter dans BDD
        }

        //Permet d'jouter un plat choisis
        public void AddPlatChoisi(String plat)
        {
            AbsPlat p = FindPlat(plat);
            prixAPayer = prixAPayer + p.Tarif;
            if (p != null)
            {
                client.AddPlatChoisis(new PlatChoisis(DateTime.Today, p.CodePlat));
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
        /// 
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

    }
}


