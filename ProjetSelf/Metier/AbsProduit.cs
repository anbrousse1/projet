using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class AbsProduit
    {
        public int ID { get; set; }
        public DateTime DateEffet { get; set; }
        public DateTime DateFin { get; set; }
        public String Nom { get; set; }
        public String Observation { get; set; }
        public CategorieProduit Categorie { get; set; }

        public override string ToString()
        {
            return $"{ID}: {Nom} ({DateEffet:dd/MM/yyyy}, {Observation} , {Categorie})";
        }

        //méthode permettant de changer la date d'effet
        internal void ChangerDateEffet(DateTime d)
        {
            DateEffet = d;
        }

        //méthode permettant de modifier la date de fin
        internal void ChangerDateFin(DateTime d)
        {
            DateFin = d;
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode() + base.GetHashCode();
        }

        public bool Equals(AbsProduit p)
        {
            if (p != null)
            {
                if (this.Nom.Equals(p.Nom))
                {
                    return true;
                }
            }
            return false;
        }


        public override bool Equals(object right)
        {
            //check null
            if (object.ReferenceEquals(right, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, right))
            {
                return true;
            }

            if (this.GetType() != right.GetType())
            {
                return false;
            }

            return this.Equals(right as AbsProduit);
        }

    }
}
