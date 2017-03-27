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
                case "Vue.AjouterMenu": label.Text = "C'est ici que vous pouvez créer un nouveau menu soit en y ajoutant des plats,\n soit en reprenant un menu existant.";
                    label1.Text += " Ajouter Menu";
                    break;
                case "Vue.AjouterPlat": label.Text = "Permet de créer un nouveau plat à partir des produits disponibles.";
                    label1.Text += " Ajouter Plat";
                    break;
                case "Vue.AjouterProduit": label.Text = "Permet d'ajouter un produit à la base de données de l'application.";
                    label1.Text += " Ajouter Produit";
                    break;
                case "Vue.AjouterUtilisateur": label.Text = "Permet d'ajouter un utilisateur à l'application.";
                    label1.Text += " Ajouter Utilisateur";
                    break;
                case "Vue.DefinitionMdpLog": label.Text = "Définir le mot de passe d'un utilisateur.";
                    label1.Text += " Définition Mot de Passe";
                    break;
                case "Vue.GererMenu": label.Text = "Permet d'attribuer un menu déjà existant à une date ultérieure.";
                    label1.Text += " Attribution Menu";
                    break;
                case "Vue.GestionMenu": label.Text = "Permet d'accéder à toutes les fonctionnalités de gestion des menus.";
                    label1.Text += " Gestion des Menus";
                    break;
                case "Vue.GestionPlat": label.Text = "Permet d'accéder à toutes les fonctionnalités de gestion des plats.";
                    label1.Text += " Gestion des Plats";
                    break;
                case "Vue.GestionProduit": label.Text = "Permet d'accéder à toutes les fonctionnalités de gestion de produits.";
                    label1.Text += " Gestion des Produits";
                    break;
                case "Vue.GestionUtilisateur": label.Text = "Permet d'accéder à toutes les fonctionnalités de gestion des utilisateurs.";
                    label1.Text += " Gestion des Utilisateurs";
                    break;
                case "Vue.ModifierDatePlatEtProduit": label.Text = "Permet de modifier les dates de disponibilités d'un produit présent dans l'application.";
                    label1.Text += " Modification date Produits";
                    break;
                case "Vue.ModifierDateUsager": label.Text = "Permet de modifier la date de fin de contrat d'un utilisateur.";
                    label1.Text += " Modification date Usagers";
                    break;
                case "Vue.ModifierMDP": label.Text = "Permet de changer le mot de passe d'un utilisateur de l'application.";
                    label1.Text += " Modification Mot de Passe";
                    break;
                case "Vue.ModifierMenu": label.Text = "Permet de modifier les plats qui composent un menu existant.";
                    label1.Text += " Modification Menu";
                    break;
                case "Vue.ModifierPlat": label.Text = "Permet de modifier un plat existant.";
                    label1.Text += " Modification Plat";
                    break;
                case "Vue.ModifierUsager": label.Text = "Permet d'accéder à des fonctionnalités de modification d'attributs des utilisateurs.";
                    label1.Text += " Modification Usager";
                    break;
                case "Vue.UCBoisson": label.Text = "Sélection des boissons choisies par les clients.";
                    label1.Text += " Boissons";
                    break;
                case "Vue.UCDessert": label.Text = "Sélection des desserts choisis par les clients.";
                    label1.Text += " Desserts";
                    break;
                case "Vue.UCEntree": label.Text = "Sélection des entrées choisies par les clients.";
                    label1.Text += " Entrees";
                    break;
                case "Vue.UCListRepas": label.Text = "Permet de modifier un ticket de caisse.";
                    label1.Text += " Modification Ticket";
                    break;
                case "Vue.UCPlat": label.Text = "Sélection des plats choisis par les clients.";
                    label1.Text += " Plats";
                    break;
                case "Vue.UCModifProd": label.Text = "Permet de choisir un produit existant afin de modifier ses dates de disponibilités.";
                    label1.Text += " Modification Produit";
                    break;
                case "Vue.VisualitationMenu": label.Text = "Permet de choisir un menu existant afin de le modifier.";
                    label1.Text += " Modification Menu";
                    break;
                case "Vue.VisualisationUtilisateur": label.Text = "Voici la liste des utilisateurs enregistrés dans l'application.\n (Cliquez sur un utilisateur pour le modifier)";
                    label1.Text += " Liste Utilisateurs";
                    break;
                case "Vue.VisualisationPlat": label.Text = "Permet de choisir un plat existant afin de le modifier.";
                    label1.Text += " Modification Plat";
                    break;
                case "Vue.ModifierTicket": label.Text = "Permet de modifier un ticket existant";
                    label1.Text += " Ticket";
                    break;
                case "Vue.Paiement": label.Text = "Permet de valider la commande d'un client";
                    label1.Text += " Récapitulatif";
                    break;          
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
