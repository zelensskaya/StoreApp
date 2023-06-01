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
    public partial class UC_PrintItems : UserControl
    {
        function fn = new function();
        String query;

        public UC_PrintItems()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            query = "SELECT items.name AS ItemName, items.price AS ItemPrice, items.category AS ItemCategory, suppliers.surname AS Surname, suppliers.name AS Name, suppliers.midname AS Midname, suppliers.phone AS Phone, suppliers.country AS Country, suppliers.city AS City FROM items INNER JOIN suppliers ON items.sid = suppliers.sid";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = $"Product Report";
            printer.SubTitle = string.Format("Date : {0}", DateTime.Now);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView1);
        }

        private void UC_PrintItems_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void UC_PrintItems_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
