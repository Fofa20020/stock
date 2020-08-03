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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //To-Do cheack login
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3DNVLJ2\SQLEXPRESS;Initial Catalog=storsj;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Login where username='"+textBox1.Text+"' and password='"+textBox2.Text+"' ",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count==1)
            {
                this.Hide();
                stockMain main = new stockMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid username & Password..!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }button1_Click(sender, e);
            
        }
    }
}
