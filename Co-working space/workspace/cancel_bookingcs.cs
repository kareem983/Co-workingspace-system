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
namespace workspace
{
    public partial class cancel_bookingcs : Form
    {
        SqlConnection con = new SqlConnection ("Data Source=localhost;Initial Catalog=milestone_project;Integrated Security=True");
        public cancel_bookingcs()
        {
            InitializeComponent();
        }

        private void cancel_bookingcs_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
       

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void circularButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = (string)textBox1.Text;
                if (name.Equals("") || name.Equals("Enter Your Reservation ID"))
                {
                    MessageBox.Show("This is Invalid Input Please Enter Reservation ID", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                else
                {
                    SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=milestone_project;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("del_reservation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@roomid", SqlDbType.Int);
                    cmd.Parameters["@roomid"].Value = Convert.ToInt32(this.textBox1.Text);
                    //cmd.Parameters.Add("@@res_iid", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    //string t = cmd.Parameters["@@res_iid"].Value.ToString();
                    //MessageBox.Show(t);
                    con.Close();
                    /* if (t == "")
                     {
                         MessageBox.Show("Reservation id: " + Convert.ToInt32(name) + " Dosn't Exsist", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;

                     }
                     else*/
                    MessageBox.Show("Your Reservation canceled successfully");
                    this.textBox1.Text = "";

                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            //if (name.Equals(" "))
            //{
            //    MessageBox.Show("Please Enter Reservation ID", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (name.Count() == 0)
            //{
            //    MessageBox.Show("Reservation id:"+ Convert.ToInt32(name)+"Dosn't Exsist", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;

            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
