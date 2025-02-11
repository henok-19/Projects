using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace cardeal
{
    public partial class Newacc : Form
    {
        public Newacc()
        {
            InitializeComponent();
        }
        public void save(string firstname,string lastname,string email,string password)
        {
    
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog= CarDataBase;Integrated Security=True");
            string q = "InsertToCustomer";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.CommandType=CommandType.StoredProcedure; 
            cmd.Parameters.AddWithValue("@FirstName", firstname);
            cmd.Parameters.AddWithValue("@LastName", lastname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                con.Open();
                MessageBox.Show("Succefully connected");
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(firstname + " ,has been Successfully Registered!!!");

                txtFirstname.Text = "";
                txtLastname.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            
        }

        private void rjButton1_Click(object sender, EventArgs e)
        { 
            Regex regex = new Regex(@"^[A-Z][a-z]+$");
            Regex reg = new Regex(@"^[A-Za-z]+[0-9]*@gmail.com$");
            if (string.IsNullOrEmpty(txtFirstname.Text))
            {
                errorProvider.SetError(txtFirstname, "First name is required");
                
            }
            else if (string.IsNullOrEmpty(txtLastname.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtLastname, "Last name is required");
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtEmail, "Email is required");
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtPassword, "Password is required");
            }
            else
            {
                errorProvider.Clear();
                if (regex.IsMatch(txtFirstname.Text))
                {
                    if (regex.IsMatch(txtLastname.Text))
                    {
                        if (reg.IsMatch(txtEmail.Text))
                        {
                            save(txtFirstname.Text, txtLastname.Text, txtEmail.Text, txtPassword.Text);
                        }
                        else
                        {
                            errorProvider.Clear();
                            errorProvider.SetError(txtEmail, "Correct format for Email is required");
                        }
                    }
                    else
                    {
                        errorProvider.Clear();
                        errorProvider.SetError(txtLastname, "Correct format of LastName is required");
                    }

                }
                else
                {
                    errorProvider.SetError(txtFirstname, "Correct format of FirstName is required");
                }
            }
        }
    }
}
