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

        void ajouterProduit(Produit p);

        void ajouterPlat(Plat p, List<Produit> lp);

        void ajouterMenu(Menu p, List<Plat> lp);

        void ajouterUtilisateur(Utilisateur p);

        void ajouterUsager(Usager p);

    }
}
