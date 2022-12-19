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
    public partial class Product_Interest : Form
    {
        //Hack to enable drop shadow
        private const int CS_DROPSHADOW = 0x00020000;

        //get variables from main menu
        MainMenu f3 = new MainMenu();

        string intrate2;
        string prodid;
        string intratenew;

        public Product_Interest()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void Product_Interest_Load(object sender, EventArgs e)
        {
            //Set and save selected customer into the protperites
            intrate2 = Properties.Settings.Default.currentInterestRate;
            prodid = Properties.Settings.Default.currentProductID;

            txtSubmit.Text = "" + intrate2 + "";

            lblMessage.Text = "Would you like to change the interest rate for Product ID " + prodid + " which currently " + "\n" + "has a interest rate of " + intrate2 + "?";
        }

        private void updatePanel()
        {
            try
            {
                f3.conn = new SQLiteConnection(f3.myConn);

                string sql = "SELECT prodid, isaname, staus, transin, intrate FROM Product";

                f3.da_staff = new SQLiteDataAdapter(sql, f3.conn);

                f3.dt_staff.Clear();
                f3.da_staff.Fill(f3.dt_staff);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            f3.myConn.ConnectionString = f3.connString + f3.details;

            try
            {
                f3.conn = new SQLiteConnection(f3.myConn);
                f3.conn.Open();
                Properties.Settings.Default.connectionOpen = true;
                Properties.Settings.Default.Save();

                if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
                }

                using (SQLiteCommand cmd = f3.conn.CreateCommand())
                {
                    //declare mysqlite command update where id is = to prodid variable
                    cmd.CommandText = "UPDATE Product SET intrate = @intrate WHERE prodid = @id";

                    cmd.Parameters.AddWithValue("@intrate", txtSubmit.Text);
                    cmd.Parameters.AddWithValue("@id", "" + prodid + "");

                    int recordsChanged = cmd.ExecuteNonQuery();

                    MessageBox.Show(recordsChanged.ToString() + " records modified");

                    //conn.Close();

                    //updatePanel();
                }

                //conn.Close();

                f3.conn.Close();
                f3.da_staff.Dispose();

                if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).closeConnection(sender, e);
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
                }

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
