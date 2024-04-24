using Email_client.BL;
using Inboxify_Backend.BL.Emails;
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

namespace Email_client.WinFormUI
{
    public partial class SignUpEmail : Form
    {
        public SignUpEmail()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            this.Hide();
            signIn.Show();
        }

        private void ButtonSignUp_Click(object sender, EventArgs e)
        {
            Account account = new Account(Connection.currentUser.Get_Id(), textEmail.Text, guna2ComboBox1.Text);
            Connection.currentAccount = account;
            ObjectHandler.EmailAccountDL.Add_Account(account);
            this.Hide();
            SignInEmail signInEmail = new SignInEmail();
            signInEmail.Show();
            /*
            Inbox inbox = new Inbox();
            inbox.Show();
            */
        }
    }
}
