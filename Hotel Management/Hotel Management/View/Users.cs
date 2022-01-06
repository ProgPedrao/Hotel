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

namespace Hotel_Management
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            Populate();
        }

        private void Populate()
        {
            conn.Open();

            string Query = "Select * from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            UserDGV.DataSource = ds.Tables[0];

            conn.Close();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pedro\Documents\HotelDbase.mdf;Integrated Security=True;Connect Timeout=30");
        int key = 0;

        private void InsertUser()
        {
            if (UNameTb.Text == "" || UPhoneTb.Text == "" || UGenderCb.SelectedIndex == -1 || UPasswordTb.Text == "")
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("insert into UserTbl(UName,UPhone,UGender,UPassword) values(@UN,@UPhone,@UG,@UPass)", conn);

                    sqlCommand.Parameters.AddWithValue("@UN", UNameTb.Text);
                    sqlCommand.Parameters.AddWithValue("@UPhone", UPhoneTb.Text);
                    sqlCommand.Parameters.AddWithValue("@UG", UGenderCb.SelectedIndex.ToString());
                    sqlCommand.Parameters.AddWithValue("@UPass", UPasswordTb.Text);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("User inserted");

                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void EditUser()
        {
            if (UNameTb.Text == "" || UPhoneTb.Text == "" || UGenderCb.SelectedIndex == -1 || UPasswordTb.Text == "")
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("update UserTbl set UName=@UN,UPhone=@UPhone,UGender=@UG,UPassword=@UPass where UNum=@UKey", conn);

                    sqlCommand.Parameters.AddWithValue("@UN", UNameTb.Text);
                    sqlCommand.Parameters.AddWithValue("@UPhone", UPhoneTb.Text);
                    sqlCommand.Parameters.AddWithValue("@UG", UGenderCb.SelectedIndex.ToString());
                    sqlCommand.Parameters.AddWithValue("@UPass", UPasswordTb.Text);
                    sqlCommand.Parameters.AddWithValue("@UKey", key);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("user updated");

                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void DeleteUser()
        {
            if (key == 0)
            {
                MessageBox.Show("Select a category!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("delete from UserTbl where UNum=@UKey", conn);
                    sqlCommand.Parameters.AddWithValue("@UKey", key);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("user Deleted!");

                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void USaveBtn_Click(object sender, EventArgs e)
        {
            InsertUser();
        }

        private void UEditBtn_Click(object sender, EventArgs e)
        {
            EditUser();
        }

        private void UDeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UNameTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UPhoneTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            UGenderCb.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            UPasswordTb.Text = UserDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (UNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Types form = new Types();
            form.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Rooms form = new Rooms();
            form.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Customers form = new Customers();
            form.Show();
            this.Hide();
        }
    }
}
