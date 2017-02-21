using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class StubDataManager : IDataManager
    {
        public List<Menu> chargeAllMenu()
        {
            return null;
        }

        public List<Menu> chargeAllMenuPlat(List<Plat> lpp)
        {
            List<Menu> menus = new List<Menu>();

            Menu m = new Menu { Nom = "menu 1" };
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "saucisse", Tarif = 3.5, ingredients = null, Categorie = CategoriePlat.Plat });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "steack", Tarif = 8.5, ingredients = null, Categorie = CategoriePlat.Plat });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "poulet", Tarif = 1.5, ingredients = null, Categorie = CategoriePlat.Plat });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "frites", Tarif = 3, ingredients = null, Categorie = CategoriePlat.Plat });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "petit pois", Tarif = 5, ingredients = null, Categorie = CategoriePlat.Plat });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "pates", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Plat });

            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade de fruit", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "creme café", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "yahourt", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "beignet", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "baba au rhum", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "bonbons", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });

            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade verte", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade bleu", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade rouge", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade orange", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });
            m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade rose", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });
            //m.plats.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade marron", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });
            m.AddDate(DateTime.Today);
            menus.Add(m);
            return menus;
        }



        public List<Plat> chargeAllPlatAvecIngred(List<Produit> lp)
        {
            List<Plat> p = new List<Plat>();
            p.Add(new Plat { ID = 001, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "saucisse", Tarif = 3.5, ingredients = null, Categorie = CategoriePlat.Plat });
            p.Add(new Plat { ID = 002, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "steack", Tarif = 8.5, ingredients = null, Categorie = CategoriePlat.Plat });
            p.Add(new Plat { ID = 003, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "poulet", Tarif = 1.5, ingredients = null, Categorie = CategoriePlat.Plat });
            p.Add(new Plat { ID = 004, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "frites", Tarif = 3, ingredients = null, Categorie = CategoriePlat.Plat });
            p.Add(new Plat { ID = 005, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "petit pois", Tarif = 5, ingredients = null, Categorie = CategoriePlat.Plat });
            p.Add(new Plat { ID = 006, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "pates", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Plat });

            p.Add(new Plat { ID = 007, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade de fruit", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });
            p.Add(new Plat { ID = 008, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "creme café", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });
            p.Add(new Plat { ID = 009, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "yahourt", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });
            p.Add(new Plat { ID = 010, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "beignet", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });
            p.Add(new Plat { ID = 011, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "baba au rhum", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });
            p.Add(new Plat { ID = 012, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "bonbons", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Dessert });

            p.Add(new Plat { ID = 013, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade verte", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });
            p.Add(new Plat { ID = 014, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade bleu", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });
            p.Add(new Plat { ID = 015, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade rouge", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });
            p.Add(new Plat { ID = 016, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade orange", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });
            p.Add(new Plat { ID = 017, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade rose", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });
            p.Add(new Plat { ID = 018, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "salade marron", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Entree });


            p.Add(new Plat { ID = 019, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "Biere", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Boisson });
            p.Add(new Plat { ID = 020, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "Eau gazeuse", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Boisson });
            p.Add(new Plat { ID = 021, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "Eau plate", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Boisson });
            p.Add(new Plat { ID = 022, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "Vin", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Boisson });
            p.Add(new Plat { ID = 023, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "Soda", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Boisson });
            p.Add(new Plat { ID = 024, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), Nom = "Jus de fruit", Tarif = 2, ingredients = null, Categorie = CategoriePlat.Boisson });

            return p;
        }

        public List<Plat> chargeAllPlats()
        {
            return null;
        }

        public List<Produit> chargeAllProduits()
        {
            List<Produit> p = new List<Produit>();
            p.Add(new Produit { Nom = "Carotte", Categorie = CategorieProduit.Legume, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), ID = 001, Observation = "carotte bio" });
            p.Add(new Produit { Nom = "Poireaux", Categorie = CategorieProduit.Legume, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), ID = 002, Observation = "carotte bio" });
            p.Add(new Produit { Nom = "Pommes de terre", Categorie = CategorieProduit.Legume, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), ID = 003, Observation = "carotte bio" });
            p.Add(new Produit { Nom = "Entrecote", Categorie = CategorieProduit.Legume, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), ID = 004, Observation = "carotte bio" });
            p.Add(new Produit { Nom = "Cuisse de poulet", Categorie = CategorieProduit.Legume, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), ID = 005, Observation = "carotte bio" });
            p.Add(new Produit { Nom = "Haricots", Categorie = CategorieProduit.Legume, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), ID = 006, Observation = "carotte bio" });
            p.Add(new Produit { Nom = "Creme fraiche", Categorie = CategorieProduit.Legume, DateEffet = DateTime.Today, DateFin = DateTime.Today.AddDays(2), ID = 007, Observation = "carotte bio" });
            return p;
        }

        public List<Usager> chargeAllUsager()
        {
            List < Usager >u = new List<Usager>();
            u.Add(new Usager {Nom="Beber", Prenom="Bob", CodeFonction=001, DateEntree=DateTime.Today.AddDays(-2), DateSortie =DateTime.Today.AddMonths(6), Titre="Mr", ID=001, Service="Restaurant", Solde=40, Fonction="Caissier" , carte=new Carte(1)});
            u.Add(new Usager { Nom = "Leponge", Prenom = "Bob", CodeFonction = 002, DateEntree = DateTime.Today.AddDays(-2), DateSortie = DateTime.Today.AddMonths(6), Titre = "Mr", ID = 002, Service = "Restaurant", Solde = 40, Fonction = "Caissier", carte = new Carte(2) });
            u.Add(new Usager { Nom = "LeBricoleur", Prenom = "Bob", CodeFonction = 003, DateEntree = DateTime.Today.AddDays(-2), DateSortie = DateTime.Today.AddMonths(6), Titre = "Mr", ID = 003, Service = "Restaurant", Solde = 40, Fonction = "Caissier", carte = new Carte(3) });
            return u;
        }

        public List<Utilisateur> chargeAllUtilisateur()
        {
            List<Utilisateur> u = new List<Utilisateur>();
            u.Add(new Utilisateur { ID = 001, Login = "caisse", Password = "admin" });
            u.Add(new Utilisateur { ID = 002, Login = "gerant", Password = "admin" });
            u.Add(new Utilisateur { ID = 001, Login = "cuisine", Password = "admin" });
            return u;
        }
    }
}
