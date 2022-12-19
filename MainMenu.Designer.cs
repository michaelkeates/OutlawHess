
namespace OutlawHess
{
    partial class MainMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.lblSectionTitle = new System.Windows.Forms.Label();
            this.sidemenuPanel = new System.Windows.Forms.Panel();
            this.lblissues = new System.Windows.Forms.Label();
            this.picISA = new System.Windows.Forms.PictureBox();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnTranx = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.connectionStatus = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblloadingstatus = new System.Windows.Forms.Label();
            this.formPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.sidemenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picISA)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionStatus)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSectionTitle
            // 
            this.lblSectionTitle.AutoSize = true;
            this.lblSectionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSectionTitle.Location = new System.Drawing.Point(191, 35);
            this.lblSectionTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSectionTitle.Name = "lblSectionTitle";
            this.lblSectionTitle.Size = new System.Drawing.Size(121, 44);
            this.lblSectionTitle.TabIndex = 15;
            this.lblSectionTitle.Text = "Home";
            // 
            // sidemenuPanel
            // 
            this.sidemenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sidemenuPanel.Controls.Add(this.lblissues);
            this.sidemenuPanel.Controls.Add(this.picISA);
            this.sidemenuPanel.Controls.Add(this.btnMainMenu);
            this.sidemenuPanel.Controls.Add(this.btnTranx);
            this.sidemenuPanel.Controls.Add(this.btnProducts);
            this.sidemenuPanel.Controls.Add(this.btnAccounts);
            this.sidemenuPanel.Controls.Add(this.btnCustomers);
            this.sidemenuPanel.Location = new System.Drawing.Point(1, -2);
            this.sidemenuPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sidemenuPanel.Name = "sidemenuPanel";
            this.sidemenuPanel.Size = new System.Drawing.Size(184, 603);
            this.sidemenuPanel.TabIndex = 18;
            // 
            // lblissues
            // 
            this.lblissues.AutoSize = true;
            this.lblissues.BackColor = System.Drawing.Color.Red;
            this.lblissues.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblissues.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblissues.Location = new System.Drawing.Point(146, 316);
            this.lblissues.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblissues.Name = "lblissues";
            this.lblissues.Size = new System.Drawing.Size(16, 17);
            this.lblissues.TabIndex = 26;
            this.lblissues.Text = "0";
            // 
            // picISA
            // 
            this.picISA.Image = global::OutlawHess.Properties.Resources.notificationbackground;
            this.picISA.Location = new System.Drawing.Point(141, 312);
            this.picISA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picISA.Name = "picISA";
            this.picISA.Size = new System.Drawing.Size(25, 25);
            this.picISA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picISA.TabIndex = 0;
            this.picISA.TabStop = false;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMainMenu.BackgroundImage = global::OutlawHess.Properties.Resources.homeButtonHighlighted;
            this.btnMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMainMenu.Location = new System.Drawing.Point(2, 122);
            this.btnMainMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(184, 56);
            this.btnMainMenu.TabIndex = 25;
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            this.btnMainMenu.MouseLeave += new System.EventHandler(this.btnMainMenu_MouseLeave);
            this.btnMainMenu.MouseHover += new System.EventHandler(this.btnMainMenu_MouseHover);
            // 
            // btnTranx
            // 
            this.btnTranx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTranx.BackgroundImage = global::OutlawHess.Properties.Resources.tranxButtonDefault;
            this.btnTranx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTranx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTranx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTranx.Location = new System.Drawing.Point(2, 356);
            this.btnTranx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTranx.Name = "btnTranx";
            this.btnTranx.Size = new System.Drawing.Size(184, 56);
            this.btnTranx.TabIndex = 24;
            this.btnTranx.UseVisualStyleBackColor = false;
            this.btnTranx.Click += new System.EventHandler(this.btnTranx_Click);
            this.btnTranx.MouseLeave += new System.EventHandler(this.btnTranx_MouseLeave);
            this.btnTranx.MouseHover += new System.EventHandler(this.btnTranx_MouseHover);
            // 
            // btnProducts
            // 
            this.btnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProducts.BackgroundImage = global::OutlawHess.Properties.Resources.productsButtonDefault;
            this.btnProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProducts.Location = new System.Drawing.Point(2, 297);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(184, 56);
            this.btnProducts.TabIndex = 23;
            this.btnProducts.UseVisualStyleBackColor = false;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            this.btnProducts.MouseLeave += new System.EventHandler(this.btnProducts_MouseLeave);
            this.btnProducts.MouseHover += new System.EventHandler(this.btnProducts_MouseHover);
            // 
            // btnAccounts
            // 
            this.btnAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAccounts.BackgroundImage = global::OutlawHess.Properties.Resources.accountButtonDefault;
            this.btnAccounts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccounts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAccounts.Location = new System.Drawing.Point(2, 238);
            this.btnAccounts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(184, 56);
            this.btnAccounts.TabIndex = 22;
            this.btnAccounts.UseVisualStyleBackColor = false;
            this.btnAccounts.Click += new System.EventHandler(this.btnAccounts_Click);
            this.btnAccounts.MouseLeave += new System.EventHandler(this.btnAccounts_MouseLeave);
            this.btnAccounts.MouseHover += new System.EventHandler(this.btnAccounts_MouseHover);
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCustomers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCustomers.BackgroundImage")));
            this.btnCustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCustomers.Location = new System.Drawing.Point(2, 180);
            this.btnCustomers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(184, 56);
            this.btnCustomers.TabIndex = 21;
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            this.btnCustomers.MouseLeave += new System.EventHandler(this.btnCustomers_MouseLeave);
            this.btnCustomers.MouseHover += new System.EventHandler(this.btnCustomers_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(183, 541);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 41);
            this.panel1.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.9992F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0008F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.connectionStatus, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSettings, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTime, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblloadingstatus, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(650, 22);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // connectionStatus
            // 
            this.connectionStatus.Image = global::OutlawHess.Properties.Resources.connectionopenicon;
            this.connectionStatus.Location = new System.Drawing.Point(2, 6);
            this.connectionStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(14, 14);
            this.connectionStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.connectionStatus.TabIndex = 0;
            this.connectionStatus.TabStop = false;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSettings.BackgroundImage = global::OutlawHess.Properties.Resources.settingsicon;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSettings.Location = new System.Drawing.Point(634, 6);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(14, 14);
            this.btnSettings.TabIndex = 26;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.MouseLeave += new System.EventHandler(this.btnSettings_MouseLeave);
            this.btnSettings.MouseHover += new System.EventHandler(this.btnSettings_MouseHover);
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Gray;
            this.lblTime.Location = new System.Drawing.Point(388, 4);
            this.lblTime.Name = "lblTime";
            this.lblTime.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTime.Size = new System.Drawing.Size(163, 17);
            this.lblTime.TabIndex = 22;
            this.lblTime.Text = "time";
            // 
            // lblloadingstatus
            // 
            this.lblloadingstatus.BackColor = System.Drawing.Color.Transparent;
            this.lblloadingstatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblloadingstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblloadingstatus.ForeColor = System.Drawing.Color.Gray;
            this.lblloadingstatus.Location = new System.Drawing.Point(21, 4);
            this.lblloadingstatus.Name = "lblloadingstatus";
            this.lblloadingstatus.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblloadingstatus.Size = new System.Drawing.Size(361, 18);
            this.lblloadingstatus.TabIndex = 21;
            this.lblloadingstatus.Text = "loading status";
            // 
            // formPanel
            // 
            this.formPanel.Location = new System.Drawing.Point(2, 2);
            this.formPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(642, 439);
            this.formPanel.TabIndex = 21;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMinimize.AutoSize = true;
            this.btnMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.BackgroundImage")));
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnMinimize.Location = new System.Drawing.Point(3, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(23, 20);
            this.btnMinimize.TabIndex = 17;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            this.btnMinimize.MouseLeave += new System.EventHandler(this.btnMinimize_MouseLeave);
            this.btnMinimize.MouseHover += new System.EventHandler(this.btnMinimize_MouseHover);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.AutoSize = true;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnClose.Location = new System.Drawing.Point(33, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 20);
            this.btnClose.TabIndex = 16;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnMinimize, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClose, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(784, 6);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(60, 28);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.formPanel, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(198, 93);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(646, 443);
            this.tableLayoutPanel3.TabIndex = 22;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(850, 573);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.sidemenuPanel);
            this.Controls.Add(this.lblSectionTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "g";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainMenu_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainMenu_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainMenu_MouseUp);
            this.sidemenuPanel.ResumeLayout(false);
            this.sidemenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picISA)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connectionStatus)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel sidemenuPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnTranx;
        private System.Windows.Forms.Button btnMainMenu;
        public System.Windows.Forms.Label lblloadingstatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.PictureBox connectionStatus;
        public System.Windows.Forms.Panel formPanel;
        public System.Windows.Forms.Label lblSectionTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblissues;
        private System.Windows.Forms.PictureBox picISA;
    }
}