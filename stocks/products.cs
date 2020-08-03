using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stocks
{
    public partial class products : Form
    {
        public products()
        {
            InitializeComponent();
        }

        private void products_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3DNVLJ2\SQLEXPRESS;Initial Catalog=storsj;Integrated Security=True");
            con.Open();
            bool status = false;
            if(comboBox1.SelectedIndex==0)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            var sqlquery = "";
            if(IfproductExist(con,textBox1.Text))
            {
                sqlquery=@"update product set product_name='"+textBox3.Text+"',product_status='"+status+"' where product_code="+textBox1.Text+"" ;
            }
            else
            {
                sqlquery = @"insert into product (product_code,product_name,product_status) values (" + textBox1.Text + ",'" + textBox3.Text + "','" + status + "'";
            }
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.ExecuteNonQuery();
            con.Close();
            LoadData();
            }

        private bool IfproductExist(SqlConnection con, string productcode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select 1 from product where product_code='" + productcode + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public void LoadData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3DNVLJ2\SQLEXPRESS;Initial Catalog=storsj;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select * from product", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();

            foreach (DataRow item in dt.Rows)
            {

                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["product_code"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["product_name"].ToString();
                if ((bool)(item)["product_status"])
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }

            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString()=="Active")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3DNVLJ2\SQLEXPRESS;Initial Catalog=storsj;Integrated Security=True");
            var sqlquery = "";
            if (IfproductExist(con, textBox1.Text))
            {
                con.Open();
                sqlquery = @"delete from product  where product_code=" + textBox1.Text + "";
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Record not Exist..!");
            }
            
            LoadData();
        }


    }
}

