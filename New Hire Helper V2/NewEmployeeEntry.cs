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
    public partial class newEmployeeButton : Form
    {
        public string checkNull(string textBox)
        {
            if (textBox.Equals(""))
                {
                textBox = "null";
                }
            return textBox;
        }
        public newEmployeeButton()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Takes the values from the text boxes and puts them into strings
            string name = nameTextBox.Text;
            string title = jobTitleTextBox.Text;
            string department = departmentTextBox.Text;
            string manager = managerTextBox.Text;
            string location = locationTextBox.Text;
            string startDate = dateTextBox.Text;
            string orientation = orientationTextBox.Text;
            string workPhone = workPhoneTextBox.Text;
            string cellPhone = cellPhoneTextBox.Text;

            //checks to see if some of the text boxes are blank and chages their values to NULL if they are

            name = checkNull(name);
            title = checkNull(title);
            department = checkNull(department);
            manager = checkNull(manager);
            location = checkNull(location);
            startDate = checkNull(startDate);
            orientation = checkNull(orientation);
            workPhone = checkNull(workPhone);
            cellPhone = checkNull(cellPhone);


            //concatenates the values into a query so the values can be added as a record to the database

            string query = "INSERT INTO Employee (name, title, department, manager, location, startDate, orientationLocation, workPhone, cellPhone) " +
                           "VALUES (@name, @title, @department, @manager, @location, @startDate, @orientationLocation, @workPhone, @cellPhone)";

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("name", name);
                sc.Parameters.AddWithValue("title", title);
                sc.Parameters.AddWithValue("department", department);
                sc.Parameters.AddWithValue("manager", manager);
                sc.Parameters.AddWithValue("location", location);
                sc.Parameters.AddWithValue("startDate", startDate);
                sc.Parameters.AddWithValue("orientationLocation", orientation);
                sc.Parameters.AddWithValue("workPhone", workPhone);
                sc.Parameters.AddWithValue("cellPhone", cellPhone);

                scon.Open();
                sc.ExecuteNonQuery();


            }
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }
    }
}
