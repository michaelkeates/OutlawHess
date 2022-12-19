
namespace OutlawHess
{
    partial class Customer_Accounts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnCalcaccured = new System.Windows.Forms.Button();
            this.radioAccountNo = new System.Windows.Forms.RadioButton();
            this.radioLastName = new System.Windows.Forms.RadioButton();
            this.radioFirstName = new System.Windows.Forms.RadioButton();
            this.cmbActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.Location = new System.Drawing.Point(24, 156);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1300, 544);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(24, 82);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(214, 50);
            this.txtSearch.TabIndex = 25;
            this.txtSearch.Text = "Search AccountID";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseDown);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCustomerName.Location = new System.Drawing.Point(12, 8);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(271, 61);
            this.lblCustomerName.TabIndex = 26;
            this.lblCustomerName.Text = "Customer:";
            // 
            // btnCalcaccured
            // 
            this.btnCalcaccured.BackColor = System.Drawing.Color.IndianRed;
            this.btnCalcaccured.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcaccured.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnCalcaccured.Location = new System.Drawing.Point(24, 718);
            this.btnCalcaccured.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalcaccured.Name = "btnCalcaccured";
            this.btnCalcaccured.Size = new System.Drawing.Size(384, 68);
            this.btnCalcaccured.TabIndex = 27;
            this.btnCalcaccured.Text = "Calculate Overnight Calculation";
            this.btnCalcaccured.UseVisualStyleBackColor = false;
            this.btnCalcaccured.Click += new System.EventHandler(this.btnCalcaccured_Click);
            // 
            // radioAccountNo
            // 
            this.radioAccountNo.AutoSize = true;
            this.radioAccountNo.ForeColor = System.Drawing.Color.Gray;
            this.radioAccountNo.Location = new System.Drawing.Point(444, 90);
            this.radioAccountNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioAccountNo.Name = "radioAccountNo";
            this.radioAccountNo.Size = new System.Drawing.Size(148, 29);
            this.radioAccountNo.TabIndex = 43;
            this.radioAccountNo.TabStop = true;
            this.radioAccountNo.Text = "AccountNo";
            this.radioAccountNo.UseVisualStyleBackColor = true;
            // 
            // radioLastName
            // 
            this.radioLastName.AutoSize = true;
            this.radioLastName.ForeColor = System.Drawing.Color.Gray;
            this.radioLastName.Location = new System.Drawing.Point(766, 90);
            this.radioLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioLastName.Name = "radioLastName";
            this.radioLastName.Size = new System.Drawing.Size(146, 29);
            this.radioLastName.TabIndex = 42;
            this.radioLastName.TabStop = true;
            this.radioLastName.Text = "Last Name";
            this.radioLastName.UseVisualStyleBackColor = true;
            // 
            // radioFirstName
            // 
            this.radioFirstName.AutoSize = true;
            this.radioFirstName.ForeColor = System.Drawing.Color.Gray;
            this.radioFirstName.Location = new System.Drawing.Point(612, 90);
            this.radioFirstName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioFirstName.Name = "radioFirstName";
            this.radioFirstName.Size = new System.Drawing.Size(147, 29);
            this.radioFirstName.TabIndex = 41;
            this.radioFirstName.TabStop = true;
            this.radioFirstName.Text = "First Name";
            this.radioFirstName.UseVisualStyleBackColor = true;
            // 
            // cmbActive
            // 
            this.cmbActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.cmbActive.DropDownWidth = 131;
            this.cmbActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbActive.ForeColor = System.Drawing.Color.DimGray;
            this.cmbActive.FormattingEnabled = true;
            this.cmbActive.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            "Show All"});
            this.cmbActive.Location = new System.Drawing.Point(278, 90);
            this.cmbActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbActive.Name = "cmbActive";
            this.cmbActive.Size = new System.Drawing.Size(132, 33);
            this.cmbActive.TabIndex = 40;
            this.cmbActive.Text = "Active";
            this.cmbActive.SelectedIndexChanged += new System.EventHandler(this.cmbActive_SelectedIndexChanged);
            // 
            // Customer_Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1352, 960);
            this.Controls.Add(this.radioAccountNo);
            this.Controls.Add(this.radioLastName);
            this.Controls.Add(this.radioFirstName);
            this.Controls.Add(this.cmbActive);
            this.Controls.Add(this.btnCalcaccured);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Customer_Accounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "//";
            this.Load += new System.EventHandler(this.Customer_Accounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Button btnCalcaccured;
        private System.Windows.Forms.RadioButton radioAccountNo;
        private System.Windows.Forms.RadioButton radioLastName;
        private System.Windows.Forms.RadioButton radioFirstName;
        private System.Windows.Forms.ComboBox cmbActive;
    }
}