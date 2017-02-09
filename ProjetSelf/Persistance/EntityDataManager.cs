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
       
        public List<Menu> getAllMenu()
        {
            throw new NotImplementedException();
        }

        public List<Plat> getAllPlats()
        {
            throw new NotImplementedException();
        }

        public List<Produit> getAllProduits()
        {
            List<Produit> lp = new List<Produit>();

            using (EntityProduit db = new EntityProduit())
            {
                foreach (var n in db.ProduitSet)
                {
                    lp.Add(n);
                }
            }
            return lp;
        }
 
    }
}
