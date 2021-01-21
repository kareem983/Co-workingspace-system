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
    public partial class del_room : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=milestone_project;Integrated Security=True");
        public del_room()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("del_reservation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@roomid", SqlDbType.Int);
            cmd.Parameters["@roomid"].Value = Convert.ToInt32(textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("you deleted room successfully");
            this.textBox1.Text = "";
        }

        private void del_room_Load(object sender, EventArgs e)
        {

        }
    }
}
