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
            string orientation = orientationTextBox.Text;
            string workPhone = workPhoneTextBox.Text;
            string cellPhone = cellPhoneTextBox.Text;

            //checks to see if some of the text boxes are blank and chages their values to NULL if they are

            name = checkNull(name);
            title = checkNull(title);
            department = checkNull(department);
            manager = checkNull(manager);
            location = checkNull(location);
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
                sc.Parameters.AddWithValue("startDate", startDate.Value);
                sc.Parameters.AddWithValue("orientationLocation", orientation);
                sc.Parameters.AddWithValue("workPhone", workPhone);
                sc.Parameters.AddWithValue("cellPhone", cellPhone);

                scon.Open();
                sc.ExecuteNonQuery();

            }


            //
            //This is the start of the huge insert of all of the tasks that are going to be generated every time a new hire comes on.
            //


            //This integer will help me determine the range of times that will be put in for the date to complete value in this table.
            int whenToComplete;

            //This will show if the new employee is an intern which will make certain tasks not be pushed into the table.
            bool intern = internCheckBox.Checked;

            //This will look for the new employee ID# that was assigned when they were pushed into the employee table.
            SqlDataReader reader;
            int employeeID = 0;
            query = "SELECT id FROM Employee WHERE name=@name";

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("name", name);
                scon.Open();
                reader = sc.ExecuteReader();
                if (reader.Read())
                {
                    employeeID = reader.GetInt32(0);
                }
            }

            //This will store the three dates that I will use throughout all of the tasks that I am going to be putting inside of this program. 
            DateTime preStartDate = startDate.Value.AddDays(-1);
            DateTime firstDay = startDate.Value;
            DateTime afterStart = startDate.Value.AddDays(1);

            //This is where all of the other variables have been declared so that we can reuse these references in all of the insert statements.

            //These are all of the user positions that the jobs will be assigned to
            string talentCoordinator = "Talent Acquisition Coordinator";
            string adminCoordinator = "Admin Coordinator";
            string CPO = "Chief People Officer";
            string it = "IT";
            string controller = "Controller";
            string accountant = "Accountant";
            string marketing = "Marketing";
            string officeManager = "Office Manager";


            string taskDescription = "Offer Details (Offer letter, EA, Benefits Summary, IT Menu";
            int taskGroupID = 1; 
            bool complete = false;

            query = "INSERT INTO Task (employeeID, userTitle, taskDescription, dateToComplete, taskGroupID, isCompleted) " +
                    "VALUES (@employeeID, @userTitle, @taskDescription, @dateToComplete, @taskGroupID, @isCompleted)";


            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", talentCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }

            taskDescription = "Send Internal Notification - Name, DOH, Manager, etc";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", talentCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }

            taskDescription = "Send Employee Information Form Request + Photo";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", talentCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }

            taskDescription = "Request Background Check ";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", talentCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Orientation Schedule Confirmed (Include Partner Source with Michelle) ";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", talentCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Schedule Orientation with Eric and Mike";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", talentCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Send New Team Member Lunch Request";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", talentCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Draft Bio and send to manager";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", talentCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Coordinate professional photo";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", talentCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", afterStart);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Assign a desk/Prep Workstation";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Keeper Setup";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Office Key (if applicable)";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Print Required Forms and place in Folder";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "SWAG Bag";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "ThinkHR - enroll in Cyber Security and Sexual Harassment Training";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Paperwork (I-9, W-4, state specific tax forms, etc.)";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", CPO);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", firstDay);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "E-Verify";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", firstDay);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Employee Handbook Review + Acknowledgement";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", CPO);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", firstDay);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Orientation Follow-up Communication & List of To-do's";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", firstDay);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Schedule 30 day check-in and PI/PLI Results";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", CPO);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Add 90 day review reminder to calendar";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", CPO);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Request Orientation Feedback";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", afterStart);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Enter in Paychex";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", afterStart);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Add Birthday & Anniversary Dates to Calendar";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", afterStart);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "OfficeVibe Group ";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", afterStart);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Email manager to add to new employee to Department Meetings";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Add to website";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", marketing);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", afterStart);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Write bio for website";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", marketing);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", afterStart);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Remind Michelle to set up in Partner Source";
            taskGroupID = 1;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", afterStart);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Add user in Active Directory";
            taskGroupID = 2;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "CRM Setup";
            taskGroupID = 3;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();


            }

            taskDescription = "Setup Office 365";
            taskGroupID = 4;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "SharePoint Access";
            taskGroupID = 4;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Distribution group";
            taskGroupID = 4;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Remind manager to add new employee to Planner Groups";
            taskGroupID = 4;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Skype for Business Set-up";
            taskGroupID = 4;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();




            }
            taskDescription = "Add Skype Contacts";
            taskGroupID = 4;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Quarterly Meeting Invites";
            taskGroupID = 4;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Team Meeting Requests (Fridays)";
            taskGroupID = 4;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Holidays";
            taskGroupID = 4;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Assign Manager in CRM";
            taskGroupID = 7;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Order Laptop";
            taskGroupID = 10;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Setup Laptop";
            taskGroupID = 5;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "OneDrive Setup";
            taskGroupID = 5;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Add Printers";
            taskGroupID = 5;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();


            }
            taskDescription = "Save AX RDP to a folder in OneDrive";
            taskGroupID = 5;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", it);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Computer to new hire location";
            taskGroupID = 6;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "CRM - PSA (Billable Resources only)";
            taskGroupID = 7;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "CRM - Holidays (Billable Resources only)";
            taskGroupID = 7;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "CRM - Add Birthday and Anniversary";
            taskGroupID = 7;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();


            }
            taskDescription = "Hire Employee and Setup User in AX";
            taskGroupID = 8;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Email Accounting when SSN is entered in AX to order Credit Card";
            taskGroupID = 9;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }
            taskDescription = "Add to Timesheet Workflow";
            taskGroupID = 9;

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);

                sc.Parameters.AddWithValue("employeeID", employeeID);
                sc.Parameters.AddWithValue("userTitle", officeManager);
                sc.Parameters.AddWithValue("taskDescription", taskDescription);
                sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                sc.Parameters.AddWithValue("isCompleted", complete);

                scon.Open();
                sc.ExecuteNonQuery();

            }

            //This is going to check to see if the new employee is an intern and not add these next items if they are.

            if (!internCheckBox.Checked) {

                taskDescription = "Add to Ease Central";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", officeManager);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", preStartDate);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();

                }
                taskDescription = "Order Business Cards";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();

                }
                taskDescription = "Order Blue Shirt";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", adminCoordinator);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();


                }
                taskDescription = "Order Jersey";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", officeManager);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();

                }
                taskDescription = "Add to Utilization Report";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", controller);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();

                }
                taskDescription = "Add to Scorecard";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", controller);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();

                }
                taskDescription = "Enter in BCBS of MN";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", officeManager);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();

                }
                taskDescription = "Enter in SunLife Dental App";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", officeManager);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();


                }
                taskDescription = "Enter in VSP";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", officeManager);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();

                }
                taskDescription = "Add to Principal Website";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", officeManager);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();

                }
                taskDescription = "Add to Select Account Website";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", officeManager);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();


                }
                taskDescription = "Add to SunLife Life and LTD";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", officeManager);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();

                }
                taskDescription = "QE form to USI";
                taskGroupID = 1;

                using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

                {
                    SqlCommand sc = new SqlCommand(query, scon);

                    sc.Parameters.AddWithValue("employeeID", employeeID);
                    sc.Parameters.AddWithValue("userTitle", officeManager);
                    sc.Parameters.AddWithValue("taskDescription", taskDescription);
                    sc.Parameters.AddWithValue("dateToComplete", afterStart);
                    sc.Parameters.AddWithValue("taskGroupID", taskGroupID);
                    sc.Parameters.AddWithValue("isCompleted", complete);

                    scon.Open();
                    sc.ExecuteNonQuery();

                }
            }


            //Then this brings it back to the main menu

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
