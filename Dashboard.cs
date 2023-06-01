using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreApp
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 fm = new Form1();
            this.Hide();
            fm.Show();
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AdminsBase1.Visible = false;
            uC_ClientsBase1.Visible = false;
            uC_OrdersBase1.Visible = false;
            uC_BillsBase1.Visible = false;
            uC_NewOrder1.Visible = false;
            uC_ItemsBase1.Visible = false;
            uC_PrintOrder1.Visible = false;
            uC_SuppliersBase1.Visible = false;
            uC_SuppliersEdit1.Visible = false;
            uC_PrintItems1.Visible = false;
            uC_Statistics1.Visible = false;
        }

        private void btnAdminsBase_Click(object sender, EventArgs e)
        {
            uC_AdminsBase1.Visible = true;
            uC_AdminsBase1.BringToFront();
        }

        private void btnClientsBase_Click(object sender, EventArgs e)
        {
            uC_ClientsBase1.Visible = true;
            uC_ClientsBase1.BringToFront();
        }

        private void btnOrdersBase_Click(object sender, EventArgs e)
        {
            uC_OrdersBase1.Visible = true;
            uC_OrdersBase1.BringToFront();
        }

        private void btnBillsBase_Click(object sender, EventArgs e)
        {
            uC_BillsBase1.Visible = true;
            uC_BillsBase1.BringToFront();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            uC_NewOrder1.Visible = true;
            uC_NewOrder1.BringToFront();
        }

        private void btnItemsBase_Click(object sender, EventArgs e)
        {
            uC_ItemsBase1.Visible = true;
            uC_ItemsBase1.BringToFront();
        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            uC_PrintOrder1.Visible = true;
            uC_PrintOrder1.BringToFront();
        }

        private void btnSuppliersBase_Click(object sender, EventArgs e)
        {
            uC_SuppliersBase1.Visible = true;
            uC_SuppliersBase1.BringToFront();
        }

        private void btnSuppliersEdit_Click(object sender, EventArgs e)
        {
            uC_SuppliersEdit1.Visible = true;
            uC_SuppliersEdit1.BringToFront();
        }

        private void btnPrintItems_Click(object sender, EventArgs e)
        {
            uC_PrintItems1.Visible = true;
            uC_PrintItems1.BringToFront();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            uC_Statistics1.Visible = true;
            uC_Statistics1.BringToFront();
        }
    }
}
