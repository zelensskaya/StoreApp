using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace StoreApp.AllUserControl
{
    public partial class UC_NewOrder : UserControl
    {

        function fn = new function();
        String query;
        SqlConnection con = new SqlConnection(@"Data Source=MARINA-PC\SQLEXPRESS;Initial Catalog=Store;Integrated Security=True");
        public UC_NewOrder()
        {
            InitializeComponent();
        }

        public void clearAll()
        {

            comboID.SelectedIndex = -1;
            txtOrderID.Clear();
            txtClientID.Clear();
            comboCategory.SelectedIndex = -1;
            txtSearch.Clear();
            txtID.Clear();
            txtItemName.Clear();
            txtPrice.Clear();
            txtTotal.Clear();
            txtQuantity.ResetText();
            labelDiscount.Text = "0%";

            loadData();
            labelTotalAmount.Text = "UAH. ";
        }

        public void loadData()
        {
            query = "SELECT * FROM bills WHERE oid = '" + txtOrderID.Text + "'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        public void cc()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT cid FROM clients";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboID.Items.Add(dr["cid"].ToString());
            }
            con.Close();
        }

        private void UC_NewOrder_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            String category = comboCategory.Text;
            query = "SELECT name FROM items WHERE category ='" + category + "'";
            showItemList(query);
        }

        private void showItemList(String query)
        {
            listBox1.Items.Clear();
            DataSet ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            String category = comboCategory.Text;
            query = "SELECT name FROM items WHERE category ='" + category + "' AND name LIKE '" + txtSearch.Text + "%'";
            showItemList(query);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.Value = 0;
            txtQuantity.ResetText();
            txtTotal.Clear();

            String text = listBox1.GetItemText(listBox1.SelectedItem);
            txtItemName.Text = text;
            query = "SELECT price FROM items WHERE name = '" + text + "'";
            DataSet ds = fn.getData(query);
            try
            {
                txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }

            query = "SELECT iid FROM items WHERE name = '" + text + "'";
            DataSet ds2 = fn.getData(query);
            try
            {
                txtID.Text = ds2.Tables[0].Rows[0][0].ToString();
            }
            catch { }

        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(txtQuantity.Value.ToString());
            Double price = Double.Parse(txtPrice.Text);
            txtTotal.Text = (quan * price).ToString();
        }

        protected int n;

        double amount, discount, total_for_order;
        public void countTotal()
        {
            query = "SELECT SUM(price) FROM bills WHERE oid = '" + txtOrderID.Text + "'";
            DataSet ds = fn.getData(query);
            total_for_order = Double.Parse(ds.Tables[0].Rows[0][0].ToString());
            amount = Double.Parse(ds.Tables[0].Rows[0][0].ToString());
            if (amount > 200)
            {
                discount = 15;
                amount = amount - amount * (discount / 100);
                labelDiscount.Text = $"{discount}%";
            }
            else if (amount > 100)
            {
                discount = 10;
                amount = amount - amount * (discount / 100);
                labelDiscount.Text = $"{discount}%";
            }
            else
            {
                discount = 0;
                labelDiscount.Text = $"{discount}%";
            }
            labelTotalAmount.Text = "UAH. " + amount;
        }

        private void btnAddtoBill_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "0" && txtTotal.Text != "")
            {
                //Double price = Double.Parse(txtPrice.Text.ToString());

                query = "INSERT INTO bills (iid, name, unity_price, quantity, price, oid) VALUES ('" + txtID.Text + "', '"+txtItemName.Text+ "', '" + txtPrice.Text+ "', '"+txtQuantity.Value+ "', '" + txtTotal.Text+"', '"+txtOrderID.Text+"')";
                fn.setData(query);
                loadData();
            }
            else
            {
                MessageBox.Show("Minimum Quantity need to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            countTotal();
        }

        int id;

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Delete item?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                query = "DELETE FROM bills WHERE bid = " + id + "";
                fn.setData(query);
                loadData();
            }
            countTotal();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            query = "INSERT INTO orders (cid) VALUES ('" + comboID.Text + "')";
            fn.setData(query);
        }

        private void btnOrderDetails_Click(object sender, EventArgs e)
        {
            query = "SELECT MAX(oid) FROM orders";
            DataSet ds = fn.getData(query);
            try
            {
                txtOrderID.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }

            query = "SELECT cid FROM orders WHERE oid = '"+txtOrderID.Text+"'";
            DataSet ds2 = fn.getData(query);
            try
            {
                txtClientID.Text = ds2.Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string order_num = txtOrderID.Text;
            string client_id = txtClientID.Text;

            DGVPrinter printer = new DGVPrinter();
            printer.Title = $"Order № {order_num}\r\nClient ID : {client_id}";
            printer.SubTitle = string.Format("Date : {0}", DateTime.Now);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = $"Total Amount : UAH. {total_for_order}\r\nDiscount : {discount}%\r\nTotal Payable Amount : {labelTotalAmount.Text}";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView1);

            labelTotalAmount.Text = "UAH. ";
        }

        private void UC_NewOrder_Enter(object sender, EventArgs e)
        {
            loadData();
            comboID.Items.Clear();
            cc();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            clearAll();
        }
    }
}
