using Email_client.BL;
using Inboxify_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_client.WinFormUI.Emails
{
    public partial class ViewEmail : Form
    {
        public ViewEmail()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TextBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewEmail_Load(object sender, EventArgs e)
        {
            TextFrom.Text = Connection.currentEmail.Get_Sender();
            TextSubject.Text = Connection.currentEmail.Get_Email_Subject();
            TextBode.Text = Connection.currentEmail.Get_Email_Body();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ObjectHandler.EmailDL.UpdateTag("Trash");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ObjectHandler.EmailDL.UpdateTag("Archive");
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            ComposeEmail composeEmail = new ComposeEmail();
            this.Hide();
            composeEmail.Show();
        }
    }
}
