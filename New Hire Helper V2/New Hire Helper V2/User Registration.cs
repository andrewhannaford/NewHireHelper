using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace New_Hire_Helper_V2
{
    public partial class User_Registration : Form
    {
        public User_Registration()
        {
            InitializeComponent();
        }

        public string checkNull(string textBox)
        {
            if (textBox.Equals(""))
            {
                textBox = "null";
            }
            return textBox;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Takes the values from the text boxes and puts them into strings
            string email = checkNull(emailText.Text);
            string confirmEmail = checkNull(emailConfirmText.Text);
            string name = checkNull(nameText.Text);
            string password = checkNull(passwordText.Text);
            string confirmPassword = checkNull(passwordConfirmText.Text);
            string title = checkNull(titleComboBox.Text);

            //checks to make sure that the password and email are correct before trying to submit to the database
            if (email.Equals(confirmEmail) && password.Equals(confirmPassword) && !password.Equals("null") && !email.Equals("null"))
            {
                //concatenates the values into a query so the values can be added as a record to the database

                string query = "INSERT INTO Users (emailAddress, name, title, password) " +
                               "VALUES (@emailAddress,@name, @title, @password)";

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("name", name);
                    sc.Parameters.AddWithValue("emailAddress", email);
                    sc.Parameters.AddWithValue("title", title);
                    sc.Parameters.AddWithValue("password", password);
    
                    scon.Open();
                    sc.ExecuteNonQuery();


                }
                MainMenu menu = new MainMenu();
                menu.Show();
                this.Hide();
            }

            else if(!password.Equals(confirmPassword) && email.Equals(confirmEmail))
            {
                MessageBox.Show("Your password and confirmation password do not match.");
            }
            else if (!email.Equals(confirmEmail) && password.Equals(confirmPassword))
            {
                MessageBox.Show("Your email and confirmation email do not match.");
            }
            else
            {
                MessageBox.Show("Both your email and password do not match the confirmation email and password.");
            }
        }

        private void User_Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void User_Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
