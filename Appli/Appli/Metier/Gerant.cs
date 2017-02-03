using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class Gerant : Cuisinier
    {
        internal Gerant(String matricule, DateTime de, DateTime ds, String titre, String nom, String prenom,
            int cfonction, String service, int codePaiement, long solde, int numCarte)
            :base(matricule,de,ds,titre,nom,prenom,cfonction,service,codePaiement,solde,numCarte)
        {
            fonction = "Gerant";
        }

        internal Gerant(String matricule, DateTime de, DateTime ds, String titre, String nom, String prenom,
            int cfonction, String service, int codePaiement, long solde, int numCarte, List<PlatChoisis> histo)
            :base(matricule,de,ds,titre,nom,prenom,cfonction,service,codePaiement,solde,numCarte,histo)
        {
            fonction = "Gerant";
        }
    }
}
