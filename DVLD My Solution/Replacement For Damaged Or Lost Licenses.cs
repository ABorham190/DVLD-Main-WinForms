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
    public partial class Replacement_For_Damaged_Or_Lost_Licenses : Form
    {
        clsOrders ReplaceLicense;
        clsLicenses NewLicense;
        clsLicenses OldLicense;

        int _OldLicenseID;
        Decimal _ApplicationFees;
        string _ApplicationName;
        int _ApplicationTypeID;
        int _PersonID;
        public Replacement_For_Damaged_Or_Lost_Licenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void findLicenseByLID1_OnFindLicense(int obj)
        {
            this._OldLicenseID = obj;
            this.OldLicense = findLicenseByLID1.License;
            _LoadAppInfo();
            btnIssueReplacement.Enabled = true;
        }

        private void _LoadAppInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblOldLicenseID.Text = this._OldLicenseID.ToString();
            lblCreatedByUserName.Text=Globals.CurrentUser.UserName;
        }
        private void _LoadApplicationInfoToObject()
        {
            this.ReplaceLicense = new clsOrders();
            this.ReplaceLicense.ApplicantID = clsPerson.GetPersonIDByLicenseID(this._OldLicenseID);
            this.ReplaceLicense.ApplicationDate = DateTime.Now;
            this.ReplaceLicense.ApplicationTypeID = this._ApplicationTypeID;
            this.ReplaceLicense.ApplicationStatus = 3;
            this.ReplaceLicense.LastStatusDate = DateTime.Now;
            this.ReplaceLicense.PaidFees = _ApplicationFees;
            this.ReplaceLicense.CreatedByUserID = Globals.CurrentUser.UserID;
        }
        private void _LoadNewLicenseInfoToObject()
        {
            this.NewLicense = new clsLicenses();
            NewLicense.ApplicationID = ReplaceLicense.ApplicationID;
            NewLicense.DriverID = OldLicense.DriverID;
            NewLicense.LicenseClassID = clsLicenses.GetLicenseClassIDByclassName(OldLicense.ClassName);
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = OldLicense.ExpirationDate;
            NewLicense.PaidFees = 0;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = 3;
            NewLicense.CreatedByUserID = Globals.CurrentUser.UserID;
            NewLicense.Notes=OldLicense.Notes;


        }

        private void rbtnDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnDamagedLicense.Checked)
            {
                if (clsOrders.GetServiceNameAndApplicationFees(4,
                    ref _ApplicationFees, ref _ApplicationName)) {
                    lblApplicationFees.Text = _ApplicationFees.ToString();
                }
                this._ApplicationTypeID = 4;
            }
        }

        private void rbtnLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (clsOrders.GetServiceNameAndApplicationFees(3,
                    ref _ApplicationFees, ref _ApplicationName))
            {
                lblApplicationFees.Text = _ApplicationFees.ToString();
            }
            this._ApplicationTypeID = 3;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (!rbtnDamagedLicense.Checked && !rbtnLostLicense.Checked)
            {
                MessageBox.Show("Please Choose Damaged Or Lost License??",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (MessageBox.Show("Are you sure you want to replace this License?",
                    "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
            {
                _LoadApplicationInfoToObject();


                if (!this.ReplaceLicense.Save())
                {
                    MessageBox.Show("Application NOT Saved Successfully!!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    lblRLAppID.Text = ReplaceLicense.ApplicationID.ToString();
                }
                _LoadNewLicenseInfoToObject();
                if (!this.NewLicense.Save())
                {
                    MessageBox.Show("New License NOT Issued Successfully!!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    linklblShowLicenseHistory.Enabled = false;
                    linklblSowLicenseInfo.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("New License Issued Successfully with License ID ="+NewLicense.LicenseID,
                        "New License Issued", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblRenewedLicenseID.Text = this.NewLicense.LicenseID.ToString();
                    btnIssueReplacement.Enabled = false;
                    linklblShowLicenseHistory.Enabled = true;
                    linklblSowLicenseInfo.Enabled = true;

                }

                if (!clsLicenses.DeactivateLocalLicenseByLicenseID(this._OldLicenseID))
                {
                    MessageBox.Show("Old License Not Deactivated Successfully!!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnIssueReplacement.Enabled=false;
                    linklblShowLicenseHistory.Enabled = true;
                    linklblSowLicenseInfo.Enabled = true;

                }
            }
            else
            {
                MessageBox.Show("Cancelled Operation !!");
            }


        }

        private void Replacement_For_Damaged_Or_Lost_Licenses_Load(object sender, EventArgs e)
        {
            btnIssueReplacement.Enabled=false;
            linklblShowLicenseHistory.Enabled=false;
            linklblSowLicenseInfo.Enabled=false;
        }

        private void linklblSowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicenses License = clsLicenses.GetLicenseDetailsByLLicenseID(NewLicense.LicenseID);
            if (License != null)
            {
                GetLicenseInfoByLicenseID frm = new GetLicenseInfoByLicenseID(License);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong License ID!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this._PersonID = clsPerson.GetPersonIDByLicenseID(this._OldLicenseID);
            PersonLicensesHistory frm = new PersonLicensesHistory(this._PersonID);
            frm.Show();
        }
    }
}
