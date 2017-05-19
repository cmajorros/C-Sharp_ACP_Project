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
    public partial class frmPart : Form
    {
        int idIndex = -1;
        public static string editpart;

        public frmPart()
        {
            
            InitializeComponent();
        }

       

        private void btnAddPart_Click(object sender, EventArgs e)
        {

            Form Frm = new frmAddPart();
            Frm.Show();
            
            
        }

        private void btnEditPart_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count != 0)
            {
               
                
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];

                editpart = row.Cells["ID"].Value.ToString();
                frmEditPart fmEdit = new frmEditPart();
                fmEdit.txtPartID.Text = editpart;
                fmEdit.Show();
            }
            else {
                MessageBox.Show("Please select Part ID before editing  ");
            }


        }

   
        private void frmPart_Load(object sender, EventArgs e)
        {

            frmPart fp = new frmPart();
            fp.WindowState = FormWindowState.Maximized;
            DBConnect dbconnect = new DBConnect();
            dbconnect.connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = dbconnect.connection;
            string qry;
            qry = "select parts.id, parts.part_name,parts.number, inventory.quantity from parts LEFT JOIN inventory  ON parts.ID =inventory.part_id order by parts.id asc;";

            command.CommandText = qry;

            DataTable data = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(data);

            dataGridView1.DataSource = data;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idIndex = e.RowIndex;
        }

        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count != 0)
            {


                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                string delpart = row.Cells["ID"].Value.ToString();
                int id = Convert.ToInt32(delpart);

                string deletecmd;
                deletecmd = "";

                if (idIndex > -1 && idIndex < dataGridView1.Rows.Count - 1)
                {
                    id = Convert.ToInt32(dataGridView1.Rows[idIndex].Cells[0].Value);
                    if (MessageBox.Show("Are you sure you want to delete part " + id + " ? Deleting part will result in losing product information", "Click <Yes> to delete part and related product.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // delete
                        deletecmd =
   "BEGIN; " + "delete from kit_relations k where k.part_id =" + id + "; " + "delete from parts where id =" + id + "; " + "delete from products p left join CountPartbyProduct cp on p.id = cp.product_id where cp.product_id IS NULL; delete from inventory where part_id = " + id + " ; COMMIT; ";

                        DBConnect dbconnect = new DBConnect();
                        dbconnect.Deletedata(deletecmd);
                        MessageBox.Show("Part and its products have been removed successfully");
                    }
                }


                
            }
            else
            {
                MessageBox.Show("Please select Part ID before editing  ");
            }

 

        }
    }
}
