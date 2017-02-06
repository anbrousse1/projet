using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    public abstract class AbstractSelf
    {
        private DateTime dateDuJour = DateTime.Today;
        private List<AbsMenu> menus;
        private List<AbsPlat> plats;
        private List<AbsProduit> produits;
        private String droitUtilisateur;
        private AbsUsager client;
        private AbsMenu menuDuJour;


    }
}
