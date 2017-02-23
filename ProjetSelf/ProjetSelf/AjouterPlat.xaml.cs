﻿using Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour AjouterPlat.xaml
    /// </summary>
    public partial class AjouterPlat : UserControl
    {
        private MainWindow parent;
        public System.Collections.ObjectModel.ReadOnlyCollection<Produit> ingredientsROC
        {
            get;
            private set;
        }
        private List<Produit> ingredients = new List<Produit>();

        public AjouterPlat(MainWindow m)
        {
            ingredientsROC = new System.Collections.ObjectModel.ReadOnlyCollection<Produit>(ingredients);
            parent = m;
            DataContext = parent.self;
            InitializeComponent();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String cate=(String)comboBox_type.SelectedItem;
                String n = nom.Text;
                String t = tarif.Text;
                if (n.Equals("") || t.Equals("")|| ingredients.Count==0 )
                {
                    MessageBox.Show("Veuillez remplir tout les champs avec une étoile et ajouter au moins un ingrédient");
                }
                else
                {
                    if (parent.self.platExistant(n))
                    {
                        MessageBox.Show("Le nom de plat entré existe déjà");
                    }
                    else
                    {
                        //parent.self.addplat(n, t, ingredients, cate);
                        MessageBox.Show("Le plat a été ajouté");
                        parent.setUC(new GestionPlat(parent));
                    }
                    
                }
            }catch { MessageBox.Show("Veuillez remplir tout les champs avec une étoile et ajouter au moins un ingrédient"); }
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionPlat(parent));
        }

        private void ajouterProdClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ingredients.Add((Produit)prod.SelectedItem);
                listeIngredient.Children.Clear();
                listeIngredient.Children.Add(new SimpleListeProduit(this));
            }
            catch { MessageBox.Show("Veuillez sélectionner un plat");}  
        }


        public void supprimerPrduit(Produit p)
        {
            ingredients.Remove(p);
            listeIngredient.Children.Clear();
            listeIngredient.Children.Add(new SimpleListeProduit(this));
        }


        
    }
}

