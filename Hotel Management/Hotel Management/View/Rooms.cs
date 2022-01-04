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

namespace Hotel_Management
{
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pedro\Documents\HotelDbase.mdf;Integrated Security=True;Connect Timeout=30");

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
                    sqlCommand.Parameters.AddWithValue("@RT", RTypeCb.SelectedIndex.ToString());
                    sqlCommand.Parameters.AddWithValue("@RS", "Available");
                    sqlCommand.ExecuteNonQuery();

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertRooms();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Types fm = new Types();
            fm.Show();
        }
    }
}
