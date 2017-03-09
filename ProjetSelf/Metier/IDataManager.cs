﻿using System;
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


        List<AbsUsager> chargeAllUsager();

        List<AbsUtilisateur> chargeAllUtilisateur();

        List<AbsPlatChoisis> chargeAllPlatChoisis();

        void ajouterProduit(Produit p);

        void ajouterPlat(Plat p, List<AbsProduit> lp);

        void ajouterMenu(Menu p, List<AbsPlat> lp);

        void ajouterUtilisateur(Utilisateur p);

        void ajouterUsager(Usager p);

    }
}
