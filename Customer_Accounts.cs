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
    public partial class Customer_Accounts : Form
    {
        // Value is given in case the cell is empty
        string custid = "0";
        string prodid = "0";
        string title = "title";
        string firstname = "firstname";
        string lastname = "lastname";

        decimal finalvalue;
        int recordsChanged;

        //get variables from main menu
        MainMenu f3 = new MainMenu();

        public Customer_Accounts()
        {
            InitializeComponent();
        }

        private void updatePanel()
        {
            //update the panel to show changes made by making a connection again to reload the data
            try
            {
                f3.conn = new SQLiteConnection(f3.myConn);

                string sql = "SELECT B.accid, B.prodid, A.firstname, A.lastname, B.balance, B.accrued, B.active, C.intrate FROM Customer A INNER JOIN Account B ON A.custid = B.custid INNER JOIN Product C ON C.prodid == B.prodid WHERE A.custid == " + custid + "";

                f3.da_staff = new SQLiteDataAdapter(sql, f3.conn);

                f3.dt_staff.Clear();
                f3.da_staff.Fill(f3.dt_staff);

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
            //try catch cany errors that might happen
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Customer_Accounts_Load(object sender, EventArgs e)
        {
            radioAccountNo.Checked = true;

            //fetch customer details that was stored from the Customer form from setting properties
            custid = Properties.Settings.Default.currentsession_customerID;
            title = Properties.Settings.Default.currentsession_customerTitle;
            firstname = Properties.Settings.Default.currentsession_customerFirstname;
            lastname = Properties.Settings.Default.currentsession_customerLastname;

            lblCustomerName.Text = "Customer: " + title + " " + firstname + " " + lastname + "";

            f3.myConn.ConnectionString = f3.connString + f3.details;

            try
            {
                //We include the Account table by using INNER JOIN to 'join up' the foreign key custid
                //Needed to amend the query and added alias of customer and account table names as kept getting 'ambigous' column error as custid has the same name in both tables

                f3.conn = new SQLiteConnection(f3.myConn);
                Properties.Settings.Default.connectionOpen = true;
                Properties.Settings.Default.Save();

                if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
                }

                //string sql = "SELECT B.accid, B.prodid, A.firstname, A.lastname, B.balance, B.accrued, B.active, C.intrate FROM Customer A INNER JOIN Account B ON A.custid = B.custid WHERE A.custid = " + custid + " INNER JOIN Product C ON B.prodid = C.prodid WHERE B.prodid = " + prodid + "";

                string sql = "SELECT B.accid, B.prodid, A.firstname, A.lastname, B.balance, B.accrued, B.active, C.intrate FROM Customer A INNER JOIN Account B ON A.custid = B.custid INNER JOIN Product C ON C.prodid == B.prodid WHERE A.custid == " + custid + "";

                f3.da_staff = new SQLiteDataAdapter(sql, f3.conn);

                f3.dt_staff.Clear();
                f3.da_staff.Fill(f3.dt_staff);

                dataGridView1.DataSource = f3.dt_staff;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7);

                dataGridView1.Columns[0].HeaderText = "AccountID";
                dataGridView1.Columns[1].HeaderText = "ProductID";
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "firstname";
                dataGridView1.Columns[3].HeaderText = "lastname";
                dataGridView1.Columns[4].HeaderText = "Balance";
                dataGridView1.Columns[5].HeaderText = "Accrued";
                dataGridView1.Columns[6].HeaderText = "Active";
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].HeaderText = "Interest";

                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                //button.UseColumnTextForButtonValue = True;
                button.Text = "View Account Details";
                button.Name = "";
                button.UseColumnTextForButtonValue = true;
                button.FlatStyle = FlatStyle.Flat;
                //button.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
                //button.DefaultCellStyle.BackColor = Color.FromArgb(39, 39, 39);
                //button.DefaultCellStyle.SelectionForeColor = Color.FromArgb(39, 39, 39);

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

                //check to make sure connection is closed
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

        private void txtSearch_MouseDown(object sender, MouseEventArgs e)
        {
            txtSearch.Text = "";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    // Value is given in case the cell is empty
                    string accid = "0";
                    //string title = "title";
                    string firstname = "firstname";
                    string lastname = "lastname";

                    //is the cell not empty?
                    if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Active"].Value != null)
                    {
                        //fetch our needed cell values to be strings
                        accid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["accid"].Value.ToString();
                        //title = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["title"].Value.ToString();
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

        private void btnCalcaccured_Click(object sender, EventArgs e)
        {
            //Allow the manager to run the overnight calculation for accrued interest for all accounts. The formula is… 
            //Accrued Interest = Accrued Interest + (Balance* Account Annual Interest Rate / 365.0)

            f3.myConn.ConnectionString = f3.connString + f3.details;

            try
            {
                // Value is given in case the cell is empty
                string accid = "0";
                //string title = "title";
                string firstname = "firstname";
                string lastname = "lastname";
                //double balance = 0;
                //double accrued = 0;
                //double interest = 0;
                //double year = 365.0;
                //double accreudinterest = 0;

                //fetch our needed cell values to be strings
                accid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["accid"].Value.ToString();
                //title = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["title"].Value.ToString();
                firstname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["firstname"].Value.ToString();
                lastname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["lastname"].Value.ToString();


                if (MessageBox.Show("Are you sure you want to run the overnight calculation for accured interest for all visible accounts owned by " + firstname + " " + lastname + ")?" + "\n" + "Click Yes to continue.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    f3.conn = new SQLiteConnection(f3.myConn);
                    f3.conn.Open();
                    Properties.Settings.Default.connectionOpen = true;
                    Properties.Settings.Default.Save();

                    if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                    {
                        (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
                    }

                    //Set and save selected customer into the protperites
                    Properties.Settings.Default.currentsession_accountID = accid;
                    Properties.Settings.Default.Save();

                    using (SQLiteCommand cmd = f3.conn.CreateCommand())
                    {
                        int loop = 0;

                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {
                            //reset and clear when loop begins
                            decimal times = 0;
                            cmd.Parameters.Clear();

                            //get our needed values to calculate overnight calculation for accreued interest
                            //for all accounts owned by customer
                            decimal balance = Convert.ToDecimal(item.Cells[5].Value);
                            decimal accrued = Convert.ToDecimal(item.Cells[6].Value);
                            decimal interest = Convert.ToDecimal(item.Cells[8].Value);

                            times = balance * interest;

                            //declare 365.0m which is 365 days in a year
                            decimal year = 365.0m;

                            //divide value from balance * account annual interest rate (product interest??)
                            decimal division = decimal.Divide(times, year);

                            //round our value to 2 decimal places
                            var newVal = Math.Round(division, 2);

                            //add our 2 decimal values together
                            decimal calculatedvalue = decimal.Add(newVal, accrued);

                            //pass our final value to global variable
                            finalvalue = calculatedvalue;

                            //add values to the sqlite table and execute changes
                            cmd.CommandText = "UPDATE Account SET accrued = @accrued WHERE accid = @accid";

                            cmd.Parameters.AddWithValue("@accrued", "" + finalvalue + "");
                            cmd.Parameters.AddWithValue("@accid", item.Cells[1].Value);
                            cmd.ExecuteNonQuery();

                            //f3.conn.Close();
                            //recordsChanged = cmd.ExecuteNonQuery();

                            loop++;
                        }
                        //fix - removed close inside loop as only one row would update. silly error!
                        MessageBox.Show(recordsChanged.ToString() + loop + " records modified");
                    }

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
    }
}
