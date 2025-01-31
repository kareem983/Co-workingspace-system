﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace workspace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.icons8_user_40;

            textBox1.ForeColor = Color.MediumAquamarine;

            pictureBox3.BackgroundImage = Properties.Resources.icons8_password_40;

            textBox2.ForeColor = Color.Azure;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.icons8_password_40;

            textBox2.ForeColor = Color.MediumAquamarine;
            //pictureBox2.BackgroundImage = Properties.Resources.icons8_user_40;

            textBox1.ForeColor = Color.Azure;

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            Form2 f1 = new Form2();
            f1.Show();
            //this.Close(); 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
                if (textBox1.Text == "" || textBox2.Text == "" )
                {
                    MessageBox.Show("you should fill all data,please!");

                }
                else
                {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(textBox1.Text);
                    if (addr.Address == textBox1.Text)
                    {
                        
                        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=milestone_project;Integrated Security=True");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("login", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@email", SqlDbType.NChar, 100);
                        cmd.Parameters.Add("@password", SqlDbType.NChar, 100);
                        cmd.Parameters.Add("@type", SqlDbType.NChar, 100);
                        cmd.Parameters.Add("@id", SqlDbType.Int, 100);
                        cmd.Parameters.Add("@@name", SqlDbType.NChar, 100).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("@@id_num", SqlDbType.NChar, 100).Direction = ParameterDirection.Output;
                       
                        cmd.Parameters["@email"].Value = textBox1.Text;
                        cmd.Parameters["@password"].Value = textBox2.Text;
                        cmd.Parameters["@type"].Value = "visitor";
                        cmd.Parameters["@id"].Value = "1";

                        cmd.ExecuteReader();
                        string n = cmd.Parameters["@@name"].Value.ToString();
                        string id_num = cmd.Parameters["@@id_num"].Value.ToString();

                        if (n == "")
                        {
                            MessageBox.Show("incorrect username or password");
                        }
                        else
                        {
                            MessageBox.Show("Signed in successfully");
                            con.Close();

                            Program.user.name = n;
                            Program.user.email = textBox1.Text;
                            Program.user.id = int.Parse(id_num);
                            Program.user.phone = "";
                            Program.user.role = "visitor";

                            textBox1.Text = "";
                            textBox2.Text = "";

                        }
                        con.Close();
                        
                        this.Close();
                      
                    }
                }
                catch(Exception ee)
                {
                  //  MessageBox.Show(ee.Message);
                    MessageBox.Show("invalid data");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.twitter.com");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

  

