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
        //DateTime effetMin;
        //DateTime finMin;
        public ModifierDatePlatEtProduit(MainWindow m, AbsProduit p)
        {
            parent = m;
            prod = p;
            InitializeComponent();
            obs.Text = p.Observation;
            dates.Text = "Veuillez sélectionner une date d'effet anterieur au " + p.DateEffet.Day+"/"+p.DateEffet.Month+"/"+p.DateEffet.Year + " et un date de fin supérieur au " + p.DateFin.Day+"/"+p.DateFin.Month+"/"+p.DateFin.Year;
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
                parent.self.changeDateEffetProd(prod, effet);
                parent.self.mAJDatePlatsEtMenu();
            }
            if(dateFin.SelectedDate != null)
            {
                DateTime fin = (DateTime)dateFin.SelectedDate;
                parent.self.changeDateFinProd(prod, fin);
                parent.self.mAJDatePlatsEtMenu();
            }

            String obser = obs.Text;
            prod.Observation = obser;

            parent.setUC(new UCModifProd(parent));
        }

        private void dateEffet_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((DateTime)dateEffet.SelectedDate != null)
                {
                    if (((DateTime)dateEffet.SelectedDate).CompareTo(prod.DateEffet) > 0)
                    {
                        MessageBox.Show("Date d'effet sélectioné non valide");
                        dateEffet.SelectedDate = null;
                    }
                }
            }
            catch { }
        }

        private void dateFin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((DateTime)dateFin.SelectedDate != null)
                {
                    if (((DateTime)dateFin.SelectedDate).CompareTo(prod.DateFin) < 0)
                    {
                        MessageBox.Show("Date de fin sélectioné non valide");
                        dateFin.SelectedDate = null;
                    }
                }
            }
            catch { }
        }

        private void text_changed(object sender, RoutedEventArgs e)
        {
            obs.Clear();
        }
    }
}
