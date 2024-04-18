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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Hide();
            signUp.Show();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            BL.Connection.currentUser = DL.UsersDL.Check_Credentials(textEmail.Text, textPassword.Text);
            if (BL.Connection.currentUser != null ) 
            {
                Inbox signUp = new Inbox();
                this.Close();
                signUp.Show();
            }
            else
            {
                MessageBox.Show("Incorrect credtionals");
            }
        }
    }
}
