using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;

namespace New_Hire_Helper_V2
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = emailText.Text;
            string password = "Error";
            SqlDataReader reader;
            string query = "SELECT password FROM Users WHERE emailAddress=@email";

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("email", email);
                scon.Open();
                reader = sc.ExecuteReader();
                if (reader.Read())
                {
                    password = reader.GetString(0);
                }  
            }          

            if (!email.Equals(""))
                {

                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp-mail.outlook.com");

                    mail.From = new MailAddress("DoNotReply@stoneridgesoftware.com");
                    mail.To.Add(email);
                    mail.Subject = "Password Recovery";
                    mail.Body = "Your password is: " + password + "." + "\n" 
                       + "Make sure to keep this password safe for future use.";
                    SmtpServer.Port = 587;
                    SmtpServer.UseDefaultCredentials = false;
                    //We need to change these credentials later once I leave stoneridge
                    SmtpServer.Credentials = new System.Net.NetworkCredential("andrewh@stoneridgesoftware.com", "EYBusiness0");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                    MessageBox.Show("Password recovery email has been sent. \n Make sure to check your spam folder.");

                    UserLogin login = new UserLogin();
                    login.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The email address that you have entered is not valid.");
                }

            }
            else
            {
                MessageBox.Show("Please enter your email address.");
            }
        }

        private void ForgotPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Hide();
        }
    }
}
