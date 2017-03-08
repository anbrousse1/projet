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
    /// Logique d'interaction pour ModifierDatePlatEtProduit.xaml
    /// </summary>
    public partial class ModifierDatePlatEtProduit : UserControl
    {
        MainWindow parent;
        AbsProduit prod;
        DateTime effetMin;
        DateTime finMin;
        public ModifierDatePlatEtProduit(MainWindow m, AbsProduit p)
        {
            parent = m;
            prod = p;
            InitializeComponent();
            effetMin = parent.self.getDateEffetMiniProd(prod);
            finMin = parent.self.getDateFinMiniProd(prod);
            obs.Text = p.Observation;
            dates.Text = "Veuillez sélectionner une date d'effet anterieur au " + effetMin.Day+"/"+effetMin.Month+"/"+effetMin.Year + " et un date de fin supérieur au " + finMin.Day+"/"+finMin.Month+"/"+finMin.Year;
        }

        private void clickAnnuler(object sender, RoutedEventArgs e)
        {
            parent.setUC(new UCModifProd(parent));
        }

        private void clickValider(object sender, RoutedEventArgs e)
        {
            if (dateEffet.SelectedDate != null)
            {
                DateTime effet = (DateTime)dateEffet.SelectedDate;
                prod.DateEffet = effet;
            }
            if(dateFin.SelectedDate != null)
            {
                DateTime fin = (DateTime)dateFin.SelectedDate;
                prod.DateFin = fin;
            }

            String obser = obs.Text;
            prod.Observation = obser;

            parent.setUC(new UCModifProd(parent));
        }

        private void dateEffet_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((DateTime)dateEffet.SelectedDate != null)
            {
                if (((DateTime)dateEffet.SelectedDate).CompareTo(effetMin) > 0)
                {
                    MessageBox.Show("Date d'effet sélectioné non valide");
                    dateEffet.SelectedDate = null;
                }
            }
        }

        private void dateFin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((DateTime)dateFin.SelectedDate != null)
            {
                if (((DateTime)dateFin.SelectedDate).CompareTo(finMin) < 0)
                {
                    MessageBox.Show("Date de fin sélectioné non valide");
                    dateFin.SelectedDate = null;
                }
            }
        }

        private void text_changed(object sender, RoutedEventArgs e)
        {
            obs.Clear();
        }
    }
}
