using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vue
{
    public partial class Aide : Form
    {
        string uc;
        public Aide(string uc)
        {
            this.uc = uc;
            InitializeComponent();
            label1.Text = "Aide";
            
            setText();
        }

        public void setText()
        {
            switch (uc)
            {
                case "Connexion": label.Text = "Voici l'écran de connexion";
                    label1.Text += " Connexion";
                    break;
                case "Vue.Caisse": label.Text = "Voici l'écran de la caisse et c'est Jérémy qui va le finir !";
                    label1.Text += " Caisse";
                    break;
                case "Vue.AccueilGerant": label.Text = "Voici l'écran de l'accueil du gérant !\n Si vous êtes ici, c'est que vous êtes le gérant de cette application : c'est plutot cool non ? \n" + 
                        "Dans le cas contraire veuillez immédiatement quitter cette application !  ";
                    label1.Text += " Gérant";
                    break;


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
