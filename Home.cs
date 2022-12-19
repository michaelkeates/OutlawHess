using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlawHess
{
    public partial class Home : Form
    {
        //get variables from main menu
        MainMenu f3 = new MainMenu();

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            f3.myConn.ConnectionString = f3.connString + f3.details;
            f3.conn = new SQLiteConnection(f3.myConn);
            Properties.Settings.Default.connectionOpen = true;
            Properties.Settings.Default.Save();
            f3.conn.Open();

            if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
            }

            using (SQLiteCommand cmd = f3.conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Customer";
                int Customers = 0;

                Customers = Convert.ToInt32(cmd.ExecuteScalar());

                lblSectionTitle.Text = "" + Customers + "";
            }

            using (SQLiteCommand cmd1 = f3.conn.CreateCommand())
            {
                cmd1.CommandText = "SELECT COUNT(*) FROM Product";
                int Products = 0;

                Products = Convert.ToInt32(cmd1.ExecuteScalar());

                lblAccounts.Text = "" + Products + "";
            }

            f3.conn.Close();
            f3.da_staff.Dispose();

            if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).closeConnection(sender, e);
                (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
            }
        }
    }
}
