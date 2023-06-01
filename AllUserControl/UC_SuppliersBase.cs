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
    public partial class UC_SuppliersBase : UserControl
    {
        function fn = new function();
        String query;

        public UC_SuppliersBase()
        {
            InitializeComponent();
        }
        public void clearAll()
        {
            txtSurname.Clear();
            txtName.Clear();
            txtMidname.Clear();
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

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM suppliers WHERE surname LIKE '" + txtSurname.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            clearAll();
        }

        private void UC_SuppliersBase_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM suppliers WHERE name LIKE '" + txtName.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM suppliers WHERE phone LIKE '" + txtPhone.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_SuppliersBase_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM suppliers WHERE email LIKE '" + txtEmail.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM suppliers WHERE country LIKE '" + txtCountry.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM suppliers WHERE city LIKE '" + txtCity.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtMidname_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM suppliers WHERE midname LIKE '" + txtMidname.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
