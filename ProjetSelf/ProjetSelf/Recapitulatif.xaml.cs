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
    /// Logique d'interaction pour Recapitulatif.xaml
    /// </summary>
    public partial class Recapitulatif : UserControl
    {
        MainWindow parent;
        public Recapitulatif(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            DataContext = parent.self;
            prixRepas.Text = parent.self.prixAPayer.ToString()+"€";
            
        }

        /// <summary>
        /// Méthode pour supprimer un plat choisis par le client
        /// </summary>
        /// <param name="p"></param>
        public void Supprimer(AbsPlat p)
        {
            parent.self.supprimerPlatChoisis(p);
        }

        /// <summary>
        /// Méthode pour incrémenter la quantité d'un plat choisis
        /// </summary>
        /// <param name="p"></param>
        public void Incrementer(AbsPlat p)
        {
            parent.self.AugmenterQuantitePlat(p);
        }

        /// <summary>
        /// Méthode pour décrémenter la quantité d'un plat choisis
        /// </summary>
        /// <param name="p"></param>
        public void Decrementer(AbsPlat p)
        {
            parent.self.DiminuerQuantitePlat(p);
        }
    }
}
