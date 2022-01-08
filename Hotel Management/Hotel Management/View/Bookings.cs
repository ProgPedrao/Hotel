using Hotel_Management.View;
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
    public partial class Bookings : Form
    {
        public Bookings()
        {
            InitializeComponent();
            Populate();
            GetRooms();
            GetCustomers();
        }

        private void Populate()
        {
            conn.Open();

            string Query = "Select * from BookingTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            BookingsDGV.DataSource = ds.Tables[0];

            conn.Close();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory + @"\HotelDbase.mdf ;Integrated Security=True;Connect Timeout=30");

        int key = 0;

        private void GetRooms()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from RoomTbl where RStatus='available'", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RNum", typeof(int));
            dt.Load(rdr);
            RoomCb.ValueMember = "RNum";
            RoomCb.DataSource = dt;

            conn.Close();
        }

        private void GetCustomers()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from CustomerTbl", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustNum", typeof(int));
            dt.Load(rdr);
            CustomerCb.ValueMember = "CustNum";
            CustomerCb.DataSource = dt;

            conn.Close();
        }

        int price = 1;
        private void fetcheCost()
        {
            conn.Open();
            string Query = "select TypeCost from RoomTbl join TypeTbl on RType=TypeNum where RNum=" + RoomCb.SelectedValue.ToString() + "";
            SqlCommand sqlCommand = new SqlCommand(Query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                price = Convert.ToInt32(dr["TypeCost"].ToString());
            }

            conn.Close();
        }

        private void BookBtn_Click(object sender, EventArgs e)
        {
            if (CustomerCb.SelectedIndex == -1 || RoomCb.SelectedIndex == -1 || AmountTb.Text == "")
            {
                MessageBox.Show("missing information!");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("insert into BookingTbl(Room,Customer,BookDate,Duration,Cost) values(@BR,@BC,@BBD,@BD,@BCost)");
                    sqlCommand.Connection = conn;

                    sqlCommand.Parameters.AddWithValue("@BR", RoomCb.SelectedValue.ToString());
                    sqlCommand.Parameters.AddWithValue("@BC", CustomerCb.SelectedValue.ToString());
                    sqlCommand.Parameters.AddWithValue("@BBD", BDate.Value.Date);
                    sqlCommand.Parameters.AddWithValue("@BD", DurationTb.Text);
                    sqlCommand.Parameters.AddWithValue("@BCost", AmountTb.Text.Replace("R$", ""));

                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Booking Added!!!");
                    conn.Close();
                    Populate();
                    setBooked();
                    GetRooms();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CancelBooking();
            setAvailable();
        }

        private void CancelBooking()
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

                    SqlCommand sqlCommand = new SqlCommand("delete from BookingTbl where BookNum=@BKey", conn);
                    sqlCommand.Parameters.AddWithValue("@BKey", key);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Customer Deleted!");

                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void setBooked()
        {
            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand("update RoomTbl set RStatus=@RS where RNum=@RKey", conn);

                sqlCommand.Parameters.AddWithValue("@RS", "Booked");
                sqlCommand.Parameters.AddWithValue("@RKey", RoomCb.SelectedValue.ToString());

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

        private void setAvailable()
        {
            try
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand("update RoomTbl set RStatus=@RS where RNum=@RKey", conn);

                sqlCommand.Parameters.AddWithValue("@RS", "Available");
                sqlCommand.Parameters.AddWithValue("@RKey", RoomCb.Text);

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

        private void BookingsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RoomCb.Text = BookingsDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustomerCb.Text = BookingsDGV.SelectedRows[0].Cells[2].Value.ToString();
            BDate.Text = BookingsDGV.SelectedRows[0].Cells[3].Value.ToString();
            DurationTb.Text = BookingsDGV.SelectedRows[0].Cells[4].Value.ToString();
            AmountTb.Text = BookingsDGV.SelectedRows[0].Cells[5].Value.ToString();

            if (DurationTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BookingsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void RoomCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetcheCost();
        }

        private void DurationTb_TextChanged(object sender, EventArgs e)
        {
            if (DurationTb.Text != "")
            {
                try
                {
                    int total = price * Convert.ToInt32(DurationTb.Text);
                    AmountTb.Text = "R$" + total;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                AmountTb.Text = "";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Rooms form = new Rooms();
            form.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Types form = new Types();
            form.Show();
            this.Hide();
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
