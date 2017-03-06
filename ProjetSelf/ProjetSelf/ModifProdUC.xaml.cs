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
using Metier;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour ModifProdUC.xaml
    /// </summary>
    public partial class ModifProdUC : UserControl
    {
        public ModifProdUC()
        {
            InitializeComponent();
        }

        public string NomProd
        {
            get { return (string)GetValue(NomProdProperty); }
            set { SetValue(NomProdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NomProd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NomProdProperty =
            DependencyProperty.Register("NomProd", typeof(string), typeof(ModifProdUC), new PropertyMetadata("rien"));

        public DateTime effetProd
        {
            get { return (DateTime)GetValue(effetProdProperty); }
            set { SetValue(effetProdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for effetProd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty effetProdProperty =
            DependencyProperty.Register("effetProd", typeof(DateTime), typeof(ModifProdUC), new PropertyMetadata(0));


        public DateTime finProd
        {
            get { return (DateTime)GetValue(finProdProperty); }
            set { SetValue(finProdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for finProd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty finProdProperty =
            DependencyProperty.Register("finProd", typeof(DateTime), typeof(ModifProdUC), new PropertyMetadata(0));

        public string obsProd
        {
            get { return (string)GetValue(obsProdProperty); }
            set { SetValue(obsProdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for obsProd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty obsProdProperty =
            DependencyProperty.Register("obsProd", typeof(string), typeof(ModifProdUC), new PropertyMetadata(0));


        public EventHandler<ModifProdEventArgs> Clicked;

        void OnClicked(ModifProdEventArgs args)
        {
            Clicked?.Invoke(this, args);
        }


        private void supprimer_Click(object sender, RoutedEventArgs e)
        {
            OnClicked(new ModifProdEventArgs());
        }
    }

}
