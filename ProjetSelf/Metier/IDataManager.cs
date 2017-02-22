using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public interface IDataManager
    {

        List<Produit> chargeAllProduits();

        List<Plat> chargeAllPlatAvecIngred(List<Produit> lp);

        List<Menu> chargeAllMenuPlat(List<Plat> lpp);


        List<Usager> chargeAllUsager();

        List<Utilisateur> chargeAllUtilisateur();

    }
}
