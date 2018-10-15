﻿using System;
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
            string query = "SELECT * from Task WHERE userTitle=@userTitle, ";
            DataSet data = new DataSet();

            using (SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))

            {
                SqlCommand sc = new SqlCommand(query, scon);
                sc.Parameters.AddWithValue("userTitle", User.getUserTitle());
                scon.Open();
                SqlDataAdapter da = new SqlDataAdapter(sc);
                da.Fill(data);
            }

           // taskCheckListBox data.Tables[0];

        }

        private void Task_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
