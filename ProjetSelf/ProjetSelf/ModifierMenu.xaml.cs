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
    /// Logique d'interaction pour ModifierMenu.xaml
    /// </summary>
    public partial class ModifierMenu : UserControl
    {
        private MainWindow parent;
        private AbsMenu menu;
        private int nbDessert=0;
        private int nbPlat=0;
        private int nbEntree=0;

        public System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat> platsMenuROC
        {
            get;
            private set;
        }
        private List<AbsPlat> plats= new List<AbsPlat>();
        public ModifierMenu(MainWindow m, AbsMenu me)
        {
            menu = me;
            parent = m;
            
            plats= me.getPlats();
            initialiserNombre();
            platsMenuROC = new System.Collections.ObjectModel.ReadOnlyCollection<AbsPlat>(plats);
            DataContext = parent.self;
            InitializeComponent();
            listPlat.DataContext = this;
            
        }

        private void ajouterPlatMenuClick(object sender, RoutedEventArgs e)
        {
            if (SelectPlat.SelectedItem == null) { MessageBox.Show("Veuillez sélectionner un plat"); return; }
            else
            {
                AbsPlat p = ((AbsPlat)SelectPlat.SelectedItem);
                if (plats.Contains(p))
                {
                    MessageBox.Show("Le plat sélectionné est déjà présent dans ce menu");
                    return;
                }
                if (categoryControl((AbsPlat)SelectPlat.SelectedItem))
                {
                    plats.Add((AbsPlat)SelectPlat.SelectedItem);
                    listPlat.Items.Refresh();
                }
            }
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            parent.setUC(new GestionMenu(parent));
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            if (plats.Count != 0)
            {
                parent.self.modifierPlatsMenu(menu, plats);
                MessageBox.Show("Modification effectuée");
                parent.setUC(new VisualitationMenu(parent));
            }else
            {
                MessageBox.Show("Le  menu doit être composé d'au moins un plat");
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AbsPlat p = ((AbsPlat)((ListView)sender).SelectedItem);
            if (p != null)
            {
                switch (p.Categorie)
                {
                    case CategoriePlat.Plat:
                        nbPlat--;
                        break;
                    case CategoriePlat.Entree:
                        nbEntree--;
                        break;
                    case CategoriePlat.Dessert:
                        nbDessert--;
                        break;
                }
                plats.Remove(p);
            }
            refreshList();
        }

        private void refreshList()
        {
            listPlat.Items.Refresh();
        }

        private void initialiserNombre()
        {
            foreach(AbsPlat p in plats)
            {
                categoryControl(p);
            }
        }

        private Boolean categoryControl(AbsPlat p)
        {
            switch (p.Categorie)
            {
                case CategoriePlat.Plat:
                    if (nbPlat == 6){MessageBox.Show("Vous avez déjà ajouté le nombre maximum de desserts(6)"); return false;}
                        nbPlat++;
                    break;
                case CategoriePlat.Entree:
                    if(nbEntree == 6) {MessageBox.Show("Vous avez déjà ajouté le nombre maximum de desserts(6)"); return false; }
                    nbEntree++;
                    break;
                case CategoriePlat.Dessert:
                    if (nbDessert == 6) { MessageBox.Show("Vous avez déjà ajouté le nombre maximum de desserts(6)"); return false; }
                    nbDessert++;
                    break;
            }
            return true;
        }


    }
}
