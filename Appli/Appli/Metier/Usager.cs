using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal class Usager
    {
        internal string Matricule { get; private set; }
        internal DateTime DateEntree { get; private set; }
        internal DateTime DateSortie { get; private set; }
        internal string Titre { get; private set; }
        internal string Nom { get; private set; }
        internal string Prenom { get; private set; }
        internal int CodeFonction { get; private set; }
        internal string Service { get; private set; }
        internal Paiement algoDePaiement { get; private set; }
        internal long Solde { get; set; }
        internal List<PlatChoisis> historiquePlatChoisi;

    }
}
