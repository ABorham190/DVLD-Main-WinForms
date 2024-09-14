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
    public partial class LogInInfo : UserControl
    {
        //int UserID;
        //string UserName;
        //int IsActive;
        public LogInInfo()
        {
            InitializeComponent();
        }

        public void LoadLogInInformations(int UserID, string UserName,
            bool IsActive)
        {

            lblUserID.Text = UserID.ToString();
            lblUserName.Text = UserName.ToString();
            if (IsActive == true)
            {
                lblIsActive.Text = "Yes";
            }
            else
            {
                lblIsActive.Text = "No";
            }

        }



    }
}
