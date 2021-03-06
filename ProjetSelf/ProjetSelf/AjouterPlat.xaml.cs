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
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsProduit> ingredientsROC
        {
            get;
            private set;
        }
        private List<AbsProduit> ingredients = new List<AbsProduit>();
        DateTime effet;
        DateTime fin;

        public AjouterPlat(MainWindow m)
        {
            ingredientsROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsProduit>(ingredients);
            parent = m;
            DataContext = parent.self;
            InitializeComponent();
            chargeCombobox();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                String cate=(String)comboBox_type.SelectedItem;
                String n = nom.Text;
                double i = 1;
                if (!double.TryParse(tarif.Text, out i))
                {
                    MessageBox.Show("Valeur saisie dans tarif incorrecte");
                    return;
                }
                double t=double.Parse(tarif.Text);
                if (n.Equals("") )
                {
                    MessageBox.Show("Veuillez remplir tout les champs ");
                }
                else
                {
                if (parent.self.platExistant(n))
                {
                    MessageBox.Show("Le nom de plat entré existe déjà");
                }
                else if (ingredients.Count == 0)
                {
                    MessageBox.Show("Vous devez ajouter au moins un ingrédients");
                    return;
                }else { 
                    parent.self.addplat(effet,fin,n, t, ingredients, cate);
                    MessageBox.Show("Le plat a été ajouté");
                    parent.setUC(new GestionPlat(parent));
                }
                }
            //}catch { MessageBox.Show("Veuillez remplir tout les champs avec une étoile et ajouter au moins un ingrédient"); }
        }

        

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionPlat(parent));
        }

        private void ajouterProdClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Produit p = (Produit)prod.SelectedItem;
                if (ingredients.Count == 0)
                {
                    effet = p.DateEffet;
                    fin = p.DateFin;
                }else
                {
                    if (effet.CompareTo(p.DateEffet) < 0) { effet = p.DateEffet;}
                    if (fin.CompareTo(p.DateFin) > 0) { fin = p.DateFin; }
                }
                ingredients.Add(p);
                listeIngredient.Children.Clear();
                listeIngredient.Children.Add(new SimpleListeProduit(this));
                
            }
            catch { MessageBox.Show("Veuillez sélectionner un plat");}  
        }


        public void supprimerProduit(Produit p)
        {
            ingredients.Remove(p);
            listeIngredient.Children.Clear();
            listeIngredient.Children.Add(new SimpleListeProduit(this));
        }

        /*private void tarif_KeyDown(object sender, KeyEventArgs e)
        {
            char c = (char)e.Key;
            Console.WriteLine(c);
            if (Char.IsNumber(c))
            {
                Console.WriteLine(Char.IsNumber(c));
                if (virgule)
                {
                    prix= prix+Char.GetNumericValue(c);
                    e.Handled = true;
                    return;
                }
            }else
            {
                if (c.Equals(",") && virgule)
                {
                    virgule = false;
                    e.Handled = true;
                    if (centimes == 0)
                    {
                        centimes = Char.GetNumericValue(c) * 10;
                    }else
                    {
                        centimes = centimes + Char.GetNumericValue(c);
                    }
                    return;
                }
            }
            e.Handled = false;
        }*/

        private void chargeCombobox()
        {
            comboBox_type.Items.Add("Entree");
            comboBox_type.Items.Add("Dessert");
            comboBox_type.Items.Add("Plat");
        }
            
    }
}

