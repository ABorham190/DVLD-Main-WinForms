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
    public partial class ChangePassword : Form
    {
        clsUsers User;
        int _UserID;
        public ChangePassword(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }

        private bool _CheckEmptytbx()
        {
            if(tbxCurrentPassword.Text==""||tbxNewPassword.Text==""
                || tbxConfirmPassword.Text == "")
            {
                return true;
            }

            return false;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            User = clsUsers.FindUser(_UserID);
            personInfos1.LoadPersonInfo(User.PersonID);
            logInInfo1.LoadLogInInformations(User.UserID,User.UserName,
                User.IsActive);
        }

        private void tbxCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(tbxCurrentPassword.Text)||
                tbxCurrentPassword.Text != User.UserPassword)
            {
                errorProvider1.SetError(tbxCurrentPassword, "You must Enter current Password");
                tbxCurrentPassword.Focus();
            }
        }

        private void tbxNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(tbxNewPassword.Text))
            {
                errorProvider1.SetError(tbxNewPassword,"You must enter the new password");
                tbxNewPassword.Focus();
            }
        }

        private void tbxConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(tbxConfirmPassword.Text))
            {
                errorProvider1.SetError(tbxConfirmPassword, "You must fill the Password again");
                tbxConfirmPassword.Focus();
            }
            if (tbxConfirmPassword.Text != tbxNewPassword.Text)
            {
                errorProvider1.SetError(tbxConfirmPassword, "Not Match");
                tbxConfirmPassword.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_CheckEmptytbx())
            {
                MessageBox.Show("You must fill all necessary fields.","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to edit password?",
                "Edit Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes) {


                User.UserPassword = tbxNewPassword.Text;
                if (User.Save())
                {
                    MessageBox.Show("Password updated successfully");
                }
                else
                {
                    MessageBox.Show("Password is not updated successfully");
                }

            }
            else
            {
                MessageBox.Show("Cancelled Operation");
            }
        }
    }
}
