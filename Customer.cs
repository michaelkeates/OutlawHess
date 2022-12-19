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
    public partial class Customer : Form
    {
        //get variables from main menu
        MainMenu f3 = new MainMenu();

        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            radioAccountNo.Checked = true;

            //add file location and connection detail to connection variable
            f3.myConn.ConnectionString = f3.connString + f3.details;

            try
            {
                //open connection and set setting to open to alert user
                f3.conn = new SQLiteConnection(f3.myConn);
                Properties.Settings.Default.connectionOpen = true;
                Properties.Settings.Default.Save();

                //call checkConnection method from MainMenu form
                //makes it easier instead of rewriting method for each form
                if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
                }

                //declare sql command
                string sql = "SELECT custid, title, firstname, lastname, dob, nicode, allowance FROM Customer";

                //declare datagrid table
                f3.da_staff = new SQLiteDataAdapter(sql, f3.conn);

                //make sure we clear datagrid first and then fill it with information
                f3.dt_staff.Clear();
                f3.da_staff.Fill(f3.dt_staff);

                //declare datasource for datagrid table and set up column headerings and buttons
                dataGridView1.DataSource = f3.dt_staff;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7);

                dataGridView1.Columns[0].HeaderText = "ACNo";
                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[2].HeaderText = "FirstName";
                dataGridView1.Columns[3].HeaderText = "LastName";
                dataGridView1.Columns[4].HeaderText = "DateofBirth";
                dataGridView1.Columns[5].HeaderText = "Nicode";
                dataGridView1.Columns[6].HeaderText = "Allowance";
                //Sort column by order of allowance
                dataGridView1.Sort(this.dataGridView1.Columns["Allowance"], ListSortDirection.Descending);

                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                //button.UseColumnTextForButtonValue = True;
                button.Text = "Open";
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

                //close connection to database
                f3.conn.Close();
                f3.da_staff.Dispose();

                //call methods from MainMenu form to make sure connection is closed and to check to confirm
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (radioAccountNo.Checked == true)
            {
                //Have to convert to string otherwise we get error as custid is a int64
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(custid, System.String) LIKE '{0}%'", txtSearch.Text);
            }
            if (radioTitle.Checked == true)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Title LIKE '{0}%'", txtSearch.Text);
            }
            if (radioFirstName.Checked == true)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("FirstName LIKE '{0}%'", txtSearch.Text);
            }
            if (radioLastName.Checked == true)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("LastName LIKE '{0}%'", txtSearch.Text);
            }
            if (radioDOB.Checked == true)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("dob LIKE '{0}%'", txtSearch.Text);
            }
            if (radioNicode.Checked == true)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nicode LIKE '{0}%'", txtSearch.Text);
            }
        }

        private void txtSearch_MouseDown(object sender, MouseEventArgs e)
        {
            txtSearch.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    // Value is given in case the cell is empty
                    string custid = "0";
                    string title = "title";
                    string firstname = "firstname";
                    string lastname = "lastname";

                    //is the cell not empty?
                    if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Title"].Value != null)
                    {
                        //fetch our needed cell values to be strings
                        custid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["custid"].Value.ToString();
                        title = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["title"].Value.ToString();
                        firstname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["firstname"].Value.ToString();
                        lastname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["lastname"].Value.ToString();

                        if (MessageBox.Show("Are you sure you want to open CustomerID " + custid + " (" + title + " " + firstname + " " + lastname + ") account?" + "\n" + "Click Yes to continue.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //Set and save selected customer into the protperites
                            Properties.Settings.Default.currentsession_customerID = custid;
                            Properties.Settings.Default.currentsession_customerTitle = title;
                            Properties.Settings.Default.currentsession_customerFirstname = firstname;
                            Properties.Settings.Default.currentsession_customerLastname = lastname;
                            Properties.Settings.Default.Save();

                            //We can use the below code to call methods from another form such as the main menu 'customerAccounts()' method in this case
                            if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                            {
                                (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).customerAccounts(sender, e);
                            }
                        }
                        else
                        {
                            //Nothing
                        }
                    }
                }
            }
            //catch any errors that might happen
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
