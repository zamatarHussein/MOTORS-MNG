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
    public partial class Form3 : Form
    {
        public Form3()
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
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select *from db_salary", cn);
            da.Fill(dt);

            txtID.Text = dt.Rows[0][0].ToString();
            txtname.Text = dt.Rows[0][1].ToString();
            txtsalary.Text = dt.Rows[0][2].ToString();  
            txtadvance.Text = dt.Rows[0][3].ToString();
            txtamount.Text = dt.Rows[0][4].ToString();
            dtpsalry.Text = dt.Rows[0][5].ToString();
            


            dgvsalry.DataSource = dt;
            cn.Close();
            
            

            

            
        }
        private void DisplayData()
        {
            cn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select *from db_salary;", cn);
            da.Fill(dt);
            dgvsalry.DataSource = dt;
            cn.Close();
        }
        private void ClearData()
        {
            txtID.Clear();
            txtname.Clear();
            txtsalary.Clear();
            txtamount.Clear();
            txtadvance.Clear();
            

            ID = 0;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtname.Text != "" && txtsalary.Text != "" &&
                txtadvance.Text != "" && txtamount.Text != "" && dtpsalry.Text != "")
            {
                cmd = new SqlCommand("insert into db_salary values(@E_ID, @Name, @Salary, @Advance, @Net_amount, @date)", cn);

                cn.Open();
               cmd.Parameters.AddWithValue("@E_ID", txtID.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Salary", txtsalary.Text);
                cmd.Parameters.AddWithValue("@Advance", txtadvance.Text);
                cmd.Parameters.AddWithValue("@Net_amount", txtamount.Text);
                cmd.Parameters.AddWithValue("@date", dtpsalry.Value);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("saved successefully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Select Record to Save!");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtname.Text != "" && txtsalary.Text != "" &&
                dtpsalry.Text != "" && txtadvance.Text != "" && txtamount.Text != "")
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Update db_salary set Name=@Name,Salary=@Salary,date=@date,Advance=@Advance,Net_amount=@Net_amount where E_ID=@E_ID", cn);

                cmd.CommandType = CommandType.Text;
                ID = Convert.ToInt32(txtID.Text);
                cmd.Parameters.AddWithValue("@E_ID", txtID.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Salary", txtsalary.Text);
                cmd.Parameters.AddWithValue("@date", dtpsalry.Value);
                cmd.Parameters.AddWithValue("@Advance", txtadvance.Text);
                cmd.Parameters.AddWithValue("@Net_amount", txtamount.Text);
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
                cmd = new SqlCommand("Delete db_salary where E_ID=@E_ID", cn);
                cn.Open();
                ID = Convert.ToInt32(txtID.Text);
                cmd.Parameters.AddWithValue("@E_ID", ID);
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

        private void btnreset_Click(object sender, EventArgs e)
        {
            string name;
            double salary;
            double advance;
            double net_amount;

            name = txtname.Text;
            salary = double.Parse(txtsalary.Text);
            advance = double.Parse(txtadvance.Text);
            

            net_amount = salary - advance;
            txtamount.Text = net_amount.ToString();

            
            
        }


        private void txtaddres_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string sqlquery = "select *from db_salary where E_ID like '" + txtsearch.Text + "%'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvsalry.DataSource = dt;
            cn.Close();
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

                string str = "Select E_ID,Name from db_employee where E_ID = '" + txtID.Text + "'";

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form10 fr10 = new Form10();
            fr10.Show();
            this.Hide();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }
    }
}
