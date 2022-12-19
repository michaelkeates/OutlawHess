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
    public partial class Account_Details : Form
    {
        //get variables from main menu
        MainMenu f3 = new MainMenu();

        public Account_Details()
        {
            InitializeComponent();
        }

        private void Account_Details_Load(object sender, EventArgs e)
        {
            f3.myConn.ConnectionString = f3.connString + f3.details;

            // Value is given in case the cell is empty
            string custid = "0";
            string accid = "0";
            string title = "title";
            string firstname = "firstname";
            string lastname = "lastname";
            string balance = "nothing";
            string dob = "01/01/1900";
            string nicode = "something";
            string email = "something";
            string password = "something";
            string allowance = "something";

            custid = Properties.Settings.Default.currentsession_customerID;
            accid = Properties.Settings.Default.currentsession_accountID;
            title = Properties.Settings.Default.currentsession_customerTitle;
            firstname = Properties.Settings.Default.currentsession_customerFirstname;
            lastname = Properties.Settings.Default.currentsession_customerLastname;

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

                string sql = "SELECT A.accid, C.trnxid, C.action, C.amnt, C.event, B.firstname, B.lastname, A.balance, A.active, B.custid, B.title, B.dob, B.nicode, B.email, B.password, B.allowance FROM Account A INNER JOIN Customer B ON B.custid = A.custid INNER JOIN Tranx C ON C.accid == A.accid WHERE A.accid == " + accid + "";

                f3.da_staff = new SQLiteDataAdapter(sql, f3.conn);

                f3.dt_staff.Clear();
                f3.da_staff.Fill(f3.dt_staff);

                dataGridView1.DataSource = f3.dt_staff;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7);

                //display these in transaction datagridview below
                dataGridView1.Columns[0].HeaderText = "AccountID";
                dataGridView1.Columns[1].HeaderText = "TransactionID";
                dataGridView1.Columns[2].HeaderText = "Action";
                dataGridView1.Columns[3].HeaderText = "Amount";
                dataGridView1.Columns[4].HeaderText = "event";
                //sort by event with latest transaction on top
                dataGridView1.Sort(this.dataGridView1.Columns["event"], ListSortDirection.Descending);

                //We dont need the rest to be displayed so hide columns
                dataGridView1.Columns[5].HeaderText = "FirstName";
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "LastName";
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].HeaderText = "Balance";
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].HeaderText = "Active";
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].HeaderText = "CustomerID";
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].HeaderText = "Title";
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].HeaderText = "DOB";
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].HeaderText = "Nicode";
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].HeaderText = "Email";
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].HeaderText = "Password";
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].HeaderText = "Allowance";
                dataGridView1.Columns[15].Visible = false;

                custid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["custid"].Value.ToString();
                title = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["title"].Value.ToString();
                firstname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["firstname"].Value.ToString();
                lastname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["lastname"].Value.ToString();
                balance = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["balance"].Value.ToString();
                dob = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["dob"].Value.ToString();
                nicode = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["nicode"].Value.ToString();
                email = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["email"].Value.ToString();
                password = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["password"].Value.ToString();
                allowance = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["allowance"].Value.ToString();

                txtCustomerid.Text = "" + custid + "";
                txtTitle.Text = "" + title + "";
                txtFirstname.Text = "" + firstname + "";
                txtLastname.Text = "" + lastname + "";
                txtDob.Text = "" + dob + "";
                txtNicode.Text = "" + nicode + "";
                txtEmail.Text = "" + email + "";
                txtPassword.Text = "" + password + "";

                txtAllowance.Text = "" + allowance + "";
                txtCurrentbalance.Text = "" + balance + "";

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

        private void btnShowpwd_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '.')
            {
                txtPassword.PasswordChar = (char)0;
                btnShowpwd.Text = "Hide Password";
            }
            else
            {
                txtPassword.PasswordChar = '.';
                btnShowpwd.Text = "Show Password";
            }
        }
    }
}
