using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Vue
{
    public partial class ValidationQuitter : Form
    {
        MainWindow parent;
        public ValidationQuitter(MainWindow m)
        {
            InitializeComponent();
            parent = m;
        }


        private void clickOui(object sender, EventArgs e)
        {
            parent.Close();
        }

        private void clickNon(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
