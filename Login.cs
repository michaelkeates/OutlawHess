using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlawHess
{
    public partial class Login : Form
    {
        //Hack to enable drop shadow
        private const int CS_DROPSHADOW = 0x00020000;

        //Buttons. Is button highlighted or not?
        bool continuebuttonhighlighted = false;
        bool cancelbuttonhighlighted = false;

        public Login()
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

        private void checkButtons()
        {
            //Check if any buttons have been clicked. If button is clicked, other buttons won't be 'highlighted' and only
            //clicked button is highlighted

            if (continuebuttonhighlighted == true)
            {
                continuebuttonhighlighted = false;
                this.btnContinue.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_continue_default));
            }

            if (cancelbuttonhighlighted == true)
            {
                cancelbuttonhighlighted = false;
                this.btnCancel.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_cancel_default));
            }
        }

        private void checkAuthorisation()
        {
            //lets check to see if the login credentials is correct by retreiving values from text boxes. if not correct show error message
            if (txtAccountNumber.Text.Trim() == "" && txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Empty Fields", "Error");
            }
            else
            {
                //make connection to admin.db
                string query = "SELECT * FROM Manager WHERE accountnumber= @acno AND password = @pass";
                SQLiteConnection conn = new SQLiteConnection("Data Source=db/admin.db;Version=3;");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                //parse data from text boxes to compare with values in database
                cmd.Parameters.AddWithValue("@acno", txtAccountNumber.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //MainMenu f2 = new MainMenu();
                    //f2.Show();
                    //this.Hide();
                    //LoadingScreen.loginSuccess = true;
                    //LoadingScreen.loadingbartimer.Start();
                    Properties.Settings.Default.loginSuccess = true;
                    Properties.Settings.Default.Save();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
        }

        private void btnContinue_MouseHover(object sender, EventArgs e)
        {
            this.btnContinue.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_continue_highlighted));
        }

        private void btnContinue_MouseLeave(object sender, EventArgs e)
        {
            if (continuebuttonhighlighted == true)
            {
                this.btnContinue.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_continue_highlighted));
            }
            else
            {
                this.btnContinue.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_continue_default));
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            checkButtons();
            checkAuthorisation();

            continuebuttonhighlighted = true;
            this.btnContinue.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_continue_highlighted));
        }

        private void btnCancel_MouseHover(object sender, EventArgs e)
        {
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_cancel_highlighted));
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            if (continuebuttonhighlighted == true)
            {
                this.btnCancel.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_cancel_highlighted));
            }
            else
            {
                this.btnCancel.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.btn_cancel_default));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void txtAccountNumber_MouseDown(object sender, MouseEventArgs e)
        {
            txtAccountNumber.Text = "";
        }

        private void txtPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.Text = "";
        }
    }
}
