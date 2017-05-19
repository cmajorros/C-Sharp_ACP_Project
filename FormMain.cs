using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccessoryPower_Final
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPMT fmPro = new frmPMT();

            fmPro.MdiParent = this;
            fmPro.WindowState = FormWindowState.Maximized;
       
            fmPro.Show();
           
            fmPro.Focus();
           

        }

        private void partToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPart fmPart = new frmPart();
            fmPart.MdiParent = this;
            fmPart.Show();
            fmPart.WindowState = FormWindowState.Maximized;
            fmPart.Focus();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmPMT fmPro = new frmPMT();

            fmPro.MdiParent = this;
            fmPro.WindowState = FormWindowState.Maximized;
            fmPro.Show();

            fmPro.Focus();
        }

        private void kitRelationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKit fmKit = new frmKit();
            fmKit.MdiParent = this;
            fmKit.WindowState = FormWindowState.Maximized;
            fmKit.Show();
            fmKit.Focus();
        }
    }
}
