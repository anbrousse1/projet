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
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary>
    public partial class AccueilGerant : UserControl
    {
        private MainWindow parent;

        public AccueilGerant(MainWindow m)
        {
            InitializeComponent();
            parent = m;
        }

        private void ClickGestionPlat(object sender, RoutedEventArgs e)
        {
            //parent.setUC(new UCGestionPlat(parent));
        }
    }
}