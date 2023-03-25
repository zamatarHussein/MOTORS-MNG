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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=Final_Japan;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        int ID = 0;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 fr8 = new Form8();
            fr8.Show();
            this.Hide();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            cn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from db_Payment;", cn);
            da.Fill(dt);

            txtID.Text = dt.Rows[0][0].ToString();
            txtname.Text = dt.Rows[0][1].ToString();
            txtamount.Text = dt.Rows[0][2].ToString();
            txtmethod.Text = dt.Rows[0][3].ToString();
            dtppayment.Value = Convert.ToDateTime(dt.Rows[0][4]);


            dgvpayment.DataSource = dt;
            cn.Close();



        }
        private void DisplayData()
        {
            cn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select*from db_Payment;", cn);
            da.Fill(dt);
            dgvpayment.DataSource = dt;
            cn.Close();
        }
        private void ClearData()
        {
            txtID.Clear();
            txtname.Clear();
            txtamount.Clear();
            txtmethod.Clear();

            ID = 0;
        }
    
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtname.Text != "" && txtamount.Text != "" && txtmethod.Text != "" && dtppayment.Text != "")
            {
                cmd = new SqlCommand("insert into db_Payment Values(@C_ID, @Name, @Amount, @Method, @Date)", cn);

                cn.Open();
                cmd.Parameters.AddWithValue("@C_ID", txtID.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Amount", txtamount.Text);
                cmd.Parameters.AddWithValue("@Method", txtmethod.Text);
                cmd.Parameters.AddWithValue("@Date", dtppayment.Value);
                cmd.ExecuteNonQuery();
                cn.Close();
                   MessageBox.Show("saved successefull");
                   DisplayData();
                   ClearData();
            }
            else
            {
                MessageBox.Show("Pro+vide Details!");
            
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
             if (txtID.Text != "" && txtname.Text != "" && txtamount.Text != "" && txtmethod.Text != "" && dtppayment.Text != "")
            {
                 cn.Open();
               SqlCommand cmd = new SqlCommand("Update db_Payment set Name=@Name,Amount=@Amount,Method=@Method,Date=@Date where C_ID=@C_ID", cn);

                  cmd.CommandType = CommandType.Text;
                 ID = Convert.ToInt32(txtID.Text);
                 cmd.Parameters.AddWithValue("@C_ID", txtID.Text);
                 cmd.Parameters.AddWithValue("@Name", txtname.Text);
                 cmd.Parameters.AddWithValue("@Amount", txtamount.Text);
                 cmd.Parameters.AddWithValue("@Method", txtmethod.Text);
                 cmd.Parameters.AddWithValue("@Date", dtppayment.Value);
                 cmd.ExecuteNonQuery();

                 cn.Close();
                 DisplayData();
                 ClearData();
                 MessageBox.Show("Update successefull");

            }
             else
             {
                 MessageBox.Show("Select Record to Update");
             }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                cmd = new SqlCommand("Delete db_Payment where C_ID=@C_ID", cn);
                cn.Open();
                ID = Convert.ToInt32(txtID.Text);
                cmd.Parameters.AddWithValue("@C_ID", ID);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Deleted Successfully!");
                DisplayData();
                ClearData();

            }
            else
            {
                MessageBox.Show("Select Record to Delete");
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                txtname.Clear();

            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Final_Japan;Integrated Security=True");

                con.Open();

                string str = "Select C_ID,Ownername from db_cars where C_ID = '" + txtID.Text + "'";

                SqlCommand cmd = new SqlCommand(str, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtID.Text = dr.GetValue(0).ToString();
                    txtname.Text = dr.GetValue(1).ToString();

                }

                con.Close();
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtname.Clear();
            txtamount.Clear();
            txtmethod.Clear();
            
            
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string sqlquery = "select *from db_Payment where Name like '" + txtsearch.Text + "%'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvpayment.DataSource = dt;
            cn.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            pay_report rp = new pay_report();
            rp.Show();
            
            

        }
    }
}
