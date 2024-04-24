using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Email_client.BL;
using Inboxify_Backend.Interfaces;



namespace Email_client
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void labelSignIn_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            this.Hide();
            signIn.Show();
        }

        private void ButtonSignUp_Click(object sender, EventArgs e)
        {
            Users user = new Users(textEmail.Text,textPassword.Text, "EndUser");
            ObjectHandler.AdminDL.Add_User(user);
        }
    }
}
