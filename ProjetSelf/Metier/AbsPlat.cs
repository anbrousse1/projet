using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class AbsPlat
    {
        public int ID { get; set; }
        public DateTime DateEffet { get; set; }
        public DateTime DateFin { get; set; }
        public String Nom { get; set; }
        public double Tarif { get; set; }
        public CategoriePlat Categorie { get; set; }
        private List<AbsProduit> ingredients = new List<AbsProduit>();
        private List<AbsTarif> tarifs = new List<AbsTarif>();

        public override string ToString()
        {
            string mess =  $"{ID}: {Nom} ({DateEffet:dd/MM/yyyy},{Categorie})\n";
            int i = 0;
            if (ingredients != null)
            {
                foreach (var p in ingredients)
                {
                    i++;
                    mess += "Produit " + i + " : " + p.ToString() + "\n";
                }
                
            }
            return mess;

        }
        /// <summary>
        /// méthode permettant de modifier le tarif d'un plat 
        /// </summary>
        /// <param name="tarif"></param>
        internal void changerTarif(double tarif)
        {
            Tarif = tarif;
        }

        /// <summary>
        /// méthode permettant de changer la date d'effet
        /// </summary>
        /// <param name="d"></param>
        internal void changerDateEffet(DateTime d)
        {
            DateEffet = d;
        }

        /// <summary>
        /// méthode permettant de modifier la date de fin
        /// </summary>
        /// <param name="d"></param>
        internal void changerDateFin(DateTime d)
        {
            DateFin = d;
        }

        /// <summary>
        /// permet d'ajouter des produits au plat
        /// </summary>
        /// <param name="p"></param>
        internal void addProduit(AbsProduit p)
        {
            if (ingredients.Count == 0) { this.DateEffet = p.DateEffet; this.DateFin = p.DateFin; }
            else
            {
                if (DateEffet.CompareTo(p.DateEffet) > 0) { DateEffet = p.DateEffet; }
                if (DateFin.CompareTo(p.DateFin) < 0) { DateFin = p.DateFin; }
            }

            ingredients.Add(p);

        }


        /// <summary>
        /// permet de vérifier si deux plats sont égaux
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool equals(AbsPlat p)
        {
            if (this.Nom.Equals(p.Nom))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Pemret de vérifer si un objet est un AbsPlat
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        public override bool Equals(object right)
        {
            //check null
            if (object.ReferenceEquals(right, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, right))
            {
                return true;
            }

            if (this.GetType() != right.GetType())
            {
                return false;
            }

            return this.equals(right as AbsPlat);
        }

        /// <summary>
        /// Permet de récuperer la liste des produits d'un plat 
        /// </summary>
        /// <returns></returns>
        public List<AbsProduit> getProduits()
        {
            return ingredients;
        }


        /// <summary>
        /// permet de modifier un produit 
        /// </summary>
        /// <param name="prods"></param>
        internal void modifProduits(List<AbsProduit> prods)
        {
            ingredients = prods;

        }

        /// <summary>
        /// permet de modifier le tarif
        /// </summary>
        /// <param name="tarif"></param>
        internal void modifierTarif(double tarif)
        {
            Tarif = tarif;
        }


    }



}

