using DVDLBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_My_Solution
{
    public partial class Add_New_User : Form
    {
        


        //Test modification => first modification 
        int PersonID = -1;
        int UserID = -1;
        clsUsers User= new clsUsers();
        string _WhatToDo;
        enum enMode { AddNewMode = 0, UpdateMode = 1 }
        enMode _Mode;
        public Add_New_User(int UserID=-1)
        {
            InitializeComponent();
            this.UserID = UserID;
            if(this.UserID == -1) 
            { 
              _Mode= enMode.AddNewMode;
                _WhatToDo = "Add";

            }
            else
            {
                _Mode= enMode.UpdateMode;
                _WhatToDo= "Update";
            }
        }
        private bool IsNessecaryFieldsEmpty()
        {
            
            
                if (tbxUserName.Text == "" || tbxPassword.Text == "" ||
                    tbxConfirmPassword.Text == "")
                {
                    return true;
                }
            
            return false;
        }
        private bool CheckFieldsValidation()
        {
            if(_Mode== enMode.AddNewMode)
            {
                return IsNessecaryFieldsEmpty();
            }
            if (personFilter1.ID == -1)
            {
                return true;
            }
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Here place of removed procedure
        private void btnSave_Click(object sender, EventArgs e)
        {
            

            if (CheckFieldsValidation())
            {
                MessageBox.Show("Please Fill All Nessecary Fields.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           


            if (MessageBox.Show("Are you sure you want to "+_WhatToDo+" this person as a user?",
               "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) ==
               DialogResult.Yes)
            {
                User.PersonID = personFilter1.ID;
                User.UserPassword = tbxPassword.Text;
                User.UserName = tbxUserName.Text;
                if (chbxIsActive.Checked)
                {
                    User.IsActive = true;
                }
                else
                {
                    User.IsActive = false;
                }
                if (User.Save())
                {
                    MessageBox.Show("User "+_WhatToDo+"ed successfully");
                    lblUserID.Text = User.UserID.ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User not "+_WhatToDo+"ed successfully");
                }
            }
            else
            {
                MessageBox.Show("Cancelled operation");
            }



        }

        private void Add_New_User_Load(object sender, EventArgs e)
        {
            if(_Mode== enMode.AddNewMode)
            {
                lblFormHeader.Text = "Add New User";
                tbxUserName.Enabled = false;
                tbxPassword.Enabled = false;
                tbxConfirmPassword.Enabled = false;
                return;
            }
            lblFormHeader.Text = "Update User";
            User = clsUsers.FindUser(UserID);
            personFilter1.LoadPersonInfoToPersonInfosControl(User.PersonID);
            this.PersonID=User.PersonID;
            tbxPassword.Text = User.UserPassword;
            tbxPassword.ReadOnly = true;
            tbxUserName.Text = User.UserName;
            tbxUserName.ReadOnly=true;
            tbxConfirmPassword.Text = User.UserPassword;
            tbxConfirmPassword.ReadOnly = true;
            lblUserID.Text = User.UserID.ToString();
            chbxIsActive.Checked = (User.IsActive == true);
            

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNewMode)
            {
                if (clsPerson.IsPersonAUser(personFilter1.ID))
                {
                    MessageBox.Show("This Person is already user", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            tbxUserName.Enabled = true;
            tbxPassword.Enabled = true;
            tbxConfirmPassword.Enabled = true;

           
            tabControl1.SelectedIndex = 1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void tbxUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxUserName.Text))
            {
                errorProvider1.SetError(tbxUserName, "User Name must entered");
                tbxUserName.Focus();
            }
        }

        private void tbxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxPassword.Text))
            {
                errorProvider1.SetError(tbxPassword, "Password Must be Entered");
                tbxPassword.Focus();
            }
        }

        private void tbxConfirmPassword_Validating(object sender, CancelEventArgs e)
                {
          if(tbxConfirmPassword.Text!=tbxPassword.Text) 
            {

                errorProvider1.SetError(tbxConfirmPassword, "Not match");
                tbxConfirmPassword.Focus();
            
            }
        }

       
    }
}
