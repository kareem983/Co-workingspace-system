using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COWORKING
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ADD_button_Click(object sender, EventArgs e)
        {
            bool aircon = checkBox1.Checked;
            bool wifi = checkBox2.Checked;
            bool whiteboard = checkBox3.Checked;
            bool projector = checkBox4.Checked;
            bool drinks = checkBox5.Checked;
            try
            {
                string num = numberofchairs_textbox.Text;
                int numi = int.Parse(num);
            }
            catch(Exception ee)
            {
                MessageBox.Show("can't get letters in number of chairs");
                Console.WriteLine(ee.Message);
                return;
            }
            DateTime dateTime = dateTimePicker1.Value;
            decimal time1 = numericUpDown1.Value;
            decimal time2 = numericUpDown2.Value;
            if(time2<time1)
            {
                MessageBox.Show("time to can't be before time from");
                return;
            }
            MessageBox.Show("rent saved correct");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
