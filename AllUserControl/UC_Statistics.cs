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
    public partial class UC_Statistics : UserControl
    {
        function fn = new function();
        String query;

        public UC_Statistics()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            query = "SELECT TOP(5) * FROM items ORDER BY price;";
            DataSet ds1 = fn.getData(query);
            guna2DataGridView1.DataSource = ds1.Tables[0];

            query = "SELECT TOP(5) * FROM items ORDER BY price DESC;";
            DataSet ds2 = fn.getData(query);
            guna2DataGridView2.DataSource = ds2.Tables[0];

            query = "SELECT clients.cid, clients.surname, clients.name, clients.midname, COUNT(orders.oid) AS number_of_orders FROM clients, orders WHERE clients.cid = orders.cid GROUP BY clients.cid, clients.surname, clients.name, clients.midname ORDER BY COUNT(orders.oid) DESC;";
            DataSet ds3 = fn.getData(query);
            guna2DataGridView3.DataSource = ds3.Tables[0];

            query = "SELECT orders.oid, SUM(bills.price) AS price FROM orders, bills WHERE orders.oid = bills.oid GROUP BY orders.oid ORDER BY SUM(bills.price) DESC;";
            DataSet ds4 = fn.getData(query);
            guna2DataGridView4.DataSource = ds4.Tables[0];
        }

        private void UC_Statistics_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void UC_Statistics_Enter(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
