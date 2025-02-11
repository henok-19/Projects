using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cardeal
{
    public partial class sign : Form
    {
        private Home home;

        public sign()
        {
            InitializeComponent();
        }

        public sign(Home home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            signin s = new signin(home,this);
            s.TopLevel = false;
            panel1.Controls.Add(s);
            s.BringToFront();
            s.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Newacc n = new Newacc();
            n.TopLevel = false;
            panel1.Controls.Add(n);
            n.BringToFront();
            n.Show();

        }
    }
}
