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
    /// Logique d'interaction pour StatPeriode.xaml
    /// </summary>
    public partial class StatPeriode : UserControl
    {
        MainWindow parent;
        public StatPeriode(MainWindow m)
        {
            parent = m;
            InitializeComponent();
        }

        private void retourClick(object sender, RoutedEventArgs e)
        {
            parent.setUC(new AccueilGerant(parent));
        }

        private void validerClick(object sender, RoutedEventArgs e)
        {
            DateTime d;
            DateTime f;
            try
            {
                d = (DateTime)debut.SelectedDate;
                f = (DateTime)fin.SelectedDate;
            }
            catch { MessageBox.Show("Sélectionner une date de début et une date de fin"); return; }
            freq.Text = parent.self.frequentation(d, f).ToString();
            ca.Text=parent.self.chiffreDAffaire(d, f).ToString()+" €";
            platp.Text= parent.self.statTopPlat(d, f);
            moy.Text= parent.self.prixMoyenRepas(d, f).ToString()+" €";
        }
    }
}
