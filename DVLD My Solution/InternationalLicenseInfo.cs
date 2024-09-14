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
    public partial class InternationalLicenseInfo : UserControl
    {
        clsInternationalLicense InternationalLicense;
        
        public InternationalLicenseInfo()
        {
            InitializeComponent();
        }
        private void _LoadDetailedInternationalLiceneseObjectToControls()
        {
            lblApplicantName.Text = InternationalLicense.Name;
            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            lblDateOfBirth.Text = InternationalLicense.DateOfBirth.ToString("dd - MMM - yyyy");
            lblDriverID.Text=InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToString("dd - MMM - yyyy");
            if(InternationalLicense.Gender == 0)
            {
                lblGender.Text = "Female";
            }
            else
            {
                lblGender.Text = "Male";
            }

            if (InternationalLicense.IsActive)
                lblIsActive.Text = "Yes";
            else 
                lblIsActive.Text = "No";
            lblIssueDate.Text = InternationalLicense.IssueDate.ToString("dd - MMM - yyyy");
            lblLicenseID.Text=InternationalLicense.LicenseID.ToString();
            lblLocalLicenseID.Text=InternationalLicense.LocalLicenseID.ToString();
            lblNationalNo.Text=InternationalLicense.NationalNo.ToString();
            picboxApplicantPic.ImageLocation = InternationalLicense.ImagePath;

        }
        public void FindAndLoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            if((InternationalLicense=clsInternationalLicense.
                FindDetailedInternationalLicenseInfoByILID(InternationalLicenseID)) != null)
            {
                _LoadDetailedInternationalLiceneseObjectToControls();
            }
            else
            {
                MessageBox.Show("NOT Found", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
