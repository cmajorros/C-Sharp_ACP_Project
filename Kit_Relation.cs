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
    public partial class frmKit : Form
    {
        public frmKit()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKit_Load(object sender, EventArgs e)
        {

            CboPart.DataSource = null;
            string selectPro = "select id, title from products;";
           

            DBConnect ConnPro = new DBConnect();
            

            DataSet dsPro = new DataSet();
            dsPro = ConnPro.SelectAllPart(selectPro);
            int TotalPro = dsPro.Tables["AllPart"].Rows.Count;
            DataTable dtPro = dsPro.Tables["AllPart"];

            
            //int totalPro = dtPro.Rows.Count;
            for (int P = 0; P < TotalPro; )
            { 

                string prodId = dtPro.Rows[P][0].ToString();
                string prodName = dtPro.Rows[P][1].ToString();
                cboProduct.Items.Add(prodId + " : " + prodName);
                P++;
            }

            string prodID = dtPro.Rows[0][0].ToString();
            
             int proNum = Convert.ToInt32(prodID);

            string selectPart = "select k.part_id, pr.part_name from kit_relations k LEFT JOIN parts pr on k.part_id=pr.id WHERE k.product_id = "+proNum+";";

             //add Part

            DBConnect connPart = new DBConnect();
            
            DataSet dsPart = new DataSet();
            dsPart = connPart.SelectAllPart(selectPart);
            DataTable dtPart = new DataTable(); 
            dtPart = dsPart.Tables["AllPart"];
            int totalPart;
            totalPart = dsPart.Tables["AllPart"].Rows.Count;
            for (int i = 0; i < totalPart; )
            {
                string PartVal = dtPart.Rows[i][0].ToString() + "  : " + dtPart.Rows[i][1].ToString();
                CboPart.Items.Add(PartVal);
                i++;
            }


            

             

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string Part;
            string Pro;
            int Qty = Convert.ToInt32(textBox1.Text);

            Part = CboPart.SelectedItem.ToString();

            int PartID = Convert.ToInt32((Part.Substring(0, 2)).Trim());

            Pro = cboProduct.SelectedItem.ToString();
            int ProID = Convert.ToInt32((Pro.Substring(0, 2)).Trim());

            string findKR = "select max(id) as MAXID from kit_relations;";
            DBConnect findID = new DBConnect();
            string maxID = findID.FindMaxID(findKR);
            int newMaxID = Convert.ToInt32(maxID) + 1;


            string Updatekit = "Update kit_relations SET part_qty = " + Qty + " WHERE part_id = " + PartID + " and product_id = " + ProID + ";"; 
            DBConnect insertkitqry = new DBConnect();
            insertkitqry.Updatedata(Updatekit);
            MessageBox.Show("Quantity of Part has been added.");

        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

            CboPart.DataSource = null;
            string proID = cboProduct.SelectedItem.ToString();
            int proNum = Convert.ToInt32(proID.Substring(0, 2).Trim());

            



            string selectPart = "select k.part_id, pr.part_name from kit_relations k LEFT JOIN parts pr on k.part_id=pr.id WHERE k.product_id = " + proNum + ";";

            //add Part

            DBConnect connPart = new DBConnect();

            DataSet dsPart = new DataSet();
            dsPart = connPart.SelectAllPart(selectPart);
            DataTable dtPart = new DataTable();
            dtPart = dsPart.Tables["AllPart"];
            int totalPart;
            totalPart = dsPart.Tables["AllPart"].Rows.Count;
            for (int i = 0; i < totalPart; )
            {
                string PartVal = dtPart.Rows[i][0].ToString() + "  : " + dtPart.Rows[i][1].ToString();
                CboPart.Items.Add(PartVal);
                i++;
            }
        }
    }
}
