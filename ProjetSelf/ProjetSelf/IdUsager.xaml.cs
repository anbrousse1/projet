using Metier;
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
    /// Logique d'interaction pour IdUsager.xaml
    /// </summary>
    public partial class IdUsager : UserControl
    {
        MainWindow parent;
        public IdUsager(MainWindow m)
        {
            InitializeComponent();
            parent = m;
            nom.Text=parent.self.client.Nom;
            prenom.Text = parent.self.client.Prenom;
            titre.Text = parent.self.client.Titre;
            service.Text = parent.self.client.Service;
        }

        private void modif_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new UCListRepas(parent));
        }
    }
}
