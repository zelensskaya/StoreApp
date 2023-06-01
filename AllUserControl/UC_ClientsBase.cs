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
    public partial class UC_ClientsBase : UserControl
    {
        function fn = new function();
        String query;

        public UC_ClientsBase()
        {
            InitializeComponent();
        }
        public void clearAll()
        {
            txtSearchPhone.Clear();
            txtSearchSurname.Clear();
            txtSurname.Clear();
            txtName.Clear();
            txtMidname.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }

        public void loadData()
        {
            query = "SELECT * FROM clients";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_ClientsBase_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearchPhone_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM clients WHERE phone LIKE '" + txtSearchPhone.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String surname = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String name = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String midname = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            String phone = guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            String email = guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            txtSurname.Text = surname;
            txtName.Text = name;
            txtMidname.Text = midname;
            txtPhone.Text = phone;
            txtEmail.Text = email;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            clearAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO clients (surname, name, midname, phone, email) VALUES ('" + txtSurname.Text + "', '" + txtName.Text + "', '"+txtMidname.Text+"', '"+txtPhone.Text+"', '"+txtEmail.Text+"')";
            fn.setData(query);
            clearAll();
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "UPDATE clients SET surname = '" + txtSurname.Text + "', name = '" + txtName.Text + "', midname = '"+txtMidname.Text+"', phone = '"+txtPhone.Text+"', email = '"+txtEmail.Text+"' WHERE cid = " + id + "";
            fn.setData(query);
            loadData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete client?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                query = "DELETE FROM clients WHERE cid = " + id + "";
                fn.setData(query);
                loadData();
            }
        }

        private void UC_ClientsBase_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearchSurname_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM clients WHERE surname LIKE '" + txtSearchSurname.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
