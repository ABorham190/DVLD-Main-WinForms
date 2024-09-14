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
    public partial class UserDetails : Form
    {
        clsUsers User;
        int _UserID;
        public UserDetails(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            User = clsUsers.FindUser(_UserID);
            personInfos1.LoadPersonInfo(User.PersonID);
            logInInfo1.LoadLogInInformations(User.UserID, User.UserName,
                User.IsActive);
        }
    }
}
