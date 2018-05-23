using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace New_Hire_Helper_V2
{
    public static class  User
    {      

        private static int userID;
        private static string name;
        private static string title;

        //returns the userID that is retrieved and set to the field by the activeUser method
        public static int getUserID()
        {
            return userID;
        }

        public static string getUserName()
        {
            return name;
        }

        public static string getUserTitle()
        {
            return title;
        }


        //this method takes in user input and checks to see if a password matches for a given email. If it does it returns true, else false.
        public static bool activeUser(string email, string passwordCheck)
        {
            SqlDataReader reader;
            string password = "Error";
            bool test = false;
            string query = "SELECT password FROM Users WHERE emailAddress=@email";
            try
            {
                //checks the database using the email that was passed as an argument, then takes the password that is returned and checks it against the one the was
                //passed as an argument.
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("email", email);
                    scon.Open();
                    reader = sc.ExecuteReader();
                    if (reader.Read())
                    {
                        password = reader.GetString(0).Trim();
                    }
                }
            }
            catch(Exception ex)
            {

            }

            if (passwordCheck.Equals(password))
            {

                //Once the user has been verified it stores their userID so that they can see the tasks that they have to do.
                query = "SELECT id FROM Users WHERE emailAddress=@email";
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("email", email);
                    scon.Open();
                    reader = sc.ExecuteReader();
                    if (reader.Read())
                    {
                        User.userID = reader.GetInt32(0);
                    }
                }

                //stores the users name so that the program can greet them 
                query = "SELECT name FROM Users WHERE emailAddress=@email";
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("email", email);
                    scon.Open();
                    reader = sc.ExecuteReader();
                    if (reader.Read())
                    {
                        User.name = reader.GetString(0);
                    }
                }

                //Stores the users title so that the user knows what task their position needs to complete
                query = "SELECT title FROM Users WHERE emailAddress=@email";
                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("email", email);
                    scon.Open();
                    reader = sc.ExecuteReader();
                    if (reader.Read())
                    {
                        User.title = reader.GetString(0);
                    }
                }
                test = true;
            }
            return test;
            
        }
    }
}
