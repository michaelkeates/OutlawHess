using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SQLite;
//using System.IO.Compression;
using Ionic.Zip;
using System.IO;

namespace OutlawHess
{
    //EASIER tasks: 

    //Allow the manager to select any open issue ISA product and change its status to closed. [DONE]

    //Allow the manager to list all customers in order of their remaining tax year deposit allowance. [DONE]

    //Allow the manager to alter the interest rate paid on a selected ISA product. [DONE]


    //HARDER tasks:

    //Show all customers, allowing one to be selected.Then show all accounts owned by the selected customer, and allow one to be selected.Finally, show the current balance of the selected account. [DONE]

    //Allow the manager to run the overnight calculation for accrued interest for all accounts. The formula is… 
    //Accrued Interest = Accrued Interest + (Balance* Account Annual Interest Rate / 365.0) [DONE]

    //Allow the manager to run the end of tax year updates to the database.All account balances should be updated with accrued interest; the accrued interest should then be reset to zero and the customer’s deposit allowances reset. [DONE]

    public partial class MainMenu : Form
    {
        string timeOpen;

        //public string SomePropertyName { get; set; }

        //we can fetch such as location of database file from settings and use as variable throughout
        public string details = Properties.Settings.Default.connectionDetails;
        public string connString = Properties.Settings.Default.connectionString;
        public string intrate;

        //Creates the connection object between C# and SQLite database
        public SQLiteConnection myConn = new SQLiteConnection();
        public SQLiteConnection conn = new SQLiteConnection();
        public SQLiteDataAdapter da_staff = new SQLiteDataAdapter();
        public DataTable dt_staff = new DataTable();

        //Is button highlighted or not?
        public bool isconnectionopen = false;
        bool mainmenubuttonhighlighted = true;
        bool customerbuttonhighlighted = false;
        bool accountbuttonhighlighted = false;
        bool productsbuttonhighlighted = false;
        bool tranxbuttonhighlighted = false;

        public bool shownonactiveaccount = true;
        public bool showallaccounts = false;

        public bool showopenproducts = true;
        public bool showallproducts = false;

        public bool showtransinproducts = true;
        public bool showalltransinproducts = false;

        //Hack to enable drop shadow
        private const int CS_DROPSHADOW = 0x00020000;

        //Move borderless window
        private bool mouseDown;
        private Point lastLocation;

        public MainMenu()
        {
            InitializeComponent();

            lblTime.Text = "Duration: 00:00:00";
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

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //if db/dogbytes.db exists
            if (File.Exists(@"" + details + ""))
            {
                lblloadingstatus.Text = "Status: Database is ready";
                this.connectionStatus.Image = ((System.Drawing.Image)(Properties.Resources.connectionreadyicon));
            }

            //call method to check how many isa issues are open to update our notification badge
            getISAissues(sender, e);

            Home dashboard = new Home() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.formPanel.Controls.Add(dashboard);
            dashboard.Show();

            //Fetch todays date and time and then add to 0 1 for every tick to display how long bank manager has been logged in
            var startTime = DateTime.Now;

            timer1.Enabled = true;
            timer1.Tick += (obj, args) => lblTime.Text = "Duration: " + (TimeSpan.FromMinutes(0) + (DateTime.Now - startTime)).ToString("hh\\:mm\\:ss");
        }

        public void openConnection(object sender, EventArgs e)
        {
            //Connect to database
            string Details = @"db/dogbytes.db";
            myConn.ConnectionString = @"Data source = " + Details;

            //Establish connection
            conn = new SQLiteConnection(myConn);

            //alert user connection is open
            lblloadingstatus.Text = "Status: Connection is Open " + Details;
            this.connectionStatus.Image = ((System.Drawing.Image)(Properties.Resources.connectionopenicon));
        }

        public void checkConnection(object sender, EventArgs e)
        {
            //Check to see if connection to database is open and update label
            if (Properties.Settings.Default.connectionOpen == true)
            {
                lblloadingstatus.Text = "Status: Connection is Open " + details;
                //Get current time as variable and save to settings
                timeOpen = DateTime.Now.ToString("HH\\:mm\\:ss");
                this.connectionStatus.Image = ((System.Drawing.Image)(Properties.Resources.connectionopenicon));
            }
            //If connection is closed then update label with time saved from variable
            else if (Properties.Settings.Default.connectionOpen == false)
            {
                lblloadingstatus.Text = "Status: Connection was last opened at " + timeOpen;
                this.connectionStatus.Image = ((System.Drawing.Image)(Properties.Resources.connectionreadyicon));
            }
            //make sure that the db file exists
            else if (!File.Exists(@"" + details + ""))
            {
                lblloadingstatus.Text = "Status: Database does not exist " + details;
                this.connectionStatus.Image = ((System.Drawing.Image)(Properties.Resources.connectionclosedicon));
            }
            //else connection is open and the database exists
            else if (myConn.State == ConnectionState.Open || conn.State == ConnectionState.Open)
            {
                lblloadingstatus.Text = "Status: Connection is Open " + details;
            }
        }

