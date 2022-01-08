using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pedro\Documents\HotelDbase.mdf;Integrated Security=True;Connect Timeout=30");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where UName='" + LoginNameTb.Text + "' and UPassword='" + LoginPasswordTb.Text + "'",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                Rooms form = new Rooms();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Login or password!");
            }

            conn.Close();
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            LoginAdmin form = new LoginAdmin();
            form.Show();
            this.Hide();
        }
    }
}
