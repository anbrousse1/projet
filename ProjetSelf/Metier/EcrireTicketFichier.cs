using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class EcrireTicketFichier
    {
        public static void ecrireTicket(AbsUsager u, System.Collections.ObjectModel.ReadOnlyDictionary<AbsPlat,int> lp, double total)
        {
            int i = 1;
            string info = u.Nom + " " +  u.Prenom +"\n" ;
            string date = DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString()  + DateTime.Today.Year.ToString();
            foreach(KeyValuePair<AbsPlat,int> r in lp){
                info = info + " Produits " + i + " : " + r.Key.Nom + " quantité : " + r.Value +"\n";
                    i++;
            }
            info = info + " total = " + total.ToString();

            //string[] information = { identite , produit, total.ToString() };
           // System.IO.File.WriteAllLines(@"C:\Users\antho\Desktop\projet\Ticket\" + u.Nom + u.Prenom + date + ".txt", information);
            System.IO.File.WriteAllText(@"C:\Users\antho\Desktop\projet\Ticket\" + u.Nom + u.Prenom + date + ".txt",info);
            
        }

    }
}
