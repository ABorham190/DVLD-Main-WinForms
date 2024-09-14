namespace DVLD_My_Solution
{
    partial class FindLicenseByLID
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxLicenseID = new System.Windows.Forms.TextBox();
            this.driverLicenseInfoUsingLID1 = new DVLD_My_Solution.DriverLicenseInfoUsingLID();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFindLicense);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxLicenseID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindLicense.Image = global::DVLD_My_Solution.Properties.Resources.Driver_License_48;
            this.btnFindLicense.Location = new System.Drawing.Point(355, 15);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(56, 39);
            this.btnFindLicense.TabIndex = 2;
            this.btnFindLicense.UseVisualStyleBackColor = true;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "LicenseID : ";
            // 
            // tbxLicenseID
            // 
            this.tbxLicenseID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxLicenseID.Location = new System.Drawing.Point(118, 25);
            this.tbxLicenseID.Name = "tbxLicenseID";
            this.tbxLicenseID.Size = new System.Drawing.Size(217, 20);
            this.tbxLicenseID.TabIndex = 0;
            // 
            // driverLicenseInfoUsingLID1
            // 
            this.driverLicenseInfoUsingLID1.Location = new System.Drawing.Point(0, 73);
            this.driverLicenseInfoUsingLID1.Name = "driverLicenseInfoUsingLID1";
            this.driverLicenseInfoUsingLID1.Size = new System.Drawing.Size(645, 242);
            this.driverLicenseInfoUsingLID1.TabIndex = 2;
            // 
            // FindLicenseByLID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.driverLicenseInfoUsingLID1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FindLicenseByLID";
            this.Size = new System.Drawing.Size(648, 320);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFindLicense;
        private DriverLicenseInfoUsingLID driverLicenseInfoUsingLID1;
        internal System.Windows.Forms.TextBox tbxLicenseID;
        protected internal System.Windows.Forms.GroupBox groupBox1;
    }
}
