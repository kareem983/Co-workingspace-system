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
    public partial class add_staff : Form
    {
        public add_staff()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data source=localhost; Initial Catalog=milestone_project; Integrated Security=true");
            con.Open();


            SqlCommand cmd = new SqlCommand("add_staff", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@email", SqlDbType.NChar, 100);
            cmd.Parameters["@email"].Value = this.txt_mail.Text;

            cmd.Parameters.Add("@pass", SqlDbType.NChar, 50);
            cmd.Parameters["@pass"].Value = this.txt_pass.Text;

            cmd.Parameters.Add("@role", SqlDbType.NChar, 20);
            cmd.Parameters["@role"].Value = "staff";

            cmd.Parameters.Add("@name", SqlDbType.NChar, 100);
            cmd.Parameters["@name"].Value = this.txt_name.Text;

            cmd.Parameters.Add("@num", SqlDbType.NChar, 20);
            cmd.Parameters["@num"].Value = this.txt_num.Text;

            cmd.Parameters.Add("@room_id", SqlDbType.Int);
            cmd.Parameters["@room_id"].Value = Convert.ToInt32(this.txt_roomid.Text);

            cmd.Parameters.Add("@@id", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();


            int person_id = Convert.ToInt32(cmd.Parameters["@@id"].Value);

            MessageBox.Show("The staff Added successfully with id: "+person_id.ToString());

            this.txt_mail.Text = "";
            this.txt_pass.Text = "";
            this.txt_name.Text = "";
            this.txt_num.Text  = "";
            this.txt_roomid.Text = "";
            
            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_staff_Load(object sender, EventArgs e)
        {

        }
    }
}
