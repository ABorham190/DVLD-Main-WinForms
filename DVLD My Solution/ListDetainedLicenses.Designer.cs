namespace DVLD_My_Solution
{
    partial class ListDetainedLicenses
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
            this.dgvDetainedLicenseList = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReleaseLicense = new System.Windows.Forms.Button();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cbxFilterByReleaseOptions = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenseList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxFilterItem
            // 
            this.tbxFilterItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxFilterItem.Location = new System.Drawing.Point(278, 225);
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
            "Detain ID",
            "IsReleased",
            "National Number",
            "Full Name",
            "Release AppID"});
            this.cbxFilterBy.Location = new System.Drawing.Point(71, 225);
            this.cbxFilterBy.Name = "cbxFilterBy";
            this.cbxFilterBy.Size = new System.Drawing.Size(196, 21);
            this.cbxFilterBy.TabIndex = 32;
            this.cbxFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbxFilterBy_SelectedIndexChanged);
            this.cbxFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxFilterBy_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Filter By : ";
            // 
            // dgvDetainedLicenseList
            // 
            this.dgvDetainedLicenseList.AllowUserToAddRows = false;
            this.dgvDetainedLicenseList.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenseList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDetainedLicenseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicenseList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDetainedLicenseList.Location = new System.Drawing.Point(12, 252);
            this.dgvDetainedLicenseList.Name = "dgvDetainedLicenseList";
            this.dgvDetainedLicenseList.ReadOnly = true;
            this.dgvDetainedLicenseList.Size = new System.Drawing.Size(990, 267);
            this.dgvDetainedLicenseList.TabIndex = 29;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(919, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 41);
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
            this.lblRecords.Location = new System.Drawing.Point(115, 563);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(43, 13);
            this.lblRecords.TabIndex = 26;
            this.lblRecords.Text = "[????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 563);
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
            this.label1.Location = new System.Drawing.Point(398, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 31);
            this.label1.TabIndex = 23;
            this.label1.Text = "Detained Licenses List";
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReleaseLicense.Image = global::DVLD_My_Solution.Properties.Resources.Release_Detained_License_321;
            this.btnReleaseLicense.Location = new System.Drawing.Point(847, 188);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(75, 58);
            this.btnReleaseLicense.TabIndex = 34;
            this.btnReleaseLicense.UseVisualStyleBackColor = true;
            this.btnReleaseLicense.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetainLicense.Image = global::DVLD_My_Solution.Properties.Resources.Detain_32;
            this.btnDetainLicense.Location = new System.Drawing.Point(927, 188);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(75, 58);
            this.btnDetainLicense.TabIndex = 30;
            this.btnDetainLicense.UseVisualStyleBackColor = true;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_My_Solution.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(462, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_My_Solution.Properties.Resources.cross;
            this.pictureBox3.Location = new System.Drawing.Point(926, 553);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            // 
            // cbxFilterByReleaseOptions
            // 
            this.cbxFilterByReleaseOptions.FormattingEnabled = true;
            this.cbxFilterByReleaseOptions.Items.AddRange(new object[] {
            "All",
            "Released",
            "Non Released"});
            this.cbxFilterByReleaseOptions.Location = new System.Drawing.Point(278, 225);
            this.cbxFilterByReleaseOptions.Name = "cbxFilterByReleaseOptions";
            this.cbxFilterByReleaseOptions.Size = new System.Drawing.Size(173, 21);
            this.cbxFilterByReleaseOptions.TabIndex = 35;
            this.cbxFilterByReleaseOptions.SelectedIndexChanged += new System.EventHandler(this.cbxFilterByReleaseOptions_SelectedIndexChanged);
            this.cbxFilterByReleaseOptions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbxFilterByReleaseOptions_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(226, 120);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(222, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 22);
            this.toolStripMenuItem1.Text = "Show Person Details";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(225, 22);
            this.toolStripMenuItem2.Text = "Show Person License History";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(225, 22);
            this.toolStripMenuItem3.Text = "Show License Details";
            // 
            // ListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 599);
            this.Controls.Add(this.cbxFilterByReleaseOptions);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.tbxFilterItem);
            this.Controls.Add(this.cbxFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.dgvDetainedLicenseList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ListDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ListDetainedLicense";
            this.Load += new System.EventHandler(this.ListDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenseList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxFilterItem;
        private System.Windows.Forms.ComboBox cbxFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dgvDetainedLicenseList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReleaseLicense;
        private System.Windows.Forms.ComboBox cbxFilterByReleaseOptions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}