namespace DVLD_My_Solution
{
    partial class International_Licenses_Applicatoins
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
            this.tbxFilterItem = new System.Windows.Forms.TextBox();
            this.cbxFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvApplicationList = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showPerosnLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxFilterItem
            // 
            this.tbxFilterItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxFilterItem.Location = new System.Drawing.Point(219, 246);
            this.tbxFilterItem.Name = "tbxFilterItem";
            this.tbxFilterItem.Size = new System.Drawing.Size(173, 20);
            this.tbxFilterItem.TabIndex = 33;
            this.tbxFilterItem.TextChanged += new System.EventHandler(this.tbxFilterItem_TextChanged);
            // 
            // cbxFilterBy
            // 
            this.cbxFilterBy.FormattingEnabled = true;
            this.cbxFilterBy.Items.AddRange(new object[] {
            "Filter By",
            "Int.LID",
            "DriverID",
            "L.LicenseID"});
            this.cbxFilterBy.Location = new System.Drawing.Point(12, 246);
            this.cbxFilterBy.Name = "cbxFilterBy";
            this.cbxFilterBy.Size = new System.Drawing.Size(196, 21);
            this.cbxFilterBy.TabIndex = 32;
            this.cbxFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbxFilterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-38, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Filter By : ";
            // 
            // dgvApplicationList
            // 
            this.dgvApplicationList.AllowUserToAddRows = false;
            this.dgvApplicationList.AllowUserToDeleteRows = false;
            this.dgvApplicationList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvApplicationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvApplicationList.Location = new System.Drawing.Point(11, 273);
            this.dgvApplicationList.Name = "dgvApplicationList";
            this.dgvApplicationList.ReadOnly = true;
            this.dgvApplicationList.Size = new System.Drawing.Size(877, 267);
            this.dgvApplicationList.TabIndex = 29;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(808, 551);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 33);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(86, 556);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(43, 13);
            this.lblRecords.TabIndex = 26;
            this.lblRecords.Text = "[????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 556);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "#Records : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(176, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(511, 31);
            this.label1.TabIndex = 23;
            this.label1.Text = "International Driving License Applications";
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.Image = global::DVLD_My_Solution.Properties.Resources.add;
            this.btnAddNewApplication.Location = new System.Drawing.Point(807, 209);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(75, 58);
            this.btnAddNewApplication.TabIndex = 30;
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_My_Solution.Properties.Resources.cross;
            this.pictureBox3.Location = new System.Drawing.Point(812, 555);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_My_Solution.Properties.Resources.papers;
            this.pictureBox1.Location = new System.Drawing.Point(344, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.showLicenseDetailsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showPerosnLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(226, 104);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_My_Solution.Properties.Resources.id__3_;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(222, 6);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::DVLD_My_Solution.Properties.Resources.id_5;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(222, 6);
            // 
            // showPerosnLicenseHistoryToolStripMenuItem
            // 
            this.showPerosnLicenseHistoryToolStripMenuItem.Image = global::DVLD_My_Solution.Properties.Resources.IssueDrivingLicense_321;
            this.showPerosnLicenseHistoryToolStripMenuItem.Name = "showPerosnLicenseHistoryToolStripMenuItem";
            this.showPerosnLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.showPerosnLicenseHistoryToolStripMenuItem.Text = "Show Perosn License History";
            this.showPerosnLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPerosnLicenseHistoryToolStripMenuItem_Click);
            // 
            // International_Licenses_Applicatoins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 595);
            this.Controls.Add(this.tbxFilterItem);
            this.Controls.Add(this.cbxFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.dgvApplicationList);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "International_Licenses_Applicatoins";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "International_Licenses_Applicatoins";
            this.Load += new System.EventHandler(this.International_Licenses_Applicatoins_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxFilterItem;
        private System.Windows.Forms.ComboBox cbxFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.DataGridView dgvApplicationList;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showPerosnLicenseHistoryToolStripMenuItem;
    }
}