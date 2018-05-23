using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Hire_Helper_V2
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            newEmployeeButton newEmployee = new newEmployeeButton();
            newEmployee.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewEmployeeList task = new NewEmployeeList();
            task.Show();
            this.Hide();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            userLabel.Text = User.getUserName();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User_Registration registration = new User_Registration();
            registration.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserLogin login = new UserLogin();
            login.Show();
            this.Hide();
        }
    }
}
