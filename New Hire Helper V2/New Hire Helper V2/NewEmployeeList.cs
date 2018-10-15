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
    public partial class NewEmployeeList : Form
    {
        public NewEmployeeList()
        {
            InitializeComponent();
        }

        private void Task_Load(object sender, EventArgs e)
        {
            //This loads all of the names to the list box so that a user can select an employee and go to the tasks that they have that are related to them
            string query = "SELECT * from Employee";
            DataSet data = new DataSet();

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);
                scon.Open();
                SqlDataAdapter da = new SqlDataAdapter(sc);
                da.Fill(data);
            }
            listBox1.DataSource = data.Tables[0];
            listBox1.DisplayMember = "Name";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Hide();
        }

        private void Task_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This takes the name of the employee and returns their ID# which can be used to return the tasks that the user may have that relate to them 
            String name = listBox1.SelectedItem.ToString();
            string query = "SELECT id from Employee WHERE name=@name";
            SqlDataReader reader;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);
                sc.Parameters.AddWithValue("name", name);
                scon.Open();
                reader = sc.ExecuteReader();
                if (reader.Read())
                {
                   //REPLACE  = reader.GetString(0);
                }
            }

            Task task = new Task();
            task.Show();
            this.Hide();
        }
    }
}
