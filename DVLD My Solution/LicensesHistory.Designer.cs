namespace DVLD_My_Solution
{
    partial class LicensesHistory
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
            this.tbcInternationalLicenses = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvInternationlLicenses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.tbcInternationalLicenses.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationlLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcInternationalLicenses
            // 
            this.tbcInternationalLicenses.Controls.Add(this.tabPage1);
            this.tbcInternationalLicenses.Controls.Add(this.tabPage2);
            this.tbcInternationalLicenses.Location = new System.Drawing.Point(3, 3);
            this.tbcInternationalLicenses.Name = "tbcInternationalLicenses";
            this.tbcInternationalLicenses.SelectedIndex = 0;
            this.tbcInternationalLicenses.Size = new System.Drawing.Size(736, 231);
            this.tbcInternationalLicenses.TabIndex = 0;
            this.tbcInternationalLicenses.SelectedIndexChanged += new System.EventHandler(this.tbcInternationalLicenses_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvLocalLicenses);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(728, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local Licenses";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(10, 7);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(712, 191);
            this.dgvLocalLicenses.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvInternationlLicenses);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International Licenses";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvInternationlLicenses
            // 
            this.dgvInternationlLicenses.AllowUserToAddRows = false;
            this.dgvInternationlLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationlLicenses.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvInternationlLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationlLicenses.Location = new System.Drawing.Point(4, 7);
            this.dgvInternationlLicenses.Name = "dgvInternationlLicenses";
            this.dgvInternationlLicenses.ReadOnly = true;
            this.dgvInternationlLicenses.Size = new System.Drawing.Size(722, 191);
            this.dgvInternationlLicenses.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Records # : ";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(75, 242);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(43, 13);
            this.lblRecords.TabIndex = 2;
            this.lblRecords.Text = "[????]";
            // 
            // LicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbcInternationalLicenses);
            this.Name = "LicensesHistory";
            this.Size = new System.Drawing.Size(756, 273);
            this.tbcInternationalLicenses.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationlLicenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbcInternationalLicenses;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.DataGridView dgvInternationlLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecords;
    }
}
