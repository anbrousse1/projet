using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public interface IDataManager
    {

        List<AbsProduit> chargeAllProduits();

        List<AbsPlat> chargeAllPlatAvecIngred(List<AbsProduit> lp);

        List<AbsMenu> chargeAllMenuPlat(List<AbsPlat> lpp);

        List<AbsRepas> chargeAllRepasPlats();

        List<AbsUsager> chargeAllUsager();

        List<AbsUtilisateur> chargeAllUtilisateur();

        void ajouterProduit(Produit p);

        void ajouterPlat(Plat p, List<AbsProduit> lp);

        void ajouterMenu(Menu p, List<AbsPlat> lp);

        void ajouterUtilisateur(Utilisateur p);

        void ajouterUsager(Usager p);

        void ajouterRepas(Repas r, List<AbsPlatChoisis> lp);

        void modifMdp(AbsUtilisateur u, String mdp);

        void setPrixPlat(AbsPlat p, double prix);

        void setDateEffetPlat(AbsPlat p, DateTime date);

        void setDateFinPlat(AbsPlat p, DateTime date);

        void setDateEffetProduit(AbsProduit p, DateTime date);

        void setDateFinProduit(AbsProduit p, DateTime date);

        void addDateToMenu(AbsMenu m, DateTime d);

        void modifDateSortieUsager(AbsUsager u, DateTime d);

    }
}
