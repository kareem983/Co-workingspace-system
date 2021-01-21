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
    public partial class sendnotification : Form
    {
        public sendnotification()
        {
            InitializeComponent();
            textBox1.ForeColor = Color.MediumAquamarine;
            textBox2.ForeColor = Color.MediumAquamarine;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // send_notification(int.Parse(this.textBox2.Text), this.textBox1.Text);

            //try
            //{
            int id = int.Parse(this.textBox2.Text);
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=milestone_project;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("notification", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@s_id", SqlDbType.Int);
            cmd.Parameters.Add("@@msg", SqlDbType.NChar, 100).Direction = ParameterDirection.Output;

            cmd.Parameters["@s_id"].Value = id;

            cmd.ExecuteNonQuery();
            string msg;
            msg = cmd.Parameters["@@msg"].Value.ToString();
            this.textBox1.Text = msg;

            MessageBox.Show("The notification with id :"+id +" is: "+ msg);
            this.textBox2.Text = "";

            con.Close();

            //}
            //  catch (Exception ee)
            //{
            //   MessageBox.Show("invalid");
            //}


        }



        private void send_notification(int id, string msg)
        {
            //try
            //{
                SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=milestone_project;Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand("notification", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@s_id",SqlDbType.Int);
                cmd.Parameters.Add("@@msg", SqlDbType.NChar, 100).Direction = ParameterDirection.Output;


                cmd.Parameters["@s_id"].Value = id;
                msg = cmd.Parameters["@@msg"].Value.ToString();

                MessageBox.Show("notification sent successfully" + msg);

                cmd.ExecuteNonQuery();
                con.Close();

            //}
          //  catch (Exception ee)
            //{
             //   MessageBox.Show("invalid");
            //}
        }


    }
}
