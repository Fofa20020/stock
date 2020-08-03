using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stocks
{
    public partial class stockMain : Form
    {
        private int childFormNumber = 0;

        public stockMain()
        {
            InitializeComponent();
        }

        private void stockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            products pro = new products();
            pro.MdiParent = this;
            pro.Show();
        }
    }
}
