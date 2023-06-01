using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace StoreApp.AllUserControl
{
    public partial class UC_PrintOrder : UserControl
    {
        function fn = new function();
        String query;

        public UC_PrintOrder()
        {
            InitializeComponent();
        }

        public void clearAll()
        {
            txtSearchID.Clear();
            txtOrderID.Clear();
            txtClientID.Clear();
            loadDataBills();
            loadDataOrders();
            labelTotalAmount.Text = "UAH. ";
            labelDiscount.Text = "0%";
        }

        public void loadDataBills()
        {
            query = "SELECT * FROM bills WHERE oid = '"+txtOrderID.Text+"'";
            DataSet ds = fn.getData(query);
            guna2DataGridView2.DataSource = ds.Tables[0];
        }

        public void loadDataOrders()
        {
            query = "SELECT * FROM orders";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

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
            printer.PrintDataGridView(guna2DataGridView2);

            clearAll();
            labelTotalAmount.Text = "UAH. ";
        }

        private void UC_PrintOrder_Load(object sender, EventArgs e)
        {
            loadDataBills();
            loadDataOrders();
        }

        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {
            query = "SELECT * FROM orders WHERE cid LIKE '" + txtSearchID.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String oid = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            String cid = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            txtOrderID.Text = oid;
            txtClientID.Text = cid;
            loadDataBills();
            countTotal();
        }

        int id;

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete bill?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                query = "DELETE FROM bills WHERE bid = " + id + "";
                fn.setData(query);
                loadDataBills();
                loadDataOrders();
            }
            countTotal();
        }

        private void UC_PrintOrder_Enter(object sender, EventArgs e)
        {
            loadDataBills();
            loadDataOrders();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            clearAll();
        }
    }
}