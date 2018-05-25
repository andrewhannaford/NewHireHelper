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
    public partial class Task : Form
    {
        public Task()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Task_Load(object sender, EventArgs e)
        {
            string query = "SELECT task from Employee";
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
    }
}
