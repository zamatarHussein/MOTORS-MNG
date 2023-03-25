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
    public partial class Form6 : Form
    {
        public Form6()
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

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Show();
            this.Hide();
        }

        private void btnsaveemply_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtName.Text != "" && txtAddress.Text != "" && comboBox1Gender.Text != "" && txtPhone.Text != "")
            {
                cmd = new SqlCommand("insert into db_employee values(@E_ID, @Name, @Address, @Gender, @Phone)", cn);

                cn.Open();
                cmd.Parameters.AddWithValue("@E_ID", txtID.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1Gender.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Saved Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Select Record to Save!");
            }
             }



        private void Form6_Load(object sender, EventArgs e)
        {
            cn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select *from db_employee;", cn);
            da.Fill(dt);

            txtID.Text = dt.Rows[0][0].ToString();
            txtName.Text = dt.Rows[0][1].ToString();
            txtAddress.Text = dt.Rows[0][2].ToString();
            comboBox1Gender.Text = dt.Rows[0][3].ToString();
            txtPhone.Text = dt.Rows[0][4].ToString();
            

            dgvemploye.DataSource = dt;
            cn.Close();
        }
        private void DisplayData()
        {
            cn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select *from db_employee;", cn);
            da.Fill(dt);
            dgvemploye.DataSource = dt;
            cn.Close();
        }
        private void ClearData()
        {
            txtID.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtsearch.Clear();
            
            

            ID = 0;
        }

        private void btneditemply_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtName.Text != "" && txtAddress.Text != "" && comboBox1Gender.Text != "" && txtPhone.Text != "")
            {
                cn.Open();
              SqlCommand cmd = new SqlCommand("Update db_employee set Name=@Name,Address=@Address,Gender=@Gender,Phone=@Phone where E_ID=@E_ID", cn);

              cmd.CommandType = CommandType.Text;
                ID = Convert.ToInt32(txtID.Text);
                cmd.Parameters.AddWithValue("@E_ID", txtID.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1Gender.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.ExecuteNonQuery();
               
                cn.Close();
                DisplayData();
                ClearData();
                MessageBox.Show("Update Seccesfully");

            }
            else
            {
                MessageBox.Show("Select Record To Update");
            }
        }

        private void btndeleteemply_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                cmd = new SqlCommand("Delete db_employee where E_ID=@E_ID", cn);
                cn.Open();
                ID = Convert.ToInt32(txtID.Text);
                cmd.Parameters.AddWithValue("@E_ID", txtID.Text);
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtsearch.Clear();
            txtAddress.Clear();
            
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string sqlquery = "select *from db_employee where Name like '" + txtsearch.Text + "%'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvemploye.DataSource = dt;
            cn.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form10 fr10 = new Form10();
            fr10.Show();
            this.Hide();
        }

    }
}
