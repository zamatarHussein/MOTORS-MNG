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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=Final_Japan;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        int ID = 0;
        


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

        private void btnresetstock_Click(object sender, EventArgs e)
        {
            TxtID.Clear();
            txtpartnamestock.Text = "";
            txtpartpricestock.Text = "";
            txtquantitystock.Text = "";
            txtTotal.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            cn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select *from db_stock;", cn);
            da.Fill(dt);

            TxtID.Text = dt.Rows[0][0].ToString();
            txtpartnamestock.Text = dt.Rows[0][1].ToString();
            txtquantitystock.Text = dt.Rows[0][2].ToString();
            txtpartpricestock.Text = dt.Rows[0][3].ToString();
            txtTotal.Text = dt.Rows[0][4].ToString();

            dgvstock.DataSource = dt;
            cn.Close();
            
        }
        private void DisplayData()
        {
            cn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select *from db_stock;", cn);
            da.Fill(dt);
            dgvstock.DataSource = dt;
            cn.Close();
        }
        private void ClearData()
        {
            TxtID.Clear();
            txtpartnamestock.Clear();
            txtpartpricestock.Clear();
            txtquantitystock.Clear();
            txtTotal.Clear();

            ID = 0;
        }

        private void btnsavestock_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "" && txtpartnamestock.Text != "" && txtquantitystock.Text != "" && txtpartpricestock.Text != "" && txtTotal.Text != "")
            {
                cmd = new SqlCommand("insert into db_stock values(@S_ID, @Part_name, @Part_Quantity, @Part_Price, @TOTALS)", cn);
                cn.Open();
                cmd.Parameters.AddWithValue("@S_ID", TxtID.Text);
                cmd.Parameters.AddWithValue("@Part_name", txtpartnamestock.Text);
                cmd.Parameters.AddWithValue("@Part_Quantity", txtquantitystock.Text);
                cmd.Parameters.AddWithValue("@Part_Price", txtpartpricestock.Text);
                cmd.Parameters.AddWithValue("@TOTALS", txtTotal.Text); 
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Saved Successfully");
                DisplayData();
                
                
               
            }
            else
            {
                MessageBox.Show("Select Record to Save!");
            }
            
        }

        private void btneditstock_Click(object sender, EventArgs e)
        {
            if (txtpartnamestock.Text != "" && txtquantitystock.Text != "" && txtpartpricestock.Text != "")
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Update db_stock set part_name=@part_name,part_quantity=@part_quantity,part_price=@part_price,TOTALS=@TOTALS where S_ID=@S_ID", cn);

              cmd.CommandType = CommandType.Text;
              ID = Convert.ToInt32(TxtID.Text);
              cmd.Parameters.AddWithValue("S_ID", TxtID.Text);
                cmd.Parameters.AddWithValue("@part_name", txtpartnamestock.Text);
                cmd.Parameters.AddWithValue("@part_quantity", txtquantitystock.Text);
                cmd.Parameters.AddWithValue("@part_price", txtpartpricestock.Text);
                cmd.Parameters.AddWithValue("@TOTALS", txtTotal.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Update successfully");
                cn.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Select Record to Update");
            }
        }

        private void btndeletestock_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "")
            {
                cmd = new SqlCommand("Delete db_stock where S_ID=@S_ID", cn);
                cn.Open();
                ID = Convert.ToInt32(TxtID.Text);
                cmd.Parameters.AddWithValue("@S_ID", ID);
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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            
            string name;
            double quentity;
            double price;
            double total;

            name = txtpartnamestock.Text;
            quentity = Convert.ToDouble(txtquantitystock.Text);
            price = Convert.ToDouble(txtpartpricestock.Text);

            total = quentity * price;
            txtTotal.Text = Convert.ToString(total);

            MessageBox.Show("Thanks");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form10 fr10 = new Form10();
            fr10.Show();
            this.Hide();
        }
    }
}
