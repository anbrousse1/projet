using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vue
{
    public partial class Aide : Form
    {
        string uc;
        public Aide(string uc)
        {
            this.uc = uc;
            InitializeComponent();
            label1.Text = "Aide";
            
            setText();
        }

        public void setText()
        {
            switch (uc)
            {
                case "Connexion": label.Text = "Voici l'écran de connexion";
                    label1.Text += " Connexion";
                    break;
                case "Vue.Caisse": label.Text = "Pour commencer, il faut insérer la carte du client dans le lecteur\n pour que celui ci soit identifié. Ensuite il suffit d'utiliser les boutons pour\n "+
                        "entrer les plats que le client a sélectionné. Sur la droite il y a un récapitulatif \nqui permet de voir les plats déja entré par le caissier mais aussi de les supprimer \n"+
                        "ou de les modifier. Pour payer il faut cliquer sur le bouton paiement.";
                    label1.Text += " Caisse";
                    break;
                case "Vue.AccueilGerant": label.Text = "Voici l'écran de l'accueil du gérant !\n Si vous êtes ici, c'est que vous êtes le gérant de cette application : c'est plutot cool non ? \n" + 
                        "Dans le cas contraire veuillez immédiatement quitter cette application !  ";
                    label1.Text += " Gérant";
                    break;
                case "Vue.AjouterMenu": label.Text = "C'est ici que vous pouvez créer un nouveau menu soit en y ajoutant des plats, soit en reprenant un menu existant.";
                    label1.Text += " Ajouter Menu";
                    break;
                case "Vue.AjouterPlat": label.Text = "Permet de créer un nouveau plat à partir des produits disponibles.";
                    label1.Text += " Ajouter Plat";
                    break;
                case "Vue.AjouterProduit": label.Text = "Permet d'ajouter un produit à la base de données de l'application.";
                    label1.Text += " Ajouter Produit";
                    break;
                case "Vue.AjouterUtilisateur": label.Text = "Permet d'ajouter un utilisateur à l'application";
                    label1.Text += " Ajouter Utilisateur";
                    break;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
