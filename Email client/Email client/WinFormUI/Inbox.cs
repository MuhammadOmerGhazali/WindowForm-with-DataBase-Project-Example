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
    }
}
