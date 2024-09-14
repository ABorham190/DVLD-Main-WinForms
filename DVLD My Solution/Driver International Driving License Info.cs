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
    public partial class Driver_International_Driving_License_Info : Form
    {
        int _InternationalLicneseID;
        public Driver_International_Driving_License_Info(int internationalLicneseID)
        {
            InitializeComponent();
            _InternationalLicneseID = internationalLicneseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Driver_International_Driving_License_Info_Load(object sender, EventArgs e)
        {
            internationalLicenseInfo1.FindAndLoadInternationalLicenseInfo(_InternationalLicneseID);
        }
    }
}
