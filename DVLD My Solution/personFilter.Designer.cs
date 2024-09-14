namespace DVLD_My_Solution
{
    partial class personFilter
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
            this.tbxFilterBy = new System.Windows.Forms.TextBox();
            this.cbxFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.personInfos1 = new DVLD_My_Solution.PersonInfos();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddNewPerson);
            this.groupBox1.Controls.Add(this.btnFindPerson);
            this.groupBox1.Controls.Add(this.tbxFilterBy);
            this.groupBox1.Controls.Add(this.cbxFilterBy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // tbxFilterBy
            // 
            this.tbxFilterBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxFilterBy.Location = new System.Drawing.Point(268, 16);
            this.tbxFilterBy.Name = "tbxFilterBy";
            this.tbxFilterBy.Size = new System.Drawing.Size(170, 20);
            this.tbxFilterBy.TabIndex = 2;
            this.tbxFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxFilterBy_KeyPress);
            // 
            // cbxFilterBy
            // 
            this.cbxFilterBy.FormattingEnabled = true;
            this.cbxFilterBy.Items.AddRange(new object[] {
            "National Number",
            "Person ID"});
            this.cbxFilterBy.Location = new System.Drawing.Point(72, 16);
            this.cbxFilterBy.Name = "cbxFilterBy";
            this.cbxFilterBy.Size = new System.Drawing.Size(190, 21);
            this.cbxFilterBy.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter By : ";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackgroundImage = global::DVLD_My_Solution.Properties.Resources.invite_friends__1_;
            this.btnAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewPerson.Location = new System.Drawing.Point(481, 14);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(31, 25);
            this.btnAddNewPerson.TabIndex = 4;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.BackgroundImage = global::DVLD_My_Solution.Properties.Resources.search_b;
            this.btnFindPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindPerson.Location = new System.Drawing.Point(444, 14);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(31, 25);
            this.btnFindPerson.TabIndex = 3;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // personInfos1
            // 
            this.personInfos1.Location = new System.Drawing.Point(13, 73);
            this.personInfos1.Name = "personInfos1";
            this.personInfos1.Size = new System.Drawing.Size(621, 201);
            this.personInfos1.TabIndex = 0;
            // 
            // personFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.personInfos1);
            this.Name = "personFilter";
            this.Size = new System.Drawing.Size(648, 277);
            this.Load += new System.EventHandler(this.personFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PersonInfos personInfos1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.TextBox tbxFilterBy;
    }
}
