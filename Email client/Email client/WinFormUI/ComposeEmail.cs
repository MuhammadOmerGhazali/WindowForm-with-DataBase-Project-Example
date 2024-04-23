using Email_client.BL;
using Inboxify_Backend.DL;
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
            Email email = new Email(Connection.currentUser.Get_Email(), TextTo.Text, TextSubject.Text,TextBody.Text, TextFrom.Text,"Sent");
            Inboxify_Backend.DL.EmailDL.AddEmail(email);
            this.Hide();
            Inbox inbox = new Inbox();
            inbox.Show();

        }
    }
}
