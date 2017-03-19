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
    /// Logique d'interaction pour GererMenu.xaml
    /// </summary>
    public partial class GererMenu : UserControl
    {
        private MainWindow parent;
        public GererMenu(MainWindow m)
        {
            parent = m;
            parent.self.chargeDateDispo();
            DataContext = parent.self;
            InitializeComponent();
        }

        /// <summary>
        /// Méthode appelé lors d'un clique su valider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valider_Click(object sender, RoutedEventArgs e)
        {
            DateTime d;
            AbsMenu m=null;
            m =(AbsMenu)comboBox_menu.SelectedItem;
            Console.WriteLine(m.Effet);
            Console.WriteLine(m.Fin);         
            try
            {
                d = (DateTime)dateMenu.SelectedDate;
                if (!parent.self.dateMenuDispo(d))
                {
                    MessageBox.Show("Cette date a déjà un menu de programmé");
                }else if (m != null)
                {
                    parent.self.addDateToMenu(m, d);
                    parent.setUC(new GestionMenu(parent));
                }else
                {
                    MessageBox.Show("Veuillez sélectionner un Menu ");
                }
            }catch { MessageBox.Show("Veuillez sélectionner une date"); }
            
            

        }

        /// <summary>
        /// Méthode appelé lors d'un clique sur retour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void retour_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionMenu(parent));
        }
    }

}
