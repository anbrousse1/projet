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
    /// Logique d'interaction pour UCBoisson.xaml
    /// </summary>
    public partial class UCBoisson : UserControl
    {
        private MainWindow parent;
        private List<AbsPlat> boissons = new List<AbsPlat>();

        public UCBoisson(MainWindow m)
        {
            parent = m;
            InitializeComponent();
            this.recap.Children.Add(new Recapitulatif(parent,true));
            ChargerBoutons();
        }

        /// <summary>
        /// Méthode qui désactive certains boutons en fonction du nombre de plats dans la liste.
        /// </summary>
        /// <param name="i"></param>
        private void DisableButtons(int i)
        {
            switch (i)
            {
                case 0:
                    MessageBox.Show("Aucune boissons dans le menu!!!");
                    button1.Visibility = Visibility.Hidden;
                    button2.Visibility = Visibility.Hidden;
                    button3.Visibility = Visibility.Hidden;
                    button4.Visibility = Visibility.Hidden;
                    button5.Visibility = Visibility.Hidden;
                    button6.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    button2.Visibility = Visibility.Hidden;
                    button3.Visibility = Visibility.Hidden;
                    button4.Visibility = Visibility.Hidden;
                    button5.Visibility = Visibility.Hidden;
                    button6.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    button3.Visibility = Visibility.Hidden;
                    button4.Visibility = Visibility.Hidden;
                    button5.Visibility = Visibility.Hidden; 
                    button6.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    button4.Visibility = Visibility.Hidden;
                    button5.Visibility = Visibility.Hidden;
                    button6.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    button5.Visibility = Visibility.Hidden;
                    button6.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    button6.Visibility = Visibility.Hidden;
                    break;
                default: return;

            }
        }

        /// <summary>
        /// Methode appelé lorsqu'on clique sur valider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickValider(object sender, RoutedEventArgs e)
        {
            parent.setUC(new Caisse(parent));
        }

        /// <summary>
        /// Methode appelé lorsqu'on clique sur annulé
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickAnnuler(object sender, RoutedEventArgs e)
        {
            parent.self.supprimerAllPlatsChoisis();
            parent.setUC(new Caisse(parent));
        }

        /// <summary>
        /// appelle les méthode permettant de séactiver les boutons et charger leurs contenu
        /// </summary>
        private void ChargerBoutons()
        {
            DisableButtons(parent.self.boissonROC.Count);
            List<AbsPlat> p = parent.self.boissonROC.ToList<AbsPlat>();
            int i = 0;
            foreach (AbsPlat pl in p)
            {
                ChargerContentBouton(i, pl);
                i++;
            }

        }

        /// <summary>
        /// Permet de charger le contenu des boutons
        /// </summary>
        /// <param name="i"></param>
        /// <param name="p"></param>
        private void ChargerContentBouton(int i, AbsPlat p)
        {
            switch (i)
            {
                case 0:
                    b1.Text = p.Nom;
                    break;
                case 1:
                    b2.Text = p.Nom;
                    break;
                case 2:
                    b3.Text = p.Nom;
                    break;
                case 3:
                    b4.Text = p.Nom;
                    break;
                case 4:
                    b5.Text = p.Nom;
                    break;
                case 5:
                    b6.Text = p.Nom;
                    break;

            }
        }



        /// <summary>
        /// Méthode appelé quand on clique sur le premier bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButton1(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(b1.Text);

            recap.Children.Clear();
            recap.Children.Add(new Recapitulatif(parent,true));
        }

        /// <summary>
        /// Méthode appelé quand on clique sur le deuxieme bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButton2(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(b2.Text);
            recap.Children.Clear();
            recap.Children.Add(new Recapitulatif(parent,true));
        }

        /// <summary>
        /// Méthode appelé quand on clique sur le troisieme bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButton3(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(b3.Text);
            recap.Children.Clear();
            recap.Children.Add(new Recapitulatif(parent,true));
        }

        /// <summary>
        /// Méthode appelé quand on clique sur le quatrième bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButton4(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(b4.Text);
            recap.Children.Clear();
            recap.Children.Add(new Recapitulatif(parent,true));
        }

        /// <summary>
        /// Méthode appelé quand on clique sur le cinquieme bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButton5(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(b5.Text);
            recap.Children.Clear();
            recap.Children.Add(new Recapitulatif(parent,true));
        }

        /// <summary>
        /// Méthode appelé quand on clique sur le sixième bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickButton6(object sender, RoutedEventArgs e)
        {
            parent.self.AddPlatChoisi(b6.Text);
            recap.Children.Clear();
            recap.Children.Add(new Recapitulatif(parent,true));
        }

    }
}