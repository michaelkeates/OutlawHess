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
    public partial class Product : Form
    {
        //get variables from main menu
        MainMenu f3 = new MainMenu();

        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            radioAccountNo.Checked = true;

            f3.myConn.ConnectionString = f3.connString + f3.details;

            try
            {
                f3.conn = new SQLiteConnection(f3.myConn);
                Properties.Settings.Default.connectionOpen = true;
                Properties.Settings.Default.Save();

                //check connection to see if open or not
                if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
                }

                string sql = "SELECT prodid, isaname, staus, transin, intrate FROM Product";

                f3.da_staff = new SQLiteDataAdapter(sql, f3.conn);

                f3.dt_staff.Clear();
                f3.da_staff.Fill(f3.dt_staff);

                dataGridView1.DataSource = f3.dt_staff;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7);

                dataGridView1.Columns[0].HeaderText = "ProductID";
                dataGridView1.Columns[1].HeaderText = "ISA";
                dataGridView1.Columns[2].HeaderText = "Status";
                dataGridView1.Columns[3].HeaderText = "transin";
                dataGridView1.Columns[4].HeaderText = "Interest";

                //add buttons for each row in their own column at the end of table
                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                button.Name = "Change Status";
                button.Text = "Change Status";
                button.UseColumnTextForButtonValue = true;
                button.FlatStyle = FlatStyle.Flat;
                button.DefaultCellStyle.ForeColor = Color.FromArgb(39, 39, 39);
                button.DefaultCellStyle.BackColor = Color.IndianRed;
                button.DefaultCellStyle.SelectionForeColor = Color.FromArgb(39, 39, 39);
                dataGridView1.Columns.Add(button);

                DataGridViewButtonColumn button2 = new DataGridViewButtonColumn();
                button2.Name = "Change Interest";
                button2.Text = "Change Interest";
                button2.UseColumnTextForButtonValue = true;
                button2.FlatStyle = FlatStyle.Flat;
                button2.DefaultCellStyle.ForeColor = Color.FromArgb(39, 39, 39);
                button2.DefaultCellStyle.BackColor = Color.IndianRed;
                button2.DefaultCellStyle.SelectionForeColor = Color.FromArgb(39, 39, 39);
                dataGridView1.Columns.Add(button2);
                
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("staus Like '%{0}%' AND Convert(transin, System.String) Like '%{1}%'", "open", "1");

                f3.conn.Close();
                f3.da_staff.Dispose();

                //check if connection is closed and update the products 'notification' counter by calling getISAissues method
                if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).closeConnection(sender, e);
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
                    (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).getISAissues(sender, e);
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

                string sql = "SELECT prodid, isaname, staus, transin, intrate FROM Product";

                f3.da_staff = new SQLiteDataAdapter(sql, f3.conn);

                //clear and refill table
                f3.dt_staff.Clear();
                f3.da_staff.Fill(f3.dt_staff);

                //variations of options for the two combo boxes.
                if (f3.showopenproducts == true && f3.showtransinproducts == true && f3.showallproducts == false && f3.showalltransinproducts == false)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("staus Like '%{0}%' AND Convert(transin, System.String) Like '%{1}%'", "open", "1");
                }
                else if (f3.showopenproducts == true && f3.showtransinproducts == false && f3.showallproducts == false && f3.showalltransinproducts == false)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("staus Like '%{0}%' AND Convert(transin, System.String) Like '%{1}%'", "open", "0");
                }
                else if (f3.showopenproducts == false && f3.showtransinproducts == true && f3.showallproducts == false && f3.showalltransinproducts == false)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("staus Like '%{0}%' AND Convert(transin, System.String) Like '%{1}%'", "closed", "1");
                }
                else if (f3.showopenproducts == false && f3.showtransinproducts == false && f3.showallproducts == false && f3.showalltransinproducts == false)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("staus Like '%{0}%' AND Convert(transin, System.String) Like '%{1}%'", "closed", "0");
                }
                else if (f3.showopenproducts == false && f3.showtransinproducts == false && f3.showallproducts == true && f3.showalltransinproducts == false)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("staus Like '%{0}%' AND Convert(transin, System.String) Like '%{1}%'", "", "0");
                }
                else if (f3.showopenproducts == false && f3.showtransinproducts == true && f3.showallproducts == true && f3.showalltransinproducts == false)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("staus Like '%{0}%' AND Convert(transin, System.String) Like '%{1}%'", "", "1");
                }
                else if (f3.showopenproducts == false && f3.showtransinproducts == false && f3.showallproducts == false && f3.showalltransinproducts == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("staus Like '%{0}%' AND Convert(transin, System.String) Like '%{1}%'", "closed", "");
                }
                else if (f3.showopenproducts == true && f3.showtransinproducts == false && f3.showallproducts == false && f3.showalltransinproducts == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("staus Like '%{0}%' AND Convert(transin, System.String) Like '%{1}%'", "open", "");
                }
                else if (f3.showopenproducts == false && f3.showtransinproducts == false && f3.showallproducts == true && f3.showalltransinproducts == true)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("staus Like '%{0}%' AND Convert(transin, System.String) Like '%{1}%'", "", "");
                }

                //close connection and dispose table
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
            if (e.ColumnIndex == dataGridView1.Columns["Change Status"].Index)
            {
                try
                {
                    if (e.ColumnIndex == 0)
                    {
                        // Value is given in case the cell is empty
                        string prodid = "0";
                        string isaname = "isaname";
                        string staus = "staus";
                        string confirmedStaus = "Something";


                        //is the cell not empty?
                        if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["prodid"].Value != null)
                        {
                            //fetch our needed cell values to be strings
                            prodid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["prodid"].Value.ToString();
                            isaname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["isaname"].Value.ToString();
                            staus = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["staus"].Value.ToString();

                            //check if staus is open and set variable to closed. else is open
                            if (staus == "open")
                            {
                                confirmedStaus = "closed";
                            }
                            else
                            {
                                confirmedStaus = "open";
                            }

                            if (MessageBox.Show("Would you like to change the status for Product ID: " + prodid + " (" + isaname + ") from " + staus + " to " + confirmedStaus + "?" + "\n" + "Click Yes to continue.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                                    //update status in product table
                                    cmd.CommandText = "UPDATE Product SET staus = @status WHERE prodid = @id";

                                    //value = @value
                                    cmd.Parameters.AddWithValue("@status", "" + confirmedStaus + "");
                                    cmd.Parameters.AddWithValue("@id", "" + prodid + "");

                                    int recordsChanged = cmd.ExecuteNonQuery();

                                    MessageBox.Show(recordsChanged.ToString() + " records modified");

                                    //close connection and dispose table
                                    f3.conn.Close();
                                    f3.da_staff.Dispose();

                                    //call methods from main menu
                                    //close connection and do a check
                                    //check how many isa issues are open
                                    if (System.Windows.Forms.Application.OpenForms["MainMenu"] != null)
                                    {
                                        (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).closeConnection(sender, e);
                                        (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).checkConnection(sender, e);
                                        (System.Windows.Forms.Application.OpenForms["MainMenu"] as MainMenu).getISAissues(sender, e);
                                    }

                                    //call method to update the panel with changes
                                    updatePanel();
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
            else if (e.ColumnIndex == dataGridView1.Columns["Change Interest"].Index)
            {
                //MessageBox.Show("test");

                try
                {
                    if (e.ColumnIndex == 1)
                    {
                        // Value is given in case the cell is empty
                        string prodid = "0";
                        string isaname = "isaname";
                        string staus = "staus";
                        string intrate = "0";

                        //is the cell not empty?
                        if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["prodid"].Value != null)
                        {
                            //fetch our needed cell values to be strings
                            prodid = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["prodid"].Value.ToString();
                            isaname = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["isaname"].Value.ToString();
                            staus = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["staus"].Value.ToString();
                            intrate = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["intrate"].Value.ToString();

                            //Set and save selected customer into the protperites
                            Properties.Settings.Default.currentInterestRate = intrate;
                            Properties.Settings.Default.currentProductID = prodid;
                            Properties.Settings.Default.Save();

                            new Product_Interest().ShowDialog();
                            updatePanel();
                        }
                            else
                            {
                                //Nothing
                            }
                        //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Show all
            if (cmbStatus.SelectedIndex == 2)
            {
                f3.showopenproducts = false;
                f3.showallproducts = true;
                f3.dt_staff.Clear();
                updatePanel();
            }
            //Closed
            if (cmbStatus.SelectedIndex == 1)
            {
                f3.showopenproducts = false;
                f3.showallproducts = false;
                f3.dt_staff.Clear();
                updatePanel();
            }
            //Open
            if (cmbStatus.SelectedIndex == 0)
            {
                f3.showopenproducts = true;
                f3.showallproducts = false;
                f3.dt_staff.Clear();
                updatePanel();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (radioAccountNo.Checked == true)
            {
                //Have to convert to string otherwise we get error as custid is a int64
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(prodid, System.String) LIKE '{0}%'", txtSearch.Text);
            }
            if (radioFirstName.Checked == true)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("isaname LIKE '{0}%'", txtSearch.Text);
            }
        }

        private void txtSearch_MouseDown(object sender, MouseEventArgs e)
        {
            txtSearch.Text = "";
        }
        private void cmbTransin_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Show all
            if (cmbTransin.SelectedIndex == 2)
            {
                f3.showtransinproducts = false;
                f3.showalltransinproducts = true;
                f3.dt_staff.Clear();
                updatePanel();
            }
            //Non-Trasnfereble
            if (cmbTransin.SelectedIndex == 1)
            {
                f3.showtransinproducts = false;
                f3.showalltransinproducts = false;
                f3.dt_staff.Clear();
                updatePanel();
            }
            //Transfereble
            if (cmbTransin.SelectedIndex == 0)
            {
                f3.showtransinproducts = true;
                f3.showalltransinproducts = false;
                f3.dt_staff.Clear();
                updatePanel();
            }
        }
    }
}
