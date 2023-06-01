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
    public partial class UC_OrdersBase : UserControl
    {
        function fn = new function();
        String query;

        public UC_OrdersBase()
        {
            InitializeComponent();
        }

        public void clearAll()
        {
            txtSearchID.Clear();
            txtClientID.Clear();
        }

        public void loadData()
        {
            query = "SELECT * FROM orders";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_OrdersBase_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM orders WHERE cid LIKE '" + txtSearchID.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO orders (cid) VALUES ('" + txtClientID.Text + "')";
            fn.setData(query);
            clearAll();
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "UPDATE orders SET cid = '" + txtClientID.Text + "' WHERE oid = " + id + "";
            fn.setData(query);
            loadData();
        }

        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String cid = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            txtClientID.Text = cid;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete order?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                query = "DELETE FROM orders WHERE oid = " + id + "";
                fn.setData(query);
                loadData();
            }
        }

        private void UC_OrdersBase_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearchOrderID_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM orders WHERE oid LIKE '" + txtSearchOrderID.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
