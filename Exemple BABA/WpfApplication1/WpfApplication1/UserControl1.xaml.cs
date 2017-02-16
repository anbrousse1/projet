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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }



        public string Prout
        {
            get { return (string)GetValue(ProutProperty); }
            set { SetValue(ProutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Prout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProutProperty =
            DependencyProperty.Register("Prout", typeof(string), typeof(UserControl1), new PropertyMetadata("pfff"));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnClicked(new MachinTrucEventArgs(this.Prout));
        }

        public event EventHandler<MachinTrucEventArgs> Clicked;

        void OnClicked(MachinTrucEventArgs args)
        {
            Clicked?.Invoke(this, args);
        }
    }
}
