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
    /// Logique d'interaction pour NumeroCarteEnBrut.xaml
    /// </summary>
    public partial class NumeroCarteEnBrut : UserControl
    {
        MainWindow parent;
        public NumeroCarteEnBrut(MainWindow m)
        {
            parent = m;
            InitializeComponent();
        }

        private void clickOK(object sender, RoutedEventArgs e)
        {
            if (parent.self.findUsager(numero.Text))
            {
                parent.setUC(new Caisse(parent));
            }
            else
            {
                MessageBox.Show("Pas de client trouvé avec ce numéro de carte");
            }
        }
    }
}
