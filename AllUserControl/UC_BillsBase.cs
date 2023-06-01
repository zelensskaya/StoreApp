using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApp.AllUserControl
{
    public partial class UC_BillsBase : UserControl
    {
        function fn = new function();
        String query;

        public UC_BillsBase()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            query = "SELECT * FROM bills";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM bills WHERE oid LIKE '" + txtSearchID.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_BillsBase_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void UC_BillsBase_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete bill?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                query = "DELETE FROM bills WHERE bid = " + id + "";
                fn.setData(query);
                loadData();
            }
        }

        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM bills WHERE name LIKE '" + txtSearchItem.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
