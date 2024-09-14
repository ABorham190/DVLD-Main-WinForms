namespace DVLD_My_Solution
{
    partial class LogInInfo
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
            this.gbxLogInInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.gbxLogInInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxLogInInfo
            // 
            this.gbxLogInInfo.Controls.Add(this.lblIsActive);
            this.gbxLogInInfo.Controls.Add(this.label5);
            this.gbxLogInInfo.Controls.Add(this.lblUserName);
            this.gbxLogInInfo.Controls.Add(this.label3);
            this.gbxLogInInfo.Controls.Add(this.lblUserID);
            this.gbxLogInInfo.Controls.Add(this.label1);
            this.gbxLogInInfo.Location = new System.Drawing.Point(3, 3);
            this.gbxLogInInfo.Name = "gbxLogInInfo";
            this.gbxLogInInfo.Size = new System.Drawing.Size(615, 64);
            this.gbxLogInInfo.TabIndex = 0;
            this.gbxLogInInfo.TabStop = false;
            this.gbxLogInInfo.Text = "LogIn Informations";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserID : ";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(61, 26);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(37, 13);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "[????]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Name : ";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(311, 26);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(37, 13);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "[????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Is Active : ";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(535, 26);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(37, 13);
            this.lblIsActive.TabIndex = 5;
            this.lblIsActive.Text = "[????]";
            // 
            // LogInInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxLogInInfo);
            this.Name = "LogInInfo";
            this.Size = new System.Drawing.Size(621, 70);
            this.gbxLogInInfo.ResumeLayout(false);
            this.gbxLogInInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxLogInInfo;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label1;
    }
}
