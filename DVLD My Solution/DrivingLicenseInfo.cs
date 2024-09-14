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
    public partial class DrivingLicenseInfo : Form
    {
        int _LDLAppID;
        public DrivingLicenseInfo(int lDLAppID)
        {
            InitializeComponent();
            _LDLAppID = lDLAppID;
        }

        private void DrivingLicenseInfo_Load(object sender, EventArgs e)
        {
            driverLicenseInfo1.LoadLicenseInfo(_LDLAppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
