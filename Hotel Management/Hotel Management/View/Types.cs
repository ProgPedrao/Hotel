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
    public partial class Types : Form
    {
        public Types()
        {
            InitializeComponent();
            Populate();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\pedro\Documents\HotelDbase.mdf;Integrated Security=True;Connect Timeout=30");

        private void Populate()
        {
            conn.Open();

            string Query = "Select * from TypeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            TypesDGV.DataSource = ds.Tables[0];

            conn.Close();
        }


        private void InsertCategories()
        {
            if (TypeNameTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    conn.Open();

                    SqlCommand sqlCommand = new SqlCommand("insert into TypeTbl(TypeName,TypeCost) values(@TN,@TC)", conn);

                    sqlCommand.Parameters.AddWithValue("@TN", TypeNameTb.Text);
                    sqlCommand.Parameters.AddWithValue("@TC", CostTb.Text);
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("completed");

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
            InsertCategories();
        }
    }
}
