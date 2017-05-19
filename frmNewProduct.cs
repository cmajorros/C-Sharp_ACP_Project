using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace AccessoryPower_Final
{
    public partial class frmNewProduct : Form
    {
        public frmNewProduct()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)


        {
            
            string title = txtTitle.Text; 
            string number = txtNumber.Text;
            int kit_flag = 0;
            double price = Convert.ToDouble(txtPrice.Text);

            if (rbdYes.Checked == true)
            {
                kit_flag = 1;

            }
            else 
            {
                kit_flag = 0; 
            }

            try {
                string searchmax = "Select MAX(ID) as MAXID from products;";
                    DBConnect conmax = new DBConnect();
                
                int IDNEW = Convert.ToInt32(conmax.FindMaxID(searchmax)) + 1;

            string InsertProduct = "";
            InsertProduct = "Insert into  products  (id,title,kit_flag,price,number) values ("+IDNEW+", '"+title+"' ,"+kit_flag+","+price+", '"+number+"') ;";

            DBConnect dbconn = new DBConnect();
            dbconn.Insertdata(InsertProduct);
               
            // insert kit relations

                int totalitem = checkedListBox1.Items.Count;
                for (int b = 0; b < totalitem; ) 
                {
                    if (checkedListBox1.GetSelected(b) == true)
                    {
                        string partselectname =   checkedListBox1.Items[b].ToString();
                        string partId1 = partselectname.Substring(0,2).Trim();
                        int partId = Convert.ToInt32(partId1);
                        
                        string findmaxkr = "Select max(id)as MAXID from kit_relations;";
                        DBConnect confindmaxrkr = new DBConnect();
                       

                        int newKRID = Convert.ToInt32(confindmaxrkr.FindMaxID(findmaxkr)) + 1;
                        string insertKitRelation = "insert into kit_relations (id, product_id,part_id) values (" + newKRID + "," + IDNEW + "," + partId + ");";
                        DBConnect coninsertKr = new DBConnect();
                        coninsertKr.Insertdata(insertKitRelation);

                    }

                     b++ ;

                }

                MessageBox.Show("Product has been created completely");
                }

            
            catch {
            MessageBox.Show("Cannot Add product !! Please check your value");
            }

            
        }

        private void frmNewProduct_Load(object sender, EventArgs e)
        {
            string selectpart = "select id, part_name from parts;";
            DBConnect dbcon = new DBConnect();
            
            DataSet Partds = new DataSet();
            Partds = dbcon.SelectAllPart(selectpart);
            
            DataTable dt = new DataTable();
            dt = Partds.Tables["AllPart"];
            int TotalPart = dt.Rows.Count;

            for (int i = 0; i < TotalPart; ) {
 
                string idPart = dt.Rows[i][0].ToString();
            
                string PartName = dt.Rows[i][1].ToString();
                checkedListBox1.Items.Add(idPart + " : " + PartName);
                i++;
                          

            }
 


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
         
            this.Close();

        }

       

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void rbnNo_CheckedChanged(object sender, EventArgs e)
        {

        }

        

             

       
    }
}
