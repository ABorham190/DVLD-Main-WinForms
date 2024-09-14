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
    public partial class DriverLicenseInfoUsingLID : UserControl
    {
        
        int _LicenseID = 0;
        public DriverLicenseInfoUsingLID()
        {
            InitializeComponent();
        }

        private void _SetIssueReasons(int IssueReason)
        {
            switch (IssueReason)
            {
                case 1:
                    lblIssueReason.Text = "First Time";
                    break;
                case 2:
                    lblIssueReason.Text = "Renew";
                    break;
                case 3:
                    lblIssueReason.Text = "Rep. Damaged";
                    break;
                case 4:
                    lblIssueReason.Text = "Rep. Lost";
                    break;
                default:
                    lblIssueReason.Text = "FirstTime";
                    break;
            }
        }

        public void ResetControls()
        {

            lblApplicantName.Text = "[????]";
            lblClassName.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            lblIsActive.Text = "[????]";

            lblIssueDate.Text = "[????]";
            lblIssueReason.Text = "[????]";

            lblLicenseID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblNotes.Text = "[????]";
            lblGender.Text = "[????]";
            lblIsDetained.Text = "[????]";
            picboxApplicantPic.ImageLocation = "";
            
        }
        public void LoadLicenseInfo(clsLicenses License)
        {
            License.IsDetained = clsLicenses.IsThisLicenseStillDetained(License.LicenseID);
            
            lblApplicantName.Text = License.Name;
            lblClassName.Text = License.ClassName;
            lblDateOfBirth.Text = License.DateOfBirth.ToString("dd - MM - yyyy");
            lblDriverID.Text = License.DriverID.ToString();
            lblExpirationDate.Text = License.ExpirationDate.ToString("dd - MM - yyyy");

            if (License.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

            lblIssueDate.Text = License.IssueDate.ToString("dd - MM - yyyy");
            _SetIssueReasons(License.IssueReason);
            lblLicenseID.Text = License.LicenseID.ToString();
            lblNationalNo.Text = License.NationalNo.ToString();
            lblNotes.Text = License.Notes.ToString();
            if (License.Gender == 0)
                lblGender.Text = "Female";
            else
                lblGender.Text = "Male";

            if (License.ImagePath != "")
                picboxApplicantPic.ImageLocation = License.ImagePath;

            if (License.IsDetained)
                lblIsDetained.Text = "Yes";
            else
                lblIsDetained.Text = "No";

        }
    }
}
