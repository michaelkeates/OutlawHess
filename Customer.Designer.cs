
namespace OutlawHess
{
    partial class Customer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.radioTitle = new System.Windows.Forms.RadioButton();
            this.radioFirstName = new System.Windows.Forms.RadioButton();
            this.radioLastName = new System.Windows.Forms.RadioButton();
            this.radioNicode = new System.Windows.Forms.RadioButton();
            this.radioAccountNo = new System.Windows.Forms.RadioButton();
            this.radioDOB = new System.Windows.Forms.RadioButton();
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.Location = new System.Drawing.Point(12, 100);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1326, 836);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(11, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(214, 50);
            this.txtSearch.TabIndex = 24;
            this.txtSearch.Text = "Search Customers";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseDown);
            // 
            // radioTitle
            // 
            this.radioTitle.AutoSize = true;
            this.radioTitle.ForeColor = System.Drawing.Color.Gray;
            this.radioTitle.Location = new System.Drawing.Point(425, 22);
            this.radioTitle.Margin = new System.Windows.Forms.Padding(4);
            this.radioTitle.Name = "radioTitle";
            this.radioTitle.Size = new System.Drawing.Size(84, 29);
            this.radioTitle.TabIndex = 29;
            this.radioTitle.TabStop = true;
            this.radioTitle.Text = "Title";
            this.radioTitle.UseVisualStyleBackColor = true;
            // 
            // radioFirstName
            // 
            this.radioFirstName.AutoSize = true;
            this.radioFirstName.ForeColor = System.Drawing.Color.Gray;
            this.radioFirstName.Location = new System.Drawing.Point(515, 22);
            this.radioFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.radioFirstName.Name = "radioFirstName";
            this.radioFirstName.Size = new System.Drawing.Size(147, 29);
            this.radioFirstName.TabIndex = 30;
            this.radioFirstName.TabStop = true;
            this.radioFirstName.Text = "First Name";
            this.radioFirstName.UseVisualStyleBackColor = true;
            // 
            // radioLastName
            // 
            this.radioLastName.AutoSize = true;
            this.radioLastName.ForeColor = System.Drawing.Color.Gray;
            this.radioLastName.Location = new System.Drawing.Point(667, 22);
            this.radioLastName.Margin = new System.Windows.Forms.Padding(4);
            this.radioLastName.Name = "radioLastName";
            this.radioLastName.Size = new System.Drawing.Size(146, 29);
            this.radioLastName.TabIndex = 31;
            this.radioLastName.TabStop = true;
            this.radioLastName.Text = "Last Name";
            this.radioLastName.UseVisualStyleBackColor = true;
            // 
            // radioNicode
            // 
            this.radioNicode.AutoSize = true;
            this.radioNicode.ForeColor = System.Drawing.Color.Gray;
            this.radioNicode.Location = new System.Drawing.Point(987, 22);
            this.radioNicode.Margin = new System.Windows.Forms.Padding(4);
            this.radioNicode.Name = "radioNicode";
            this.radioNicode.Size = new System.Drawing.Size(110, 29);
            this.radioNicode.TabIndex = 32;
            this.radioNicode.TabStop = true;
            this.radioNicode.Text = "Nicode";
            this.radioNicode.UseVisualStyleBackColor = true;
            // 
            // radioAccountNo
            // 
            this.radioAccountNo.AutoSize = true;
            this.radioAccountNo.ForeColor = System.Drawing.Color.Gray;
            this.radioAccountNo.Location = new System.Drawing.Point(259, 22);
            this.radioAccountNo.Margin = new System.Windows.Forms.Padding(4);
            this.radioAccountNo.Name = "radioAccountNo";
            this.radioAccountNo.Size = new System.Drawing.Size(148, 29);
            this.radioAccountNo.TabIndex = 34;
            this.radioAccountNo.TabStop = true;
            this.radioAccountNo.Text = "AccountNo";
            this.radioAccountNo.UseVisualStyleBackColor = true;
            // 
            // radioDOB
            // 
            this.radioDOB.AutoSize = true;
            this.radioDOB.ForeColor = System.Drawing.Color.Gray;
            this.radioDOB.Location = new System.Drawing.Point(819, 22);
            this.radioDOB.Margin = new System.Windows.Forms.Padding(4);
            this.radioDOB.Name = "radioDOB";
            this.radioDOB.Size = new System.Drawing.Size(162, 29);
            this.radioDOB.TabIndex = 35;
            this.radioDOB.TabStop = true;
            this.radioDOB.Text = "Date of Birth";
            this.radioDOB.UseVisualStyleBackColor = true;
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1352, 960);
            this.Controls.Add(this.radioDOB);
            this.Controls.Add(this.radioAccountNo);
            this.Controls.Add(this.radioNicode);
            this.Controls.Add(this.radioLastName);
            this.Controls.Add(this.radioFirstName);
            this.Controls.Add(this.radioTitle);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton radioTitle;
        private System.Windows.Forms.RadioButton radioFirstName;
        private System.Windows.Forms.RadioButton radioLastName;
        private System.Windows.Forms.RadioButton radioNicode;
        private System.Windows.Forms.RadioButton radioAccountNo;
        private System.Windows.Forms.RadioButton radioDOB;
    }
}