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
    /// Logique d'interaction pour DefinitionMdpLog.xaml
    /// </summary>
    public partial class DefinitionMdpLog : UserControl
    {
        MainWindow parent;
        public DefinitionMdpLog(MainWindow p)
        {
            InitializeComponent();
            parent = p;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text.Equals("")||mdp1.Password.Equals("")|| mdp2.Password.Equals(""))
            {
                MessageBox.Show("Remplir tous les champs svp");
                return;
            }
            if (mdp2.Password.Equals(mdp1.Password))
            {
                parent.self.addUtilisateur(mdp1.Password, login.Text, parent.self.utilisateurROC.Count);
                parent.setUC(new GestionUtilisateur(parent));
            }else
            {
                MessageBox.Show("Mots de passe non identique");
            }

        }
    }
}
