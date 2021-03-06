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
    /// Logique d'interaction pour ModifierMenu.xaml
    /// </summary>
    public partial class ModifierDateUsager : UserControl
    {
        private MainWindow parent;
        private AbsUsager usager;
        public ModifierDateUsager(MainWindow m, AbsUsager u)
        {
            parent = m;
            usager = u;
            InitializeComponent();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            DateTime d;
            if (dateUsager.SelectedDate == null)
            {
                d = new DateTime(9999, 12, 31);
            }
            else
            {
                d = (DateTime)dateUsager.SelectedDate;
            }
            if (d.CompareTo(DateTime.Today)<0)
            {
               MessageBox.Show("La date sélectionée doit être supérieur ou égale à la date d'aujourd'hui");
               return;
            }else
            {
               parent.self.modifierDateFinUtlisateur(usager, d);
               MessageBox.Show("Modification éffectuée");
               parent.setUC(new ModifierUsager(parent, usager));
            }

        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new ModifierUsager(parent,usager));
        }
    }
}
