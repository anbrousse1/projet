﻿using System;
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
    /// Logique d'interaction pour AjouterProduit.xaml
    /// </summary>
    public partial class AjouterProduit : UserControl
    {
        MainWindow parent;
        public AjouterProduit(MainWindow m)
        {

            InitializeComponent();
            chargeCombobox();
            parent = m;
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            if(comboBox_type.SelectedItem == null || dateFin.SelectedDate ==null || dateEffet.SelectedDate==null
                || parent.self.produitExistant(nom.Text) )
            {
                MessageBox.Show("Veuillez renseigner tous les champs ");
                return;
            }
            String type=(String)comboBox_type.SelectedItem;
            DateTime effet = (DateTime)dateEffet.SelectedDate;
            DateTime fin = (DateTime)dateFin.SelectedDate;
            if (effet.CompareTo(fin)>0)
            {
                MessageBox.Show("La date d'effet doit etre antérieure à la date de fin");
                return;
            }
            if (fin.CompareTo(DateTime.Today)<0)
            {
                MessageBox.Show("La date de fin doit etre supérieure à la date d'ajourd'hui");
                return;
            }
            String name = nom.Text;
            if (name.Equals("")) { MessageBox.Show("Veuillez renseigner un nom"); return; }
            String obser = observation.Text;
            parent.self.addProduit(effet, fin, name, obser, type);
            MessageBox.Show("Ajout effectué");
            parent.setUC(new GestionProduit(parent));
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionProduit(parent));
        }

        private void chargeCombobox()
        {
            comboBox_type.Items.Add("Poisson");
            comboBox_type.Items.Add("Légume");
            comboBox_type.Items.Add("Fruit");
            comboBox_type.Items.Add("Viande");
            comboBox_type.Items.Add("Féculent");
            comboBox_type.Items.Add("Charcuterie");
            comboBox_type.Items.Add("Produit Sucré");
            comboBox_type.Items.Add("Autres");
        }
    }
}
