using Email_client.BL;
using Inboxify_Backend.BL.Emails;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Email_client.WinFormUI
{
    public partial class SignInEmail : Form
    {
        private string email =null;
        private string type =null;
        public SignInEmail()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SignUpEmail signUpEmail = new SignUpEmail();
            this.Hide();
            signUpEmail.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            this.Hide();
            signIn.Show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SignInEmail_Load(object sender, EventArgs e)
        {
            LoadUsersIntoDataGridView();
        }
        public void LoadUsersIntoDataGridView()
        {
            guna2DataGridView1.Rows.Clear();
            guna2DataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 14);
            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT Email, AccountType FROM Accounts WHERE User_Id = @User_Id";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@User_Id", Connection.currentUser.Get_Id());
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        // indices correspond to actual columns in the Emails table
                        string Email = rdr.GetString(0);
                        string AcccountType = rdr.GetString(1);
                        // Adding a new row to the DataGridView
                        guna2DataGridView1.Rows.Add(Email, AcccountType);
                    }
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

                email = row.Cells[0].Value.ToString();
                type = row.Cells[1].Value.ToString();
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            Account account = new Account(Connection.currentUser.Get_Id(),email,type);
            Connection.currentAccount = account;
            Inbox inbox = new Inbox();
            this.Hide();
            inbox.Show();
        }
    }
}
