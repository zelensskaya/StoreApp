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
    public partial class UC_SuppliersEdit : UserControl
    {
        function fn = new function();
        String query;

        public UC_SuppliersEdit()
        {
            InitializeComponent();
        }
        public void clearAll()
        {
            txtSearch.Clear();
            txtSurname.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtCountry.Clear();
            txtCity.Clear();
        }

        public void loadData()
        {
            query = "SELECT * FROM suppliers";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_SuppliersEdit_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void UC_SuppliersEdit_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM suppliers WHERE surname LIKE '" + txtSurname.Text + "%'";
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
            String country = guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            String city = guna2DataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            txtSurname.Text = surname;
            txtName.Text = name;
            txtMidname.Text = midname;
            txtPhone.Text = phone;
            txtEmail.Text = email;
            txtCountry.Text = country;
            txtCity.Text = city;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO suppliers (surname, name, midname, phone, email, country, city) VALUES ('" + txtSurname.Text + "','" + txtName.Text + "', '"+txtMidname.Text+"', '" + txtPhone.Text + "', '"+txtEmail.Text+"', '"+txtCountry.Text+"', '"+txtCity.Text+"')";
            fn.setData(query);
            clearAll();
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "UPDATE suppliers SET surname = '" + txtSurname.Text + "', name = '" + txtName.Text + "', midname = '"+txtMidname.Text+"', phone = '" + txtPhone.Text + "', email = '"+txtEmail.Text+"', country = '"+txtCountry.Text+"', city = '"+txtCity.Text+"' WHERE sid = " + id + "";
            fn.setData(query);
            clearAll();
            loadData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete supplier?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                query = "DELETE FROM suppliers WHERE sid = " + id + "";
                fn.setData(query);
                clearAll();
                loadData();
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            clearAll();
        }
    }
}
