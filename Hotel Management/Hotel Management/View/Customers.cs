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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            Populate();
        }

        private void Populate()
        {
            conn.Open();

            string Query = "Select * from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            CustomerDGV.DataSource = ds.Tables[0];

            conn.Close();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pedro\Documents\HotelDbase.mdf;Integrated Security=True;Connect Timeout=30");
        int key = 0;

        private void InsertCustomer()
        {
            if (CNametb.Text == "" || CGenderCb.SelectedIndex == -1 || CPhoneTb.Text == "")
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("insert into CustomerTbl(CustName,CustGender,CustPhone) values(@CN,@CG,@CP)", conn);

                    sqlCommand.Parameters.AddWithValue("@CN", CNametb.Text);
                    sqlCommand.Parameters.AddWithValue("@CG", CGenderCb.SelectedIndex.ToString());
                    sqlCommand.Parameters.AddWithValue("@CP", CPhoneTb.Text);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Customer inserted");

                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void EditCustomer()
        {
            if (CNametb.Text == "" || CGenderCb.SelectedIndex == -1 || CPhoneTb.Text == "")
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("update CustomerTbl set CustName=@CN,CustPhone=@CP,CustGender=@CG where CustNum=@CKey", conn);

                    sqlCommand.Parameters.AddWithValue("@CN", CNametb.Text);
                    sqlCommand.Parameters.AddWithValue("@CG", CGenderCb.SelectedIndex.ToString());
                    sqlCommand.Parameters.AddWithValue("@CP", CPhoneTb.Text);
                    sqlCommand.Parameters.AddWithValue("@CKey", key);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Customer updated");

                    conn.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        private void DeleteCustomer()
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

                    SqlCommand sqlCommand = new SqlCommand("delete from CustomerTbl where CustNum=@CKey", conn);
                    sqlCommand.Parameters.AddWithValue("@CKey", key);
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

        private void CSaveBtn_Click(object sender, EventArgs e)
        {
            InsertCustomer();
        }

        private void CEditBtn_Click(object sender, EventArgs e)
        {
            EditCustomer();
        }

        private void CDeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }

        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CNametb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            CPhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            CGenderCb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (CNametb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CustomerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
