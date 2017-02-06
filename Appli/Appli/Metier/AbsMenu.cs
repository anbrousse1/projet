using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli.Metier
{
    internal abstract class AbsMenu
    {
        internal int CodeMenu { get; set; }
        internal List<DateTime> dates = new List<DateTime>();
        internal List<AbsPlat> plats = new List<AbsPlat>();

        //Permet d'ajouter un date à un menu
        internal void AddDate(DateTime d)
        {
            dates.Add(d);
        }


        //Permet d'ajouter une liste de  date à un menu
        internal void AddListDate(List<DateTime> d)
        {
            dates.AddRange(d);
        }
    }
}
