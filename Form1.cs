using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StoreApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=MARINA-PC\SQLEXPRESS;Initial Catalog=Store;Integrated Security=True");

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            String username, u_password;

            username = txtUsername.Text;
            u_password = txtPassword.Text;

            try
            {
                String q = "SELECT * FROM admins WHERE username = '"+txtUsername.Text+"' AND password = '"+txtPassword.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(q, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txtUsername.Text;
                    u_password = txtPassword.Text;

                    Dashboard ds = new Dashboard();
                    ds.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var myForm = new AllSpices();
            myForm.Show();
            this.Hide();
        }
    }
}