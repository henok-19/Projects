﻿using System;
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
    public partial class H : Form
    {
        private Home home;

        public H()
        {
            InitializeComponent();
        }
        public H(string email, Home home)
        {
            InitializeComponent();
            if (email == "Sign in")
                lblSignin.Text = "Sign in";
            else
            {
                lblSignin.Text = email;
                lblLogOut.Text = "Log out";
                this.home = home;
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {
            sign s = new sign();
            s.Show();
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            if (lblLogOut.Text == "Log out")
            {
                Home h = new Home();
                h.Show();
                home.Hide();
            }
        }
    }
}
