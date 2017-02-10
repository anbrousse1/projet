using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public interface IDataManager
    {
        //Seule méthode a appelé pour l'instant : elle charge toute les ReadOnlyCollections
        List<Menu> chargeAllMenu();

        List<Produit> chargeAllProduits();

        List<List<PlatProduit>> chargeAllPlatProduit(List<Plat> lpp, List<Produit> lp);

        List<List<MenuPlat>> chargeAllMenuPlat(List<Menu> lm, List<Plat> lpp);

        List<Plat> chargeAllPlats();

        void chargeAll(Self s);

    }
}
