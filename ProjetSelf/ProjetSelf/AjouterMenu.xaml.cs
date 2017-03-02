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
    /// Logique d'interaction pour AjouterMenu.xaml
    /// </summary>
    public partial class AjouterMenu : UserControl
    {
        private MainWindow parent;
        public System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat> platsMenuROC
        {
            get;
            private set;
        }
        private List<AbsPlat> platsMenu = new List<AbsPlat>();

        private int nbEntree = 0;
        private int nbPlat = 0;
        private int nbDessert = 0;

        public AjouterMenu(MainWindow m)
        {
            platsMenuROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(platsMenu);
            parent = m;
            parent.self.chargeEntrPlatDes();
            DataContext = parent.self;
            InitializeComponent();

        }

        private void ajouterPlatClick(object sender, RoutedEventArgs e)
        {
            if (nbPlat != 6)
            {
                Plat p = (Plat)plat.SelectedItem;
                if (p == null)
                {
                    MessageBox.Show("Veuillez sélectionner un plat");
                }
                else
                {
                    if (platsMenu.Contains(p))
                    {
                        MessageBox.Show("Ce plat a déjà était ajouté");
                    }
                    else
                    {
                        platsMenu.Add(p);
                        nbPlat++;
                        plats.Children.Clear();
                        plats.Children.Add(new SimpleListePlat(this));
                    }
                }
            }else
            {
                MessageBox.Show("Nombre limite de plats atteint(6)");
            }
           
        }

        private void ajouterEntreeClick(object sender, RoutedEventArgs e)
        {
            if (nbEntree != 6)
            {
                Plat p = (Plat)entree.SelectedItem;
                if (p == null)
                {
                    MessageBox.Show("Veuillez sélectionner une entree");
                }
                else
                {
                    if (platsMenu.Contains(p))
                    {
                        MessageBox.Show("Ce plat a déjà était ajouté");
                    }
                    else
                    {
                        platsMenu.Add(p);
                        nbEntree++;
                        plats.Children.Clear();
                        plats.Children.Add(new SimpleListePlat(this));
                    }
                }

            }
           else
            {
                MessageBox.Show("Nombre limite d'entrées atteint(6)");
            }
        }

        private void ajouterDessertClick(object sender, RoutedEventArgs e)
        {
            if (nbDessert != 6)
            {
                Plat p = (Plat)dessert.SelectedItem;
                if (p == null)
                {
                    MessageBox.Show("Veuillez sélectionner un dessert");
                }
                else
                {
                    if (platsMenu.Contains(p))
                    {
                        MessageBox.Show("Ce plat a déjà était ajouté");
                    }
                    else
                    {
                        platsMenu.Add(p);
                        nbDessert++;
                        plats.Children.Clear();
                        plats.Children.Add(new SimpleListePlat(this));
                    }
                }
            }
            else
            {
                MessageBox.Show("Nombre limite de desserts atteint(6)");
            }
        }

        public void supprimerPlat(Plat p)
        {
            platsMenu.Remove(p);
            plats.Children.Clear();
            plats.Children.Add(new SimpleListePlat(this));
        }

        private void ajouterMenuClick(object sender, RoutedEventArgs e)
        {
            if (platsMenu.Count == 0)
            {
                MessageBox.Show("Vous devez ajouter au moins un plat au menu");
            }else
            {
                if (!nomM.Text.Equals(""))
                {
                    parent.self.addMenu(nomM.Text, platsMenu);
                    parent.setUC(new GestionMenu(parent));
                }
                else { MessageBox.Show("Veuillez entrer un nom pour votre menu"); }
                
            }
        }
    }



}
