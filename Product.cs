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
    public partial class frmPMT : Form
    {

        public static string ResultID;

        int editpro = -1;

        //public static string ResultID = "";

        public frmPMT()
        {
            InitializeComponent();
             

        }

       

        public void frmPMT_Load(object sender, EventArgs e)
        {
            frmPMT fp = new frmPMT();
            fp.WindowState = FormWindowState.Maximized;
            DBConnect dbconnect = new DBConnect();
            dbconnect.connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = dbconnect.connection;
            string qry;
            qry = "Select P.id, P.title, P.number, P.price,flag, (CASE WHEN F.part_name is null then 'NO_ Part' ELSE F.part_name end)as Part_name, F.Quantity  from ProductView P LEFT JOIN  FinalPrByPro F ON P.id = F.Product_id;";
                //"select  PV.id, PV.title, PV.number, PV.price,PV.flag, (case when FSV.Product_ID is null then 'Multiple' else FSV.part_name end) as part_name, Quantity from ProductView PV LEFT JOIN FindSingleVal FSV ON PV.ID = FSV.Product_ID Left join QuantityByProduct QP on PV.ID = QP.Product_ID;";

            command.CommandText = qry;

            DataTable data = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(data);

            dataGridView1.DataSource = data;

        }

        private  void button3_Click(object sender, EventArgs e)
        {

            frmNewProduct fmProduct = new frmNewProduct();
            
            fmProduct.Show();
            this.Close();

          
           
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
             if (dataGridView1.SelectedRows.Count != 0)
            {

              
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];

                string delpro = row.Cells["ID"].Value.ToString();
                 int delID = Convert.ToInt32(delpro);

                 if (MessageBox.Show("Are you sure you want to delete part " + delpro + " ? ", "Click <Yes> if you want to delete part .",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                 {


                     string delQry = "BEGIN; delete from kit_relations where product_id = " + delID + "; delete from products where id = " + delID + ";  COMMIT;";
                     DBConnect conn = new DBConnect();
                     conn.Deletedata(delQry);
                     MessageBox.Show("Selected Part has been deleted successfuly");
                 }

                
            }
            else
            {
                MessageBox.Show("Please select Product ID before editing  ");
            }
             

        }

        public void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {


                DataGridViewRow row = this.dataGridView1.SelectedRows[0];

                ResultID = row.Cells["ID"].Value.ToString();
                frmEditProduct fmEditProduct = new frmEditProduct();
                fmEditProduct.txtID.Text = ResultID;
                fmEditProduct.Show();

            }
            else
            {
                MessageBox.Show("Please select Part ID before editing  ");
            }

            frmEditProduct fEditPro = new frmEditProduct();
            
            fEditPro.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editpro = e.RowIndex;
        }
        


    }
}
