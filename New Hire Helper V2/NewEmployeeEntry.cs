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
                textBox = "NULL";
                }
            return textBox;
        }

        string connectionString;
        public newEmployeeButton()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // connectionString = ConfigurationManager.ConnectionStrings["Data Source=(LocalDB)\\NewHireDatabase;AttachDbFilename=C:\\Users\andrewh\\Documents\\New Hire Helper\\New Hire Helper V2\\New Hire Helper V2\\NewHireDatabase.mdf;Integrated Security=True;Context Connection=False"].ConnectionString;
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

            string values = "(" + name + ", " + title + ", " + department + ", " + manager + ", " + location + ", " + startDate + ", " + orientation + ", " + workPhone + ", " + cellPhone + ")";

            string query = "INSTERT INTO Employee (name, title, department, manager, location, startDate, orientationLocation, workPhone, cellPhone) "+
                           "VALUES " + values;

            //MessageBox.Show(values);
            //MessageBox.Show(query);

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                
            }


        }
    }
}
