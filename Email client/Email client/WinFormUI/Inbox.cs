using Email_client.BL;
using Inboxify_Backend.DL;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Xml.Linq;

namespace Email_client
{
    public partial class Inbox : Form
    {
        public Inbox()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonCompose_Click(object sender, EventArgs e)
        {
            ComposeEmail signUp = new ComposeEmail();
            this.Hide();
            signUp.Show();
        }

        private void Inbox_Load(object sender, EventArgs e)
        {
            AccountName.Text = BL.Connection.currentUser.Get_Email();
            LoadEmailsIntoDataGridView("Inbox");
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadEmailsIntoDataGridView(string tag)
        {
            dataGridView.Rows.Clear();
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.DefaultCellStyle.Font = new Font("Century Gothic", 14);
            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT Sender, Subject, Date FROM Emails WHERE Receiver = @Receiver AND Tag = @Tag" ;

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Receiver", Connection.currentUser.Get_Email());
                cmd.Parameters.AddWithValue("@Tag", tag);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        // indices correspond to actual columns in the Emails table
                        string sender = rdr.GetString(0);
                        string subject = rdr.GetString(1);
                        DateTime date = rdr.GetDateTime(2);

                        // Adding a new row to the DataGridView
                        dataGridView.Rows.Add(sender, subject, date);
                    }
                }
            }
        }
    }
}
