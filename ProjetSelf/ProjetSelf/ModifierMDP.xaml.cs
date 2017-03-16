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
    /// Logique d'interaction pour ModifierMDP.xaml
    /// </summary>
    public partial class ModifierMDP : UserControl
    {
        private MainWindow parent;
        public ModifierMDP(MainWindow m)
        {
            parent = m;
            InitializeComponent();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            if (parent.self.connexion(parent.self.log, oldmdp.Password))
            {
                if (newmdp.Password.Equals(confmdp.Password))
                {
                    if (!newmdp.Password.Equals(""))
                    {
                        parent.self.changerMdp(newmdp.Password);
                        MessageBox.Show("Le mot de passe a été modifié");
                    }else
                    {
                        MessageBox.Show("Nouveau mot de passe incorrect");
                    }
                }else
                {
                    MessageBox.Show("Les deux mots de passe sont différents");
                }
            }else
            {
                MessageBox.Show("Mot de passe incorrect");
            }
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            //parent.setUC(new ModifierUsager(parent));
        }
    }
}
