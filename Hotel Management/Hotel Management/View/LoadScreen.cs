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
    public partial class LoadScreen : Form
    {
        public LoadScreen()
        {
            InitializeComponent();
            timer1.Start();
        }

        int StartP = 0;

        private void timer1_Tick(object sender, EventArgs e)
         {
            StartP += 1;
            ProgressCirc.Value = StartP;

            if (ProgressCirc.Value == 100)
            {
                Login form = new Login();

                ProgressCirc.Value = 0;
                timer1.Stop();

                form.Show();
                this.Hide();
            }
        }
    }
}
