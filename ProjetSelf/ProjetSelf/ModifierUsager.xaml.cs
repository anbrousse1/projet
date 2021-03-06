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
    public partial class ModifierUsager : UserControl
    {
        private MainWindow parent;
        private AbsUsager usager;
        public ModifierUsager(MainWindow m, AbsUsager u)
        {
            usager = u;
            parent = m;
            InitializeComponent();
        }

        private void modifDate(object sender, RoutedEventArgs e)
        {
            parent.setUC(new ModifierDateUsager(parent, usager));
        }

        private void modifMdp(object sender, RoutedEventArgs e)
        {
            parent.setUC(new ModifierMDP(parent, usager));
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionUtilisateur(parent));
        }
    }
}
