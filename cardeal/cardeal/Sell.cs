﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace cardeal
{
    public partial class Sell : Form
    {
        public Sell()
        {
            InitializeComponent();

        }
        public void searchAgent(string location)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog= CarDataBase;Integrated Security=True");
            string q = "SearchAgentByLocation";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@location", location);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();
                int r = 0;
                while (sdr.Read())
                {
                    AgentInfo si = new AgentInfo();
                    si.Name = sdr["name"].ToString();
                    si.Location = sdr["Location"].ToString();
                    si.Phone = sdr["phone"].ToString();
                    si.Email = sdr["email"].ToString();

                    panel4.Controls.Add(si);

                    r++;
                }
                con.Close();
                
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }

        }
        public void submit(string name, int phone, string email, string message)
        {

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog= CarDataBase;Integrated Security=True");
            string q = "InsertSeller";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@message", message);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(name + " ,your message has been Successfully submitted!!!");
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtMessage.Text = "";

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            submit(txtName.Text,Convert.ToInt32(txtPhone.Text),txtEmail.Text,txtMessage.Text);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            searchAgent(cmbLocation.SelectedItem.ToString());
        }
    }
}
