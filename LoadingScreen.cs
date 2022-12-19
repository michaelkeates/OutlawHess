using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
//using System.IO;
//using System.IO.Compression;
//Ionic nuget plugin allows the encryption of files to zip and extraction
using Ionic.Zip;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OutlawHess
{
    public partial class LoadingScreen : Form
    {
        //Hack to enable drop shadow
        private const int CS_DROPSHADOW = 0x00020000;

        //Creates the connection object between C# and SQLite database
        SQLiteConnection myConn = new SQLiteConnection();

        public LoadingScreen()
        {
            InitializeComponent();
            LoadingStatus();

            //Make sure loginSuccess is reset to false to prompt login form
            //save it into property settings
            Properties.Settings.Default.loginSuccess = false;
            Properties.Settings.Default.Save();
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

        private void LoadingStatus()
        {
            //alert user with changing label to display information
            pictureBox1.Controls.Add(lblloadingstatus);
            lblloadingstatus.BackColor = Color.Transparent;

            lblloadingstatus.Text = ("IS2S555 Programming 2 Assignment 2 - Michael Keates (23009273)");
        }

        private void loadingbartimer_Tick(object sender, EventArgs e)
        {
            //loading bar which is a gimick but does check to see if .db file exists, if not it is extracted from the .bin file
            //increase loading bar using timer ticks

            //Connect to database
            string Details = @"db/dogbytes.db";
            myConn.ConnectionString = @"Data source = " + Details;

            panel2.Width += 3;
            if (panel2.Width >= 700)
            {
                //finally when loading bar is at end. stop timer and open main menu
                loadingbartimer.Stop();
                MainMenu f3 = new MainMenu();
                f3.Show();
                this.Hide();

                if (myConn.State == ConnectionState.Open)
                {
                    MainMenu f2 = new MainMenu();
                    f2.Show();
                    this.Hide();
                    lblloadingstatus.Text = "Connection is Open ";
                }
            }
            if (panel2.Width >= 350 && Properties.Settings.Default.loginSuccess == false)
            {
                //implemented login screen. must input correct details to continue
                //login details to continue to main menu
                //user = 12345678
                //password = 12345678
                loadingbartimer.Stop();
                new Login().ShowDialog();
                lblloadingstatus.Text = "Login with your credentials ";
                loadingbartimer.Start();
            }
            if (panel2.Width >= 355)
            {
                lblloadingstatus.Text = "Database decrypted";
            }
            if (panel2.Width >= 360)
            {
                lblloadingstatus.Text = "Decompressing encrypted file";

                //decompressing encrypted zip file that is password protected
                //db file will be extracted
                if (!File.Exists(@"db/dogbytes.db"))
                {
                    ZipFile zip = ZipFile.Read(@"db/dogbytes.bin");
                    Directory.CreateDirectory(@"db");
                    foreach (ZipEntry f in zip)
                    {
                        // check if you want to extract e or not
                        if (f.FileName == "dogbytes.db")
                            f.Password = "12345678";
                        //encryptiong used
                        f.Encryption = EncryptionAlgorithm.WinZipAes256;
                        f.Extract(@"db", ExtractExistingFileAction.OverwriteSilently);
                        //f.Extract(@"db");
                    }
                }
                else
                {
                    //do nothing
                }
            }
            if (panel2.Width >= 365)
            {
                lblloadingstatus.Text = "You have succesfully logged in ";
            }
        }
    }
}