        public void closeConnection(object sender, EventArgs e)
        {
            //amend setting to false as conenction is closed.
            Properties.Settings.Default.connectionOpen = false;
            Properties.Settings.Default.Save();

            //forces collection of garbage including connections made to the database that were closed but still 'silently' open
            //fix to be able to close form processes as without we get error that 'file is in used' and cannot be removed
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        public void getISAissues(object sender, EventArgs e)
        {
            //set up connection and open it
            myConn.ConnectionString = connString + details;
            conn = new SQLiteConnection(myConn);
            Properties.Settings.Default.connectionOpen = true;
            Properties.Settings.Default.Save();
            conn.Open();

            if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
            }

            //count amount of rows there are in product table where status is open
            //we can set int the number of open issues to alert user
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Product WHERE staus = 'open'";
                int Issues = 0;

                Issues = Convert.ToInt32(cmd.ExecuteScalar());

                lblissues.Text = "" + Issues + "";

                if (Issues == 0)
                {
                    //if there are no product open statuses then we dont need the notification
                    //so hide them
                    picISA.Visible = false;
                    lblissues.Visible = false;
                }
                else
                {
                    picISA.Visible = true;
                    lblissues.Visible = true;
                }
            }

            conn.Close();

            //retrieve methods from the main menu where we close the connection and then another check to make sure the connection was indeed closed
            if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).closeConnection(sender, e);
                (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
            }
        }

        private void checkButtons()
        {
            //Check if any buttons have been clicked. If button is clicked, other buttons won't be 'highlighted' and only
            //clicked button is highlighted

            if (mainmenubuttonhighlighted == true)
            {
                mainmenubuttonhighlighted = false;
                this.btnMainMenu.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.homeButtonDefault));
            }

            if (customerbuttonhighlighted == true)
            {
                customerbuttonhighlighted = false;
                this.btnCustomers.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.customerButtonDefault));
            }

            if (accountbuttonhighlighted == true)
            {
                accountbuttonhighlighted = false;
                this.btnAccounts.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.accountButtonDefault));
            }

            if (productsbuttonhighlighted == true)
            {
                productsbuttonhighlighted = false;
                this.btnProducts.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.productsButtonDefault));
            }

            if (tranxbuttonhighlighted == true)
            {
                tranxbuttonhighlighted = false;
                this.btnTranx.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.tranxButtonDefault));
            }
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_close_hover));
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_close_default));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.formPanel.Controls.Clear();
            Customer f3 = new Customer();
            f3.Close();
            SQLiteConnection.ClearAllPools();
            checkConnection(sender, e);

            //If user clicks continue to close program. the db file is compressed, encrypted and added to a password protected zip file
            if (MessageBox.Show("Are you sure you want to exit?" + "\n" + "Click Yes to exit.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //encrypt, compress updated dogbytes file to dogbytes.bin (zip)
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = "12345678";
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                    zip.AddFile(@""+ details + "", "");
                    zip.Save(@"db\\dogbytes.bin");
                }

                //delete dogbytes.db
                File.Delete(@"" + details + "");

                //kill all processes to make sure there is nothing running in the background
                Application.Exit();
                foreach (var process in Process.GetProcessesByName("OutlawHess"))
                {
                    process.Kill();
                }
            }
            else
            {
                //Nothing
            }
        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            this.btnMinimize.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_minimize_hover));
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            this.btnMinimize.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_minimize_default));
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCustomers_MouseHover(object sender, EventArgs e)
        {
            this.btnCustomers.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.customerButtonHighlighted));
        }

        private void btnCustomers_MouseLeave(object sender, EventArgs e)
        {
            if (customerbuttonhighlighted == true)
            {
                this.btnCustomers.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.customerButtonHighlighted));
            }
            else
            {
                this.btnCustomers.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.customerButtonDefault));
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            checkButtons();

            customerbuttonhighlighted = true;
            this.btnCustomers.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.customerButtonHighlighted));

            this.formPanel.Controls.Clear();
            lblSectionTitle.Text = "Customers";

            //if connection is open. update text
            if (myConn.State == ConnectionState.Open)
            {
                lblloadingstatus.Text = "Status: Connection is Open " + details;
            }

            //load form and display within a panel
            Customer customerform = new Customer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.formPanel.Controls.Add(customerform);
            customerform.Show();
        }

        public void customerAccounts(object sender, EventArgs e)
        {
            lblSectionTitle.Text = "Customer Accounts";
            formPanel.Controls.Clear();

            //load form and display within a panel
            Customer_Accounts customeraccountform = new Customer_Accounts() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.formPanel.Controls.Add(customeraccountform);
            customeraccountform.Show();
        }

        private void btnAccounts_MouseHover(object sender, EventArgs e)
        {
            this.btnAccounts.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.accountButtonHighlighted));
        }

        private void btnAccounts_MouseLeave(object sender, EventArgs e)
        {
            if (accountbuttonhighlighted == true)
            {
                this.btnAccounts.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.accountButtonHighlighted));
            }
            else
            {
                this.btnAccounts.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.accountButtonDefault));
            }
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            checkButtons();

            accountbuttonhighlighted = true;
            this.btnAccounts.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.accountButtonHighlighted));

            this.formPanel.Controls.Clear();
            lblSectionTitle.Text = "Accounts";

            if (myConn.State == ConnectionState.Open)
            {
                lblloadingstatus.Text = "Status: Connection is Open " + details;
            }

            //load form and display within a panel
            Account accountform = new Account() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.formPanel.Controls.Add(accountform);
            accountform.Show();
        }

        public void accountDetails(object sender, EventArgs e)
        {
            lblSectionTitle.Text = "Account Details";
            formPanel.Controls.Clear();

            //load form and display within a panel
            Account_Details accountdetailsform = new Account_Details() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.formPanel.Controls.Add(accountdetailsform);
            accountdetailsform.Show();
        }

        private void btnProducts_MouseHover(object sender, EventArgs e)
        {
            this.btnProducts.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.productsButtonHighlighted));
        }

        private void btnProducts_MouseLeave(object sender, EventArgs e)
        {
            if (productsbuttonhighlighted == true)
            {
                this.btnProducts.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.productsButtonHighlighted));
            }
            else
            {
                this.btnProducts.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.productsButtonDefault));
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            checkButtons();
            getISAissues(sender, e);

            productsbuttonhighlighted = true;
            this.btnProducts.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.productsButtonHighlighted));

            this.formPanel.Controls.Clear();
            lblSectionTitle.Text = "Products";

            if (myConn.State == ConnectionState.Open)
            {
                lblloadingstatus.Text = "Status: Connection is Open " + details;
            }

            //load form and display within a panel
            Product productform = new Product() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.formPanel.Controls.Add(productform);
            productform.Show();
        }

        private void btnTranx_MouseHover(object sender, EventArgs e)
        {
            this.btnTranx.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.tranxButtonHighlighted));
        }

        private void btnTranx_MouseLeave(object sender, EventArgs e)
        {
            if (tranxbuttonhighlighted == true)
            {
                this.btnTranx.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.tranxButtonHighlighted));
            }
            else
            {
                this.btnTranx.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.tranxButtonDefault));
            }
        }

        private void btnTranx_Click(object sender, EventArgs e)
        {
            checkButtons();

            tranxbuttonhighlighted = true;
            this.btnTranx.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.tranxButtonHighlighted));

            this.formPanel.Controls.Clear();
            lblSectionTitle.Text = "Transactions";

            if (myConn.State == ConnectionState.Open)
            {
                lblloadingstatus.Text = "Status: Connection is Open " + details;
            }

            //load form and display within a panel
            Tranx tranxform = new Tranx() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.formPanel.Controls.Add(tranxform);
            tranxform.Show();
        }

        private void btnMainMenu_MouseHover(object sender, EventArgs e)
        {
            this.btnMainMenu.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.homeButtonHighlighted));
        }

        private void btnMainMenu_MouseLeave(object sender, EventArgs e)
        {
            if (mainmenubuttonhighlighted == true)
            {
                this.btnMainMenu.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.homeButtonHighlighted));
            }
            else
            {
                this.btnMainMenu.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.homeButtonDefault));
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            checkButtons();

            myConn.Close();

            mainmenubuttonhighlighted = true;
            this.btnMainMenu.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.homeButtonHighlighted));

            this.formPanel.Controls.Clear();
            lblSectionTitle.Text = "Home";

            if (myConn.State == ConnectionState.Open)
            {
                lblloadingstatus.Text = "Status: Connection is Open " + details;
            }

            //load form and display within a panel
            Home dashboard = new Home() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.formPanel.Controls.Add(dashboard);
            dashboard.Show();
        }

        private void btnSettings_MouseHover(object sender, EventArgs e)
        {
            this.btnSettings.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.settingsiconhighlighted));
        }

        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            this.btnSettings.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.settingsicon));
        }

        private void MainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MainMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            
                this.Update();
            }
        }

        private void MainMenu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
