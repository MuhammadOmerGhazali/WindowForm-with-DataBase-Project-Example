using Email_client.BL;
using Inboxify_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_client.WinFormUI.AdminUI
{
    public partial class AdminDashBoard : Form
    {
        public string username = null;
        public string perms = null;
        public string password = null;
        public AdminDashBoard()
        {
            InitializeComponent();
        }
        private void TextStatSpam_TextChanged(object sender, EventArgs e)
        {

        }
        private void AdminDashBoard_Load(object sender, EventArgs e)
        {
            LoadUsersIntoDataGridView();
        }
        public void LoadUsersIntoDataGridView()
        {
            guna2DataGridView1.Rows.Clear();
            guna2DataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 14);
            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT username, perms, password FROM Users";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        // indices correspond to actual columns in the Emails table
                        string username = rdr.GetString(0);
                        string perms = rdr.GetString(1);
                        string password = rdr.GetString(2);

                        // Adding a new row to the DataGridView
                        guna2DataGridView1.Rows.Add(username, perms, password);
                    }
                }
            }
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

                username = row.Cells[0].Value.ToString();
                perms = row.Cells[1].Value.ToString();
                password = row.Cells[2].Value.ToString();

            }

        }
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            ObjectHandler.AdminDL.ChangetoAdmin(username);
            LoadUsersIntoDataGridView();
        }
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(BL.Connection.connectionString);
            connection.Open();
            try
            {
                string query = "DELETE FROM Users WHERE UserID = (SELECT UserID FROM Users WHERE username = @username)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@username", username));
                command.ExecuteNonQuery();
                LoadUsersIntoDataGridView();
                connection.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Deletion failed .Delete emails first");
            }


        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            updateStats();
            guna2Panel2.Visible = true;
        }
        private void updateStats()
        {
            SqlConnection connection = new SqlConnection(BL.Connection.connectionString);
            connection.Open();
            string query = "SELECT COUNT(*) AS PersonalAccountCount FROM Accounts WHERE AccountType = 'Personal'";
            SqlCommand command = new SqlCommand(query, connection);
            int personalAccountCount = (int)command.ExecuteScalar();
            query = "SELECT COUNT(*) AS BussinessAccountCount FROM Accounts WHERE AccountType = 'Bussiness'";
            SqlCommand cmd = new SqlCommand(query, connection);
            int bussinessAccountCount = (int)command.ExecuteScalar();
            double ratio = (double)personalAccountCount / bussinessAccountCount;
            int progressBarValue = (int)(ratio * 100);
            guna2ProgressBar2.Value = progressBarValue;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ObjectHandler.AdminDL.ChangetoEndUser(username);
            LoadUsersIntoDataGridView();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signin = new SignIn();
            signin.Show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
