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
    public partial class GetLicenseInfoByLicenseID : Form
    {
        int _LicenseID;
        clsLicenses LocalLicense;
        public GetLicenseInfoByLicenseID(clsLicenses License)
        {
            InitializeComponent();
            this.LocalLicense = License;
        }

        private void GetLicenseInfoByLicenseID_Load(object sender, EventArgs e)
        {
            driverLicenseInfoUsingLID1.LoadLicenseInfo(this.LocalLicense);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
