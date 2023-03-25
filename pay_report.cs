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
    public partial class pay_report : Form
    {
        public pay_report()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=Final_Japan;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string SELECT ="SELECT * FROM db_Payment where C_ID = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(SELECT, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();


                PAY_REP PR = new PAY_REP();
                PR.Database.Tables["db_Payment"].SetDataSource(dt);
                this.crystalReportViewer1.ReportSource = PR;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "mesege", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string SELECT = "SELECT * FROM db_Payment where Name='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(SELECT, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();


                PAY_REP RP = new PAY_REP();
                RP.Database.Tables["db_Payment"].SetDataSource(dt);
                this.crystalReportViewer1.ReportSource = RP;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "mesege", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
