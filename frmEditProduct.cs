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
    public partial class frmEditProduct : Form
    {
        


        public frmEditProduct()
        {
            InitializeComponent();
            
        }
       


        private void btnClear_Click(object sender, EventArgs e)
        {
          txtPrice.Text = "";
          txtNumber.Text = "";
          txtTitle.Text = "";
          rbnYes.Checked = true;
           
        }

        private void frmEditProduct_Load(object sender, EventArgs e)
        {
           
            txtID.Text = frmPMT.ResultID;
            int ID;
            ID = Convert.ToInt32(txtID.Text);

            string LoadCheckbox = "";
            LoadCheckbox = "Select k.id, k.part_id, p.part_name ,k.product_id from kit_relations k left join  parts p on k.part_id  = p.id where k.product_id = " + ID + ";";

            string selectProduct = "";
            selectProduct = "Select * from products where id= "+ID+" ;";

            DBConnect connPro = new DBConnect();
            DataSet proDetail = new DataSet();
            proDetail = connPro.SelectData(selectProduct);
            DataTable dt = proDetail.Tables["details"];

            string title; 
            string numberpart;
            string price;
            string kit_staus;
            //string part;

         
            string idpro = dt.Rows[0][0].ToString();
            title = dt.Rows[0][1].ToString();
            
            numberpart = dt.Rows[0][2].ToString();
            price = dt.Rows[0][3].ToString();
            kit_staus = dt.Rows[0][4].ToString();


            txtPrice.Text = price;
            txtNumber.Text = numberpart;
            txtTitle.Text = title;
            if (kit_staus == "1")
            {
                rbnYes.Checked = true;
                rbnNo.Checked = false;
            }
            else
            {
                rbnNo.Checked = true;
                rbnYes.Checked = false;
            }

            





        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            int ID = Convert.ToInt32(txtID.Text);
            string title = txtTitle.Text;
            string number = txtNumber.Text;
            int kit_flag = 0;
            double price = Convert.ToDouble(txtPrice.Text);

            if (rbnYes.Checked == true)
            {
                kit_flag = 1;

            }
            else 
            {
                kit_flag = 0; 
            }

            try {
            string updateProduct = "";
            updateProduct = "update products set title = '"+title+"' , kit_flag = "+kit_flag+", price = "+price+", number = '"+number+"' where id = "+ID+";";

            DBConnect dbconn = new DBConnect();
            dbconn.Updatedata(updateProduct);
                MessageBox.Show("Product has been updated completely");
                
            }
            catch {
            MessageBox.Show("Cannot update !! Please check your insert value");
            }

            this.Close();
        }

        private void frmEditProduct_Load_1(object sender, EventArgs e)
        {

        }

       
    }
}
