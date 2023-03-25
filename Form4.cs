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
    public partial class Form4 : Form
    {
        public Form4()
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

        private void btnresetcar_Click(object sender, EventArgs e)
        {
            
            txtcarno.Text = "";
            txtcardBrand.Text = "";
            txtcarmodel.Text = "";
            txtcarcolor.Text = "";
            txtownername.Text = "";
            txtID.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Show();
            this.Hide();
        }

        private void btnsavecar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtcarno.Text != "" && txtcardBrand.Text != "" && txtcarmodel.Text != "" && txtcarcolor.Text != ""
                && txtownername.Text != "" && dtpcar.Text != "")
            {

                cmd = new SqlCommand("insert into db_cars values(@S_ID, @CarNo, @CarBrand, @CarModel, @CarColor, @OwnerName, @Date)", cn);

                cn.Open();
                cmd.Parameters.AddWithValue("@S_ID", txtID.Text);
                cmd.Parameters.AddWithValue("@CarNo", txtcarno.Text);
                cmd.Parameters.AddWithValue("@CarBrand", txtcardBrand.Text);
                cmd.Parameters.AddWithValue("@CarModel", txtcarmodel.Text);
                cmd.Parameters.AddWithValue("@CarColor", txtcarcolor.Text);
                cmd.Parameters.AddWithValue("@OwnerName", txtownername.Text);
                cmd.Parameters.AddWithValue("@Date", dtpcar.Value);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("saved successefull");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Select Record to Save!");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            cn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from db_cars", cn);
            da.Fill(dt);
            txtID.Text = dt.Rows[0][0].ToString();
            txtcarno.Text = dt.Rows[0][1].ToString();
            txtcardBrand.Text = dt.Rows[0][2].ToString();
            txtcarmodel.Text = dt.Rows[0][3].ToString();
            txtcarcolor.Text = dt.Rows[0][4].ToString();
            txtownername.Text = dt.Rows[0][5].ToString();
            dtpcar.Value = Convert.ToDateTime(dt.Rows[0][6]);

           

            dgvcar.DataSource = dt;
            cn.Close();


            


        }
        private void DisplayData()
        {
            cn.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from db_cars", cn);
            da.Fill(dt);
            dgvcar.DataSource = dt;
            cn.Close();
        }
        private void ClearData()
        {
            txtcarcolor.Clear();
            txtcardBrand.Clear();
            txtcarmodel.Clear();
            txtcarno.Clear();
            txtownername.Clear();
            txtID.Clear();
        }

        private void btnEditcar_Click(object sender, EventArgs e)
        {
             if (txtID.Text != "" && txtcarno.Text != "" && txtcardBrand.Text != "" && txtcarmodel.Text != "" && txtcarcolor.Text != ""
                && txtownername.Text != "" && dtpcar.Text != "")
             {
                 cn.Open();
                 SqlCommand cmd = new SqlCommand("Update db_cars set Car_No=@Car_No,Car_brand=@Car_brand,Car_model=@Car_model,Car_color=@Car_color,Ownername=@Ownername,Date=@Date where C_ID=@C_ID", cn);

               cmd.CommandType = CommandType.Text;
                 ID = Convert.ToInt32(txtID.Text);
                 cmd.Parameters.AddWithValue("@C_ID", txtID.Text);
                 cmd.Parameters.AddWithValue("@Car_No", txtcarno.Text);
                 cmd.Parameters.AddWithValue("@Car_brand", txtcardBrand.Text);
                 cmd.Parameters.AddWithValue("@Car_model", txtcarmodel.Text);
                 cmd.Parameters.AddWithValue("@Car_color", txtcarcolor.Text);
                 cmd.Parameters.AddWithValue("@Ownername", txtownername.Text);
                 cmd.Parameters.AddWithValue("@Date", dtpcar.Value);
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

        private void btndeletecar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                cmd = new SqlCommand("Delete db_cars where C_ID=@C_ID", cn);
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

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
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
