using Email_client.BL;
using Email_client.WinFormUI;
using Email_client.WinFormUI.AdminUI;
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
            if (RadioAdmin.Checked) 
            {
                if (ObjectHandler.AdminDL.Check_Credentials(textEmail.Text, textPassword.Text) != null)
                {
                    AdminDashBoard adminDashBoard = new AdminDashBoard();
                    this.Hide();
                    adminDashBoard.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect credtionals");
                }
            }
            else
            {
                if (ObjectHandler.EndUserDL.Check_Credentials(textEmail.Text, textPassword.Text) != null)
                {
                    SignInEmail signInEmail = new SignInEmail();
                    Connection.currentUser = ObjectHandler.EndUserDL.FillInfo(textEmail.Text, textPassword.Text);
                    this.Hide();
                    signInEmail.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect credtionals");
                }
            }

        }
    }
}
