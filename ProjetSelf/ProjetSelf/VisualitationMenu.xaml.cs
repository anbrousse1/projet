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
    /// Logique d'interaction pour VisualitationMenu.xaml
    /// </summary>
    public partial class VisualitationMenu : UserControl
    {
        MainWindow parent;
        public VisualitationMenu(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            DataContext = parent.self;

        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionMenu(parent));
        }

        private void UCVisualiserMenu_Clicked(object sender, PlatCEventArgs e)
        {
            AbsMenu m = parent.self.findMenuByName((sender as UCVisualiserMenu).NomMenu);
            if (e.Num == 0)
            {
                // appelle de supprimer menu
                parent.self.supprimerMenu(m);
                liste.Items.Refresh();
            }
            else
            {
                //Vue modifier menu 
                parent.setUC(new ModifierMenu(parent, m));
            }
        }


    }
}
