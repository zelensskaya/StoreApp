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
    public partial class UC_ItemsBase : UserControl
    {
        function fn = new function();
        String query;

        public UC_ItemsBase()
        {
            InitializeComponent();
        }
        public void clearAll()
        {
            txtSearchItem.Clear();
            txtSearchPrice.Clear();
            comboSearchCategory.SelectedIndex = -1;
            txtSearchSupplierID.Clear();
            txtCategory.SelectedIndex = -1;
            txtItemName.Clear();
            txtPrice.Clear();
            txtSupplierID.Clear();
        }
        public void loadData()
        {
            query = "SELECT * FROM items";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM items WHERE name LIKE '" + txtSearchItem.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            clearAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO items (name, category, price, sid) VALUES ('" + txtItemName.Text + "','" + txtCategory.Text + "'," + txtPrice.Text + ", '"+txtSupplierID.Text+"')";
            fn.setData(query);
            clearAll();
            loadData();
        }

        private void UC_ItemsBase_Load(object sender, EventArgs e)
        {
            loadData();
        }

        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String category = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String item_name = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String price = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            String sid = guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            txtCategory.Text = category;
            txtItemName.Text = item_name;
            txtPrice.Text = price;
            txtSupplierID.Text = sid;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "UPDATE items SET name = '" + txtItemName.Text + "', category = '" + txtCategory.Text + "', price = '"+txtPrice.Text+"', sid = '"+txtSupplierID.Text+"' WHERE iid = " + id + "";
            fn.setData(query);
            clearAll();
            loadData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete item?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                query = "DELETE FROM items WHERE iid = " + id + "";
                fn.setData(query);
                clearAll();
                loadData();
            }
        }

        private void UC_ItemsBase_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearchPrice_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM items WHERE price LIKE '" + txtSearchPrice.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearchSupplierID_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM items WHERE sid LIKE '" + txtSearchSupplierID.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void comboSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            String category = comboSearchCategory.Text;
            query = "SELECT * FROM items WHERE category ='" + category + "'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
