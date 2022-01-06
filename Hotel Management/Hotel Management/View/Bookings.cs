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

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pedro\Documents\HotelDbase.mdf;Integrated Security=True;Connect Timeout=30");
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

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {

        }

        private void BookingsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RoomCb.Text = BookingsDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustomerCb.Text = BookingsDGV.SelectedRows[0].Cells[2].Value.ToString();
            DurationTb.Text = BookingsDGV.SelectedRows[0].Cells[3].Value.ToString();
            AmountTb.Text = BookingsDGV.SelectedRows[0].Cells[4].Value.ToString();
            BDate.Text = BookingsDGV.SelectedRows[0].Cells[5].Value.ToString();

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

                    throw;
                }
            }
            else
            {
                AmountTb.Text = "R$ 0";
            }
        }
    }
}
