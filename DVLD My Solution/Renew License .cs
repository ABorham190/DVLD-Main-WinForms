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
    public partial class Renew_License : Form
    {
        int _LicenseID;
        string _ServiceName;
        Decimal _ApplicationFees;
        Decimal _LicenseFees;
        Decimal _TotalFees;
        int _DriverID;
        int _PersonID;

        clsOrders RenewLicenseApp;
        clsLicenses NewLicense;
        

        public Renew_License()
        {
            InitializeComponent();
        }

        private bool _IsLicenseExpired()
        {
            if(findLicenseByLID1.LicenseExpirationDate < DateTime.Now)
            {
                return true;
            }
            return false;
        }

        private void _GetApplicatoinFees()
        {
            if(clsOrders.GetServiceNameAndApplicationFees(2,ref this._ApplicationFees,
                ref this._ServiceName))
            {
                lblApplicationFees.Text= this._ApplicationFees.ToString();
            }
        }
        private void _GetLicenseFees()
        {
            if(clsLicenses.GetLicenseClassFeesByClassName(findLicenseByLID1.ClassName,
                ref this._LicenseFees))
            {
                lblLicenseFees.Text = this._LicenseFees.ToString();
            }
        }
        private void _SetTotalFees()
        {
            this._TotalFees = this._ApplicationFees + this._LicenseFees;
            lblTotalFees.Text = this._TotalFees.ToString();
        }

        private void _FillInitialAppInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            _GetApplicatoinFees();
            _GetLicenseFees();
            lblOldLicenseID.Text=this._LicenseID.ToString();

            _SetTotalFees();
            lblCreatedByUserName.Text=Globals.CurrentUser.UserName;

        }
        private void _ResetInitialAppInfo()
        {
            lblApplicationDate.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblApplicationFees.Text = "[????]";
            lblLicenseFees.Text = "[????]";
            lblOldLicenseID.Text = "[????]";
            lblTotalFees.Text = "[????]";
            lblCreatedByUserName.Text = Globals.CurrentUser.UserName;
        }

        private void findLicenseByLID1_OnFindLicense(int obj)
        {
            _LicenseID = obj;
            if (!_IsLicenseExpired())
            {
                MessageBox.Show("This license not expired yet !!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnRenew.Enabled = false;
                linklblSowLicenseInfo.Enabled = false;
                linklblShowLicenseHistory.Enabled = false;

                _ResetInitialAppInfo();

                return;

            }
           

            btnRenew.Enabled = true;
            _FillInitialAppInfo();

        }

        private void Renew_License_Load(object sender, EventArgs e)
        {
            linklblShowLicenseHistory.Enabled = false;
            linklblSowLicenseInfo.Enabled = false;
            btnRenew.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadApplicationInfoToObject()
        {
            this.RenewLicenseApp = new clsOrders();
            RenewLicenseApp.ApplicantID = clsPerson.GetPersonIDByLicenseID(_LicenseID);
            RenewLicenseApp.ApplicationDate = DateTime.Now;
            RenewLicenseApp.ApplicationTypeID = 2;
            RenewLicenseApp.ApplicationStatus = 3;
            RenewLicenseApp.LastStatusDate = DateTime.Now;
            RenewLicenseApp.PaidFees = _ApplicationFees;
            RenewLicenseApp.CreatedByUserID = Globals.CurrentUser.UserID;
        }
        private void _LoadNewLicenseInfoToObject()
        {
            this.NewLicense = new clsLicenses();
            NewLicense.ApplicationID = RenewLicenseApp.ApplicationID;
            NewLicense.DriverID = findLicenseByLID1.DriverID;
            NewLicense.LicenseClassID = clsLicenses.GetLicenseClassIDByclassName(
                findLicenseByLID1.ClassName);
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(10);
            NewLicense.PaidFees = this._LicenseFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = 2;
            NewLicense.CreatedByUserID= Globals.CurrentUser.UserID;


        }

       

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew this " +
                "expired license??", "Renew Confirm", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _LoadApplicationInfoToObject();


                if (!RenewLicenseApp.Save())
                {
                    MessageBox.Show("Renew License Application NOT Saved" +
                        " Successfully!!", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                _LoadNewLicenseInfoToObject();
                NewLicense.Notes = tbxNotes.Text;

                if (!NewLicense.Save())
                {
                    MessageBox.Show("License Not Renewed" +
                       " Successfully!!", "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    return;
                }

                lblRLApplicationID.Text = RenewLicenseApp.ApplicationID.ToString();
                lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
                lblExpirationDate.Text = NewLicense.ExpirationDate.ToString();

                if (!clsLicenses.DeactivateLocalLicenseByLicenseID(this._LicenseID))
                {
                    MessageBox.Show("Old License Not Deactivated Successfully!!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            else
            {
                MessageBox.Show("Cancelled Operation !!",
                        "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            MessageBox.Show("License Renewed Successfully ", "Done",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRenew.Enabled = false;

            linklblSowLicenseInfo.Enabled = true;
            linklblShowLicenseHistory.Enabled = true;
        }

        private void linklblSowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicenses License=clsLicenses.GetLicenseDetailsByLLicenseID(NewLicense.LicenseID);
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
            this._PersonID= clsPerson.GetPersonIDByLicenseID(this._LicenseID);
            PersonLicensesHistory frm = new PersonLicensesHistory(this._PersonID);
            frm.Show();
        }
    }
}
