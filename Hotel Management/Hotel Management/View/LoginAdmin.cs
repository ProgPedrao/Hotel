using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management.View
{
    public partial class LoginAdmin : Form
    {
        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Login form = new Login();

            form.Show();
            this.Hide();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (LoginPasswordTb.Text == "")
            {
                MessageBox.Show("Enter password!");
            }
            else
            {
                if (LoginPasswordTb.Text == "Password")
                {
                    Users form = new Users();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Password!");
                }
            }
        }
    }
}
