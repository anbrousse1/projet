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
    /// Logique d'interaction pour ModifierTicket.xaml
    /// </summary>
    public partial class ModifierTicket : UserControl
    {
        MainWindow parent;
        AbsRepas repas;
        public ModifierTicket(MainWindow m, AbsRepas r)
        {
            parent = m;
            repas = r;
            InitializeComponent();
        }
    }
}
