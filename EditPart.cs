using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccessoryPower_Final
{
    public partial class frmEditPart : Form
    {
        public frmEditPart()
        {
            InitializeComponent();
            
        }


        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            txtPartID.Text = frmPart.editpart;
            int partid = Convert.ToInt32(txtPartID.Text);
            string partname = txtname.Text;
            string number = txtnumber.Text;
            string desc = txtdesc.Text;
            int quantity = Convert.ToInt32(txtquantity.Text);

           string updatepart ="update parts p INNER JOIN inventory i ON p.id = i.part_id SET p.part_name = '"+partname+"' , p.number ='"+ number+ "', p.description = '"+desc+"',i.quantity = "+quantity+" WHERE p.id = "+partid+" ;";

           try
           {
               DBConnect conn = new DBConnect();
               conn.Updatedata(updatepart);
               MessageBox.Show("Part has been updated successfully");

           }
           catch {
               MessageBox.Show("Cannot update . Please check the data");
           }
           this.Close();

        }

        private void frmEditPart_Load(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(txtPartID.Text);
            string findupdate = "select p.part_name , p.number, p.description, i.quantity  from parts p left join inventory i on p.id = i.part_id where p.id = " + ID + ";";
            DBConnect conn = new DBConnect();
            DataSet UPds = new DataSet();
            UPds =    conn.SelectData(findupdate);
            DataTable dt = new DataTable();
            dt = UPds.Tables["Details"];
             
            txtname.Text = dt.Rows[0][0].ToString();
            txtnumber.Text =  dt.Rows[0][1].ToString();
            txtdesc.Text = dt.Rows[0][2].ToString();
            txtquantity.Text =  dt.Rows[0][3].ToString();


            
        }
    }
}
