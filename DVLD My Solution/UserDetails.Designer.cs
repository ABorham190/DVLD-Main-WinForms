namespace DVLD_My_Solution
{
    partial class UserDetails
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
            this.btnClose = new System.Windows.Forms.Button();
            this.logInInfo1 = new DVLD_My_Solution.LogInInfo();
            this.personInfos1 = new DVLD_My_Solution.PersonInfos();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(553, 310);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 33);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // logInInfo1
            // 
            this.logInInfo1.Location = new System.Drawing.Point(18, 229);
            this.logInInfo1.Name = "logInInfo1";
            this.logInInfo1.Size = new System.Drawing.Size(610, 70);
            this.logInInfo1.TabIndex = 1;
            // 
            // personInfos1
            // 
            this.personInfos1.Location = new System.Drawing.Point(12, 12);
            this.personInfos1.Name = "personInfos1";
            this.personInfos1.Size = new System.Drawing.Size(621, 211);
            this.personInfos1.TabIndex = 0;
            // 
            // UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 355);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.logInInfo1);
            this.Controls.Add(this.personInfos1);
            this.Name = "UserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserDetails";
            this.Load += new System.EventHandler(this.UserDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PersonInfos personInfos1;
        private LogInInfo logInInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}