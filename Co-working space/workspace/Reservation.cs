using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace workspace
{
    public partial class Reservation : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-B3KM1PT;Initial Catalog=milestone_project;Integrated Security=True");
        public Reservation()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
        int i=0;
        private void button2_Click(object sender, EventArgs e)
        {
            int sy = dateTimePicker1.Value.Year;
            int ey = dateTimePicker2.Value.Year;
            int sd = dateTimePicker1.Value.Day;
            int ed = dateTimePicker2.Value.Day;
            int sm = dateTimePicker1.Value.Month;
            int em = dateTimePicker2.Value.Month;

            int TotalDays = ((ey - sy) * 365) + ((em - sm) * 30) + (ed - sd);
            string t = (TotalDays * 50).ToString();


            i++;
            if (i == 1)
            {
                MessageBox.Show("please choose your room from rows .. ", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if (i == 2)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("reserve", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@st_date", SqlDbType.Date);
                cmd.Parameters.Add("@en_date", SqlDbType.Date);
                //cmd.Parameters.Add("@st_time", SqlDbType.Time);
                //cmd.Parameters.Add("@en_time", SqlDbType.Time);
                cmd.Parameters.Add("@roomid", SqlDbType.Int);
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@fee", SqlDbType.Int);


                cmd.Parameters.Add("@@res_id", SqlDbType.Int).Direction = ParameterDirection.Output;
               // cmd.Parameters.Add("@@fee", SqlDbType.Money).Direction = ParameterDirection.Output;
                cmd.Parameters["@st_date"].Value = dateTimePicker1.Value.Date;
                cmd.Parameters["@en_date"].Value = dateTimePicker2.Value.Date;
                //cmd.Parameters["@st_time"].Value = dateTimePicker3.Value.TimeOfDay;
                //cmd.Parameters["@en_time"].Value = dateTimePicker4.Value.TimeOfDay;
                cmd.Parameters["@id"].Value = Program.user.id;
                cmd.Parameters["@roomid"].Value = Convert.ToInt32(textBox1.Text);
                cmd.Parameters["@fee"].Value = t;

               
                cmd.ExecuteNonQuery();
                string n = cmd.Parameters["@@res_id"].Value.ToString();
                


                MessageBox.Show("Your Reservation ID is " + n + "\nYour Fees is " + t);
                con.Close();
            }
        }

        private void Reservation_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("res_time", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@st_date", SqlDbType.Date);
            cmd.Parameters.Add("@en_date", SqlDbType.Date);
            cmd.Parameters.Add("@st_time", SqlDbType.Time);
            cmd.Parameters.Add("@en_time", SqlDbType.Time);
            cmd.Parameters["@st_date"].Value = dateTimePicker1.Value.Date;
            cmd.Parameters["@en_date"].Value = dateTimePicker2.Value.Date;
            cmd.Parameters["@st_time"].Value = dateTimePicker3.Value.TimeOfDay;
            cmd.Parameters["@en_time"].Value = dateTimePicker4.Value.TimeOfDay;

            //cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void dataGridView1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
