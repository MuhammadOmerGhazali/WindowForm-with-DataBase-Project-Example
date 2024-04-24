using Email_client.BL;
using Inboxify_Backend.DL;
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

namespace Email_client
{
    public partial class ComposeEmail : Form
    {
        public ComposeEmail()
        {
            InitializeComponent();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            Email email = new Email(Connection.currentUser.Get_Email(), TextTo.Text, TextSubject.Text,TextBody.Text, TextFrom.Text,"Inbox");
            ObjectHandler.FileEmailDL.AddEmail(email);
            ObjectHandler.EmailDL.AddEmail(email);
            this.Hide();
            Inbox inbox = new Inbox();
            inbox.Show();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Email email = new Email(Connection.currentUser.Get_Email(), TextTo.Text, TextSubject.Text, TextBody.Text, TextFrom.Text, "Draft");
            ObjectHandler.EmailDL.AddEmail(email);
            this.Hide();
            Inbox inbox = new Inbox();
            inbox.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Email email = new Email(Connection.currentUser.Get_Email(), TextTo.Text, TextSubject.Text, TextBody.Text, TextFrom.Text, "Trash");
            ObjectHandler.EmailDL.AddEmail(email);
            this.Hide();
            Inbox inbox = new Inbox();
            inbox.Show();
        }
    }
}
