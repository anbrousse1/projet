using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class EcrireTicketFichier
    {
        public static void ecrireTicket(AbsUsager u,AbsUsager c,System.Collections.ObjectModel.ReadOnlyDictionary<AbsPlat, int> lp, double total,DateTime d)
        {
            int i = 1;
            string identite = u.Nom + " " + u.Prenom + "\n";
            string date =d.Day.ToString() + "." + d.Month.ToString() + "." + d.Year.ToString() + "." + d.Hour + "." + d.Minute;
            string info = "";
            string appli = "EasySelf";
            string caissier = "caissier : " + c.Nom + " " + c.Prenom;
            foreach (KeyValuePair<AbsPlat,int> r in lp){
                info = info + " Produits " + i + " : " + r.Key.Nom + " quantité : " + r.Value + " prix : "+ r.Key.Tarif*r.Value+ "\n";
                i++;
            }

            string tot = "Total : " + total.ToString();
            string[] text = {appli,caissier,identite, "-----------------------", info, tot};
            //ajouter lles info au text
            
            //string[] information = { identite , produit, total.ToString() };
             System.IO.File.WriteAllLines("../../../Ticket/" + u.Nom + u.Prenom + date + ".txt", text);
            //System.IO.File.WriteAllText(@"C:\Users\antho\Desktop\projet\Ticket\" + u.Nom + u.Prenom + date + ".txt",info);


        }
        //Faire une methode pour modifier le ticket avec une version 2 


    }
}
