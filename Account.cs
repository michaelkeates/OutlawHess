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
    public partial class Account : Form
    {
        //get variables from main menu
        MainMenu f3 = new MainMenu();

        public Account()
        {
            InitializeComponent();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            radioAccountNo.Checked = true;

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

                string sql = "SELECT B.accid, A.custid, A.firstname, A.lastname, A.allowance, B.balance, B.accrued, B.active FROM Customer A INNER JOIN Account B ON A.custid = B.custid";

                f3.da_staff = new SQLiteDataAdapter(sql, f3.conn);

                f3.dt_staff.Clear();
                f3.da_staff.Fill(f3.dt_staff);

                dataGridView1.DataSource = f3.dt_staff;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7);

                dataGridView1.Columns[0].HeaderText = "AccountID";
                dataGridView1.Columns[1].HeaderText = "CustomerID";
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[3].HeaderText = "Last Name";
                dataGridView1.Columns[4].HeaderText = "Allowance";
                dataGridView1.Columns[5].HeaderText = "Balance";
                dataGridView1.Columns[6].HeaderText = "Interest";
                dataGridView1.Columns[7].HeaderText = "Active";
                dataGridView1.Columns[7].Visible = false;

                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                button.Text = "View Account Details";
                button.Name = "";
                button.UseColumnTextForButtonValue = true;
                button.FlatStyle = FlatStyle.Flat;
                button.DefaultCellStyle.ForeColor = Color.FromArgb(39, 39, 39);
                button.DefaultCellStyle.BackColor = Color.IndianRed;
                button.DefaultCellStyle.SelectionForeColor = Color.FromArgb(39, 39, 39);
                dataGridView1.Columns.Add(button);

                if (f3.shownonactiveaccount == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(active, System.String) LIKE '{0}%'", "1");
                }
                else if (f3.shownonactiveaccount == false)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(active, System.String) LIKE '{0}%'", "0");
                }
                else if (f3.showallaccounts == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(active, System.String) LIKE '{0}%'", "");
                }

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

        private void updatePanel()
        {
            try
            {
                f3.conn = new SQLiteConnection(f3.myConn);

                string sql = "SELECT B.accid, A.custid, A.firstname, A.lastname, A.allowance, B.balance, B.accrued, B.active FROM Customer A INNER JOIN Account B ON A.custid = B.custid";

                f3.da_staff = new SQLiteDataAdapter(sql, f3.conn);

                f3.dt_staff.Clear();
                f3.da_staff.Fill(f3.dt_staff);

                //filter table depending on which radio button is clicked which in turn will set boolean to true
                if (f3.shownonactiveaccount == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(active, System.String) LIKE '{0}%'", "1");
                }
                if (f3.shownonactiveaccount == false)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(active, System.String) LIKE '{0}%'", "0");
                }
                if (f3.showallaccounts == true && f3.shownonactiveaccount == false)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(active, System.String) LIKE '{0}%'", "");
                }

                f3.conn.Close();
                f3.da_staff.Dispose();

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
                    string firstname = "firstname";
                    string lastname = "lastname";

                    //is the cell not empty?
                    if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Active"].Value != null)
                    {
                        //fetch our needed cell values to be strings
                        accid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["accid"].Value.ToString();
                        firstname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["firstname"].Value.ToString();
                        lastname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["lastname"].Value.ToString();

                        if (MessageBox.Show("Are you sure you want to open AccountID " + accid + " (" + firstname + " " + lastname + ") account?" + "\n" + "Click Yes to continue.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void btnEndofyeartax_Click(object sender, EventArgs e)
        {
            //Allow the manager to run the end of tax year updates to the database.All account balances should be updated with accrued interest;
            //the accrued interest should then be reset to zero and the customer’s deposit allowances reset.
            //deposit allowance = 15240

            f3.myConn.ConnectionString = f3.connString + f3.details;

            try
            {
                if (MessageBox.Show("Are you sure you want to run the end of year tax update for all accounts?" + "\n" + "Click Yes to continue.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                        int loop = 0;

                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {
                            //reset and clear when loop begins
                            string accid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["accid"].Value.ToString();
                            //declare 365.0m which is 365 days in a year for our calculation
                            decimal year = 365.0m;
                            decimal amnt = 0;
                            string evnt = "";
                            evnt = DateTime.Now.ToString("yyyy\\:MM\\:dd\\ hh\\:mm\\:ss");
                            decimal allowance = 0;
                            decimal balance = 0;
                            decimal accrued = 0;
                            decimal newVal = 0;
                            decimal newVal2 = 0;
                            decimal oldbalance = 0;
                            decimal division = 0;
                            cmd.Parameters.Clear();

                            //get our needed values to calculate overnight calculation for accreued interest
                            //for all accounts owned by customer
                            allowance = Convert.ToDecimal(item.Cells[5].Value);
                            balance = Convert.ToDecimal(item.Cells[6].Value);
                            accrued = Convert.ToDecimal(item.Cells[7].Value);

                            division = decimal.Divide(accrued, year);

                            amnt = division * balance;

                            oldbalance = amnt + balance;

                            //round our value to 2 decimal places
                            newVal = Math.Round(amnt, 2);
                            newVal2 = Math.Round(oldbalance, 2);

                            cmd.CommandText = "UPDATE Account SET accrued = @accrued, balance = @balance WHERE accid = @accid";
                            cmd.Parameters.AddWithValue("@accrued", "0");
                            cmd.Parameters.AddWithValue("@balance", "" + (newVal + newVal2) + "");
                            cmd.Parameters.AddWithValue("@accid", item.Cells[1].Value);
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "UPDATE Customer SET allowance = @allowance WHERE custid = @custid";
                            cmd.Parameters.AddWithValue("@allowance", "15240");
                            cmd.Parameters.AddWithValue("@custid", item.Cells[2].Value);
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "INSERT INTO Tranx (trnxid, accid, action, amnt, event) VALUES (NULL, @accid, @action, @amnt, @event)";
                            cmd.Parameters.AddWithValue("@accid", item.Cells[1].Value);
                            cmd.Parameters.AddWithValue("@action", "interest");
                            cmd.Parameters.AddWithValue("@amnt", "" + newVal + "");
                            cmd.Parameters.AddWithValue("@event", "" + evnt + "");
                            cmd.ExecuteNonQuery();

                            loop++;
                        }
                    }

                    //MessageBox.Show(recordsChanged.ToString() + loop + " records modified");

                    f3.conn.Close();
                    f3.da_staff.Dispose();

                    if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).closeConnection(sender, e);
                        (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
                    }

                    updatePanel();
                }
                else
                {
                    //Nothing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Show all
            if (cmbActive.SelectedIndex == 2)
            {
                f3.shownonactiveaccount = false;
                f3.showallaccounts = true;
                f3.dt_staff.Clear();
                updatePanel();
            }
            //Inactive
            if (cmbActive.SelectedIndex == 1)
            {
                f3.shownonactiveaccount = false;
                f3.showallaccounts = false;
                f3.dt_staff.Clear();
                updatePanel();
            }
            //Active
            if (cmbActive.SelectedIndex == 0)
            {
                f3.shownonactiveaccount = true;
                f3.showallaccounts = false;
                f3.dt_staff.Clear();
                updatePanel();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (radioAccountNo.Checked == true)
            {
                //Have to convert to string otherwise we get error as custid is a int64
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(accid, System.String) LIKE '{0}%'", txtSearch.Text);
            }
            if (radioFirstName.Checked == true)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("FirstName LIKE '{0}%'", txtSearch.Text);
            }
            if (radioLastName.Checked == true)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("LastName LIKE '{0}%'", txtSearch.Text);
            }
        }

        private void txtSearch_MouseDown(object sender, MouseEventArgs e)
        {
            txtSearch.Text = "";
        }
    }
}
