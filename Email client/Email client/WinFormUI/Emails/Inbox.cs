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
using Email_client.WinFormUI.Emails.Menus;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Guna.UI2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Inboxify_Backend.Interfaces;
using Email_client.WinFormUI.Emails;

namespace Email_client
{
    public partial class Inbox : Form
    {
        private string current_tag = "Inbox";
        private string search = null;
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
            LoadEmailsIntoDataGridView(current_tag);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                string Sender = row.Cells[0].Value.ToString();
                string Subject = row.Cells[1].Value.ToString();
                Email email = ObjectHandler.EmailDL.GetEmail(Sender,Connection.currentUser.Get_Email(),Subject);
                if (email != null)
                {
                    Connection.currentEmail = email;
                    guna2Button5.Visible = true;
                    guna2Button3.Visible = true;
                }

            }
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            HelpMenu helpMenu = new HelpMenu();
            helpMenu.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LoadEmailsIntoDataGridView(current_tag);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UserMenu userMenu = new UserMenu();
            this.Hide();
            userMenu.Show();
        }

        private void buttonInbox_Click(object sender, EventArgs e)
        {
            current_tag = "Inbox";
            LoadEmailsIntoDataGridView(current_tag);
        }

        private void buttonSentMail_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.DefaultCellStyle.Font = new Font("Century Gothic", 14);
            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT Receiver, Subject, Date FROM Emails WHERE Sender = @Sender AND Tag = @Tag";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Sender", Connection.currentUser.Get_Email());
                cmd.Parameters.AddWithValue("@Tag", "Inbox");

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        // indices correspond to actual columns in the Emails table
                        string Receiver = rdr.GetString(0);
                        string subject = rdr.GetString(1);
                        DateTime date = rdr.GetDateTime(2);

                        // Adding a new row to the DataGridView
                        dataGridView.Rows.Add(Receiver, subject, date);
                    }
                }
            }
        }

        private void buttonDrafts_Click(object sender, EventArgs e)
        {
            current_tag = "Draft";
            LoadEmailsIntoDataGridView(current_tag);
        }

        private void buttonArchivedMails_Click(object sender, EventArgs e)
        {
            current_tag = "Archive";
            LoadEmailsIntoDataGridView(current_tag);
        }

        private void buttonSpam_Click(object sender, EventArgs e)
        {
            current_tag = "Spam";
            LoadEmailsIntoDataGridView(current_tag);
        }

        private void button_Click(object sender, EventArgs e)
        {
            current_tag = "Trash";
            LoadEmailsIntoDataGridView(current_tag);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            search = guna2TextBox1.Text;
            dataGridView.Rows.Clear();
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.DefaultCellStyle.Font = new Font("Century Gothic", 14);
            SqlConnection con = new SqlConnection(Connection.connectionString);
            con.Open();
            string query = "SELECT Sender, Subject, Date FROM Emails WHERE Sender = @Sender";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Sender", search);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        // indices correspond to actual columns in the Emails table
                        string sender1 = rdr.GetString(0);
                        string subject = rdr.GetString(1);
                        DateTime date = rdr.GetDateTime(2);

                        // Adding a new row to the DataGridView
                        dataGridView.Rows.Add(sender1, subject, date);
                    }
                }
            }

        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                string Sender = row.Cells[0].Value.ToString();
                string Subject = row.Cells[1].Value.ToString();
                Email email = ObjectHandler.EmailDL.GetEmail(Sender, Connection.currentUser.Get_Email(), Subject);
                if (email != null)
                {
                    Connection.currentEmail = email;
                    ViewEmail viewEmail = new ViewEmail();
                    viewEmail.Show();
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            ObjectHandler.EmailDL.UpdateTag("Trash");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ObjectHandler.EmailDL.UpdateTag("Archive");
        }
    }
}
