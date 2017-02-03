using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    public class Self
    {
        private DateTime dateDuJour;
        private List<Menu> menus;
        private List<Plat> plats;
        private List<Produit> produits;
        private List<Usager> clients;
        private String droitUtilisateur;
        private Usager client;


        private Menu menuDuJour;

        
        public Self()
        {
            droitUtilisateur = null;
            dateDuJour = DateTime.Today;
            menus = getAllMenus();
            menuDuJour = getMenu(dateDuJour);
            if (menuDuJour == null)
            {
                throw new Exception();
            }
        }


        //Retourne le menu correspondant à la date passé en paramètre
        private Menu getMenu(DateTime d)
        {
            foreach (Menu m in menus)
            {
                if (m.dates.Contains(d))
                {
                    return m;
                }
            }
            return null;
        }


        //Charge la liste de menus à partir des élements de la BDD
        private List<Menu> getAllMenus()
        {
            //recuperer dans BDD
            return null;
        }


        //Charge la liste de plats à partir des élements de la BDD
        private List<Plat> getAllPlats()
        {
            //recuperer dans BDD
            return null;
        }

        //Charge la liste de produits à partir des élements de la BDD
        private List<Produit> getAllProduit()
        {
            //recuperer dans BDD
            return null;
        }


        //méthode permettant à un utilisateur de se connecter
        private void connexion(String login, String mdp)
        {
            //BDD
            //on mettra dans droitUtilisateur si c'est un gérant, un caissier ou un cuisinier et on chargera user.

        }


        //méthode permattant à un utilisateur de se déconnecter 
        private void deconnexion()
        {
            droitUtilisateur = null;
        }

        //Charge liste des usagers à partir des éléments de,la BDD
        private List<Usager> getAllUsager()
        {
            //BDD
            return null;
        }


        //Permet d'identifier un usager avec son numéro de carte
        private void FindUsager(int numeroCarte)
        {
            foreach(Usager u in clients)
            {
                if (u.carte.Numero == numeroCarte)
                {
                    client= u;
                }
            }
        }

        //Permet de recuperer la liste des entrees 
        private List<String> GetEntrees()
        {
            List<String> entrees = new List<String>();
            foreach (Plat p in menuDuJour.plats)
            {
                if (p.Categorie.Equals(CategoriePlat.Entree)){
                    entrees.Add(p.Nom);
                }
            }
            return entrees;
        }

        //Permet de recuperer la liste des plats de resistance
        private List<String> GetPlatsResistance()
        {
            List<String> plats = new List<String>();
            foreach (Plat p in menuDuJour.plats)
            {
                if (p.Categorie.Equals(CategoriePlat.Plat)){
                    plats.Add(p.Nom);
                }
            }
            return plats;
        }

        //Permet de recuperer la liste des desserts
        private List<String> GetDesserts() {
            {
                List<String> desserts = new List<String>();
                foreach (Plat p in menuDuJour.plats)
                {
                    if (p.Categorie.Equals(CategoriePlat.Dessert)){
                        desserts.Add(p.Nom);
                    }
                }
                return desserts;
            }
        }

        //Methode pour faire payer un usager
        private void Paiement(double prixAPayer)
        {
            client.payer(prixAPayer);
        }


        //Permet d'ajouter un Plat
        private void Addplat(DateTime debut, DateTime fin,String nom,Double tarif, List<String> ingredientString , String cate)
        {
            plats.Add(new Plat(plats.Count + 1, debut, fin, nom, tarif, FindProduit(ingredientString), FindCategoriePlat(cate)));
            //Ajout à la BDD
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

        //Permet à partir d'une liste de string d'obtenir une liste de produit
        private List<Produit> FindProduit(List<String> prod)
        {
            List<Produit> ingredients = new List<Produit>();
            foreach(String s in prod)
            {
                foreach (Produit p in produits)
                {
                    if (p.Nom.Equals(s))
                    {
                        ingredients.Add(p);
                    }
                }
            }
            return ingredients;   
        }

        


    }
}
