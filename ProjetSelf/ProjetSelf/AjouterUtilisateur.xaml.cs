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
    /// Logique d'interaction pour AjouterUtilisateur.xaml
    /// </summary>
    public partial class AjouterUtilisateur : UserControl
    {
        private MainWindow parent;
        public AjouterUtilisateur(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            chargeComboBox();
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {

            if( dateEntree.SelectedDate==null || fonction.SelectedItem == null || prenom.Text.Equals("") || nom.Text.Equals("") || titre.SelectedItem==null )
            {
                MessageBox.Show("Vous devez remplir tous les champs");
                return;
            }
            if (dateFin.SelectedDate != null)
            {

                if (DateTime.Today.CompareTo((DateTime)dateFin.SelectedDate) >= 0)
                {
                    MessageBox.Show("La date de fin doit etre supérieur à la date d'aujourd'hui");
                    return;
                }
                if (((DateTime)dateFin.SelectedDate).CompareTo((DateTime)dateEntree.SelectedDate) <= 0)
                {
                    MessageBox.Show("La date de fin doit etre supérieur à la date de début");
                    return;
                }
                parent.self.addUsager((string)titre.SelectedItem, (string)fonction.SelectedItem, getCodeFonction((string)fonction.SelectedItem), nom.Text, prenom.Text, (DateTime)dateEntree.SelectedDate, (DateTime)dateFin.SelectedDate);
                parent.setUC(new DefinitionMdpLog(parent));
                return;
            }else
            {
                parent.self.addUsager((string)titre.SelectedItem, (string)fonction.SelectedItem, getCodeFonction((string)fonction.SelectedItem), nom.Text, prenom.Text, (DateTime)dateEntree.SelectedDate, new DateTime(9999,12,31));
                parent.setUC(new DefinitionMdpLog(parent));
            }
            

        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionUtilisateur(parent));
        }

        private void chargeComboBox()
        {
            fonction.Items.Add("Cuisinier");
            fonction.Items.Add("Gerant");
            fonction.Items.Add("Caissier");

            titre.Items.Add("Monsieur");
            titre.Items.Add("Madame");
        }

        private int getCodeFonction(string fonction)
        {
            if (fonction.Equals("Caissier"))
            {
                return 001;
            }
            if (fonction.Equals("Gerant"))
            {
                return 002;
            }
            return 003;
        }

    }
}
