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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            CountEmployee();
            CountSalary();
            CountCars();



        }
        SqlConnection cn = new SqlConnection("server=localhost;database=alnuur;integrated security=true;");
        private void CountEmployee()
        {
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*)from db_employee", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblemployee.Text = dt.Rows[0][0].ToString() + "";
            cn.Close();
            
        }
        private void CountSalary()
        {
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*)from db_salary", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblSalary0.Text = dt.Rows[0][0].ToString() + "";
            cn.Close();

        }
        private void CountCars()
        {
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*)from db_cars", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblcar.Text = dt.Rows[0][0].ToString() + "";
            cn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            fr4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            fr5.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            fr6.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 fr7 = new Form7();
            fr7.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 fr8 = new Form8();
            fr8.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Show();
            this.Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CountCars();
            CountEmployee();
            CountSalary();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form10 fr10 = new Form10();
            fr10.Show();
            this.Hide();
        }
    }
}
