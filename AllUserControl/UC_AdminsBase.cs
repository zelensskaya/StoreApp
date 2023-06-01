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
    public partial class UC_AdminsBase : UserControl
    {
        function fn = new function();
        String query;

        public UC_AdminsBase()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            query = "SELECT * FROM admins";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void UC_EditAdmins_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM admins WHERE username LIKE '" + txtSearchAdmin.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO admins (username, password, surname, name, midname, phone, email) VALUES ('" + txtUsername.Text + "', '" + txtPassword.Text + "', '"+txtSurname.Text+"', '"+txtName.Text+"', '"+txtMidname.Text+"', '"+txtPhone.Text+"','"+txtEmail.Text+"')";
            fn.setData(query);
            clearAll();
            loadData();
        }
        public void clearAll()
        {
            txtSearchAdmin.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtSurname.Clear();
            txtName.Clear();
            txtMidname.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
        }

        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String username = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String password = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String surname = guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            String name = guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            String midname = guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            String phone = guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            String email = guna2DataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            txtUsername.Text = username;
            txtPassword.Text = password;
            txtSurname.Text = surname;
            txtName.Text = name;
            txtMidname.Text = midname;
            txtPhone.Text = phone;
            txtEmail.Text = email;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "UPDATE admins SET username = '" + txtUsername.Text + "', password = '" + txtPassword.Text + "', surname = '"+txtSurname.Text+"', name = '"+txtName.Text+"', midname = '"+txtMidname.Text+"', phone = '"+txtPhone.Text+"', email = '"+txtEmail.Text+"' WHERE aid = " + id + "";
            fn.setData(query);
            loadData();
        }
        

        private void btnRemove_Click(object sender, EventArgs e) 
        {
            if (MessageBox.Show("Delete admin?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                query = "DELETE FROM admins WHERE aid = " + id + "";
                fn.setData(query);
                loadData();
            }
        }

        private void UC_EditAdmins_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            clearAll();
        }
    }
}
