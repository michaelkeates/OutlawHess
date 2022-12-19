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
    public partial class Tranx : Form
    {
        //get variables from main menu
        MainMenu f3 = new MainMenu();

        public Tranx()
        {
            InitializeComponent();
        }

        private void Tranx_Load(object sender, EventArgs e)
        {
            f3.myConn.ConnectionString = f3.connString + f3.details;
            try
            {
                f3.conn = new SQLiteConnection(f3.myConn);
                Properties.Settings.Default.connectionOpen = true;
                Properties.Settings.Default.Save();

                if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
                }

                //We include the Account table by using INNER JOIN to 'join up' the foreign key custid
                //Needed to amend the query and added alias of customer and account table names as kept getting 'ambigous' column error as custid has the same name in both tables
                //string sql = "SELECT A.custid, B.accid, B.prodid, B.balance, B.accrued, B.active FROM Customer A INNER JOIN Account B ON A.custid = B.custid";

                string sql = "SELECT trnxid, accid, action, amnt, event FROM Tranx";

                f3.da_staff = new SQLiteDataAdapter(sql, f3.conn);

                f3.dt_staff.Clear();
                f3.da_staff.Fill(f3.dt_staff);

                dataGridView1.DataSource = f3.dt_staff;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7);

                dataGridView1.Columns[0].HeaderText = "TransactionID";
                dataGridView1.Columns[1].HeaderText = "AccountID";
                dataGridView1.Columns[2].HeaderText = "Action";
                dataGridView1.Columns[3].HeaderText = "Amount";
                dataGridView1.Columns[4].HeaderText = "Event";

                dataGridView1.Sort(this.dataGridView1.Columns["event"], ListSortDirection.Descending);

                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                //button.UseColumnTextForButtonValue = True;
                button.Text = "View Account Details";
                button.Name = "";
                button.UseColumnTextForButtonValue = true;
                button.FlatStyle = FlatStyle.Flat;
                button.DefaultCellStyle.ForeColor = Color.FromArgb(39, 39, 39);
                button.DefaultCellStyle.BackColor = Color.IndianRed;
                button.DefaultCellStyle.SelectionForeColor = Color.FromArgb(39, 39, 39);
                dataGridView1.Columns.Add(button);

                f3.conn.Close();
                f3.da_staff.Dispose();

                if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).closeConnection(sender, e);
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    // Value is given in case the cell is empty
                    string accid = "0";
                    string trnxid = "transaction";
                    string firstname = "firstname";
                    string lastname = "lastname";

                    //is the cell not empty?
                    if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["accid"].Value != null)
                    {
                        //fetch our needed cell values to be strings
                        accid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["accid"].Value.ToString();
                        trnxid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["trnxid"].Value.ToString();
                        //firstname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["firstname"].Value.ToString();
                        //lastname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["lastname"].Value.ToString();

                        if (MessageBox.Show("Are you sure you want to open AccountID? " + accid + " (Transaction ID " + trnxid + ")" + "\n" + "Click Yes to continue.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //Set and save selected customer into the protperites
                            Properties.Settings.Default.currentsession_accountID = accid;
                            Properties.Settings.Default.Save();

                            //We can use the below code to call methods from another form such as the main menu 'accountDetails()' method in this case
                            if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                            {
                                (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).accountDetails(sender, e);
                            }
                        }
                        else
                        {
                            //Nothing
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(trnxid, System.String) LIKE '{0}%'", txtSearch.Text);
        }

        private void txtSearch_MouseDown(object sender, MouseEventArgs e)
        {
            txtSearch.Text = "";
        }
    }
}
