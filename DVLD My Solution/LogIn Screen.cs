using DVDLBussinessLayer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace DVLD_My_Solution
{
    public partial class LogIn_Screen : Form
    {
        clsUsers User;
        public LogIn_Screen()
        {
            InitializeComponent();
        }
    

        private string _GetUserNameFromWinRegistry()
        {
            string Path = @"HKEY_CURRENT_USER\SOFTWARE\MyUserNameAndPassword";
            string UserNameName = "UserName";
            string UserName = "";
            try
            {
                UserName = Registry.GetValue(Path, UserNameName, null).ToString();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return UserName;
        }
        private string _GetPasswordFromRegistry()
        {
            string Path = @"HKEY_CURRENT_USER\SOFTWARE\MyUserNameAndPassword";
            string PassName = "Password";
            string Password = "";
            try
            {
                Password = Registry.GetValue(Path, PassName, null).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return Password;
        }
        private void _GetUserNameAndPasswordFromRegistry()
        {
            tbxUserName.Text = _GetUserNameFromWinRegistry();
            tbxPassword.Text=_GetPasswordFromRegistry();
        }
       

        private bool _IsThereEmptyFields()
        {
            if (tbxUserName.Text == "" || tbxPassword.Text == "")
            {
                return true;
            }
            return false;
        }
        private bool _LogIn()
        {
            User = clsUsers.FindUser(tbxUserName.Text, tbxPassword.Text);
            if (User == null)
            {
                MessageBox.Show("Incorrect User Name Or Password!!", "Login error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (User.IsActive==false)
            {
                MessageBox.Show("This user must be activated to be able to log in",
                    "LogIn Fail",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;

            }
            return true;
        }
        private void _MakeThisFormVisible()
        {
            this.Visible = true;
            _GetUserNameAndPasswordFromRegistry();
        }
        private bool _AddUserNameToRegistery(string UserName)
        {
            string Path = @"HKEY_CURRENT_USER\SOFTWARE\MyUserNameAndPassword";
            string UserNameName = "UserName";
            string UserNameValue = UserName;
            try
            {
                Registry.SetValue(Path, UserNameName, UserNameValue, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }




        }
        private bool _AddPasswordToRegistery(string PassWord)
        {
            string Path = @"HKEY_CURRENT_USER\SOFTWARE\MyUserNameAndPassword";
            string PassordName = "PassWord";
            string PasswordValue = PassWord;
            try
            {
                Registry.SetValue(Path, PassordName, PasswordValue, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }



        }
        private void _SaveUserNameAndPasswordInWinRegistry(string UserName = "", string Password = "")
        {
            if (!_AddUserNameToRegistery(UserName) || !_AddPasswordToRegistery(Password))
            {
                MessageBox.Show("User Name Or Password Not Added To Registry !!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void _HandleUserNameAndPasswordToWinRegistry()
        {
            if (cbxRememberMe.Checked)
            {
                _SaveUserNameAndPasswordInWinRegistry(tbxUserName.Text, tbxPassword.Text);
            }
            else
            {
                _SaveUserNameAndPasswordInWinRegistry();

            }
        }


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if(_IsThereEmptyFields())
            {
                MessageBox.Show("You must enter username and password!!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_LogIn())
            {
                Globals.CurrentUser= User;
                _HandleUserNameAndPasswordToWinRegistry();
                tbxUserName.Text = "";
                tbxPassword.Text = "";
                this.Visible = false;
                Main frm = new Main();
                frm.MakeLogInFormVisible += _MakeThisFormVisible;
                frm.ShowDialog();
            }
            
        }

        private void LogIn_Screen_Load(object sender, EventArgs e)
        {
            cbxRememberMe.Checked = true;

            _GetUserNameAndPasswordFromRegistry();
        }

        
    }
}
