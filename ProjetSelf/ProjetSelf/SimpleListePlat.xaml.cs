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
    /// Logique d'interaction pour SimpleListePlat.xaml
    /// </summary>
    public partial class SimpleListePlat : UserControl
    {
        private AjouterMenu parent;
        public SimpleListePlat(AjouterMenu p)
        {
            parent = p;
            DataContext = parent;
            InitializeComponent();
        }

        private void ListView_Selected(object sender, SelectionChangedEventArgs e)
        {
            Plat p = (Plat)((ListView)sender).SelectedItem;
            parent.supprimerPlat(p);
        }
    }
}
