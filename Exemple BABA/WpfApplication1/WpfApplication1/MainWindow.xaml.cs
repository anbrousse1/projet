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

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            laListBox.ItemsSource = MaListe;
        }

        private void UserControl1_Clicked(object sender, MachinTrucEventArgs e)
        {
            laTextBlock.Text = $"{(sender as UserControl1).Prout} - {e.TheProut}";
        }

        public static List<UneClasse> MaListe = new List<UneClasse>()
        {
            new UneClasse { UnTexte = "truc" },
            new UneClasse { UnTexte = "muche" },
            new UneClasse { UnTexte = "machin" }
        };
    }
}
