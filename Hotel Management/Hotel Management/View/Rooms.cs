using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hotel_Management.View;

namespace Hotel_Management
{
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
            Populate();
            GetCategories();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pedro\Documents\HotelDbase.mdf;Integrated Security=True;Connect Timeout=30");
        int key = 0;

        private void Populate()
        {
            conn.Open();

            string Query = "Select * from RoomTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            RoomsDGV.DataSource = ds.Tables[0];

            conn.Close();
        }


        private void InsertRooms()
        {
            if (RNameTb.Text == "" || RTypeCb.SelectedIndex == -1 || RStatusCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("insert into RoomTbl(RName,RType,RStatus) values(@RN,@RT,@RS)", conn);

                    sqlCommand.Parameters.AddWithValue("@RN", RNameTb.Text);
                    sqlCommand.Parameters.AddWithValue("@RT", RTypeCb.SelectedValue.ToString());
                    sqlCommand.Parameters.AddWithValue("@RS", "Available");
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Room Added!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void GetCategories()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from TypeTbl", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeNum", typeof(int));
            dt.Load(rdr);
            RTypeCb.ValueMember = "TypeNum";
            RTypeCb.DataSource = dt;

            conn.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertRooms();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Types fm = new Types();
            fm.Show();
            this.Hide();
        }

        private void EditRooms()
        {
            if (RNameTb.Text == "" || RTypeCb.SelectedIndex == -1 || RStatusCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("update RoomTbl set RName=@RN,RType=@RT,RStatus=@RS where RNum=@RKey", conn);

                    sqlCommand.Parameters.AddWithValue("@RN", RNameTb.Text);
                    sqlCommand.Parameters.AddWithValue("@RT", RTypeCb.SelectedIndex.ToString());
                    sqlCommand.Parameters.AddWithValue("@RS", RStatusCb.SelectedItem.ToString());
                    sqlCommand.Parameters.AddWithValue("@RKey", key);

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Room Updated!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    conn.Close();

                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteRooms()
        {
            if (key == 0)
            {
                MessageBox.Show("select a room!", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("delete from RoomTbl where RNum=@RKey", conn);
                    sqlCommand.Parameters.AddWithValue("@RKey", key);

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Room Deleted!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    conn.Close();

                    Populate();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RoomsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RNameTb.Text = RoomsDGV.SelectedRows[0].Cells[1].Value.ToString();
            RTypeCb.Text = RoomsDGV.SelectedRows[0].Cells[2].Value.ToString();
            RStatusCb.Text = RoomsDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (RNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(RoomsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditRooms();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteRooms();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Users form = new Users();
            form.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Customers form = new Customers();
            form.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Bookings form = new Bookings();
            form.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard form = new Dashboard();
            form.Show();
            this.Hide();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }
    }
}
