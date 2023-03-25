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

namespace japan_final
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("server=localhost;database=alnuur;integrated security=true;");

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select*from db_Login where Username=@username and Password=@password", cn);
                cn.Open();

                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                
                SqlDataReader dr = cmd.ExecuteReader();
               
                if (dr.HasRows == true)
                    
                {


                    {
                        Form8 fr8 = new Form8();
                        fr8.Show();
                        this.Hide();

                    }


                }
                else
                {
                    MessageBox.Show("check username or password");
                }
                cn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }          
            
            
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnshow_Click(object sender, EventArgs e)
        {

        }

        private void btnhide_Click(object sender, EventArgs e)
        {


        }

        private void btnhide_Click_1(object sender, EventArgs e)
        {

            if (txtpassword.PasswordChar == '*')
            {
                btnshow.BringToFront();
                txtpassword.PasswordChar = '\0';
            }
            
           
        }

        private void btnshow_Click_1(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '\0')
            {
                btnhide.BringToFront();
                txtpassword.PasswordChar = '*';
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form7 fr7 = new Form7();
            fr7.Show();
            this.Hide();
        }
    }
}
