using Email_client.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_client.WinFormUI.Emails.Menus
{
    public partial class UserMenu : Form
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void UserMenu_Load(object sender, EventArgs e)
        {
            label1.Text = Connection.currentAccount.EmailAccount;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SignInEmail signInEmail = new SignInEmail();
            this.Hide();
            signInEmail.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signin = new SignIn();
            signin.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inbox inbox = new Inbox();
            inbox.Show();
        }
    }
}
