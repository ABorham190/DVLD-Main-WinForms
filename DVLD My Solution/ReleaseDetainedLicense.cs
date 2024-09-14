using DVDLBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_My_Solution
{
    
    public partial class ReleaseDetainedLicense : Form
    {
        clsOrders ReleaseLicenseApp;
        clsDetain Detain;


        Decimal _ApplicationFees;
        string _ServiceName;
        string _DetainedByUserName;
        Decimal _TotalFees;
        int _PersonID;
        int _LicenseID;
        public ReleaseDetainedLicense()
        {
            InitializeComponent();
        }
        public ReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            findLicenseByLID1.tbxLicenseID.Text=_LicenseID.ToString();
            findLicenseByLID1.groupBox1.Enabled = false;

            findLicenseByLID1.PerformProcess();
            btnRelease.Enabled = true;

        }

        private void _GetApplicatoinFees()
        {
            if (clsOrders.GetServiceNameAndApplicationFees(5, ref this._ApplicationFees,
                ref this._ServiceName))
            {
                lblApplicationFees.Text = this._ApplicationFees.ToString();
            }
        }
        private void _GetTotalFees()
        {
            this._TotalFees = Detain.FineFees + this._ApplicationFees;
            lblTotalFees.Text = (this._ApplicationFees + Detain.FineFees).ToString(); 
        }
        private void _GetDetainedByUserName()
        {
            if(clsUsers.GetUserNameByUserID(Detain.CreatedByUserID,ref this._DetainedByUserName))
            {
                lblCreatedByUserName.Text=this._DetainedByUserName;
            }
        }
       
        private void _LoadInitialInfoToControls()
        {

            Detain = clsDetain.FindDetain(findLicenseByLID1.License.LicenseID);

            if (Detain != null) {

                lblDetainID.Text=Detain.DetainID.ToString();
                lblDetainDate.Text = Detain.DetainDate.ToString();

                _GetApplicatoinFees();
                
                lblLicenseID.Text =findLicenseByLID1.License.LicenseID.ToString();
                _GetDetainedByUserName();

                lblFineFees.Text =Detain.FineFees.ToString();
                _GetTotalFees();
            }

        }

        private void _LoadApplicationInfoToObject()
        {
            this.ReleaseLicenseApp = new clsOrders();
            this.ReleaseLicenseApp.ApplicantID = clsPerson.GetPersonIDByLicenseID(findLicenseByLID1.License.LicenseID);
            this.ReleaseLicenseApp.ApplicationDate = DateTime.Now;
            this.ReleaseLicenseApp.ApplicationTypeID = 5;
            this.ReleaseLicenseApp.ApplicationStatus = 3;
            this.ReleaseLicenseApp.LastStatusDate = DateTime.Now;
            this.ReleaseLicenseApp.PaidFees = _ApplicationFees;
            this.ReleaseLicenseApp.CreatedByUserID = Globals.CurrentUser.UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void findLicenseByLID1_OnFindLicense(int obj)
        {
            if (!findLicenseByLID1.License.IsDetained)
            {
                MessageBox.Show("This license is NOT detained !!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                linklblSowLicenseInfo.Enabled = false;
                linklblShowLicenseHistory.Enabled = false;
                btnRelease.Enabled = false;
                return;
            }
            linklblSowLicenseInfo.Enabled = true;
            linklblShowLicenseHistory.Enabled = true;
            btnRelease.Enabled = true;
            _LoadInitialInfoToControls();
        }
        private void _LoadReleaseDetainInfo()
        {
            Detain.IsRelease=true;
            Detain.ReleaseDate = ReleaseLicenseApp.ApplicationDate;
            Detain.ReleasedByUserId = Globals.CurrentUser.UserID;
            Detain.ReleasedAppID = ReleaseLicenseApp.ApplicationID;

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained License?",
                "Release Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {

                _GetApplicatoinFees();
                _LoadApplicationInfoToObject();

                if (!this.ReleaseLicenseApp.Save())
                {
                    MessageBox.Show("Release License Application NOT saved " +
                        "Successfully !!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                _LoadReleaseDetainInfo();
                if (!Detain.Save())
                {
                    MessageBox.Show("Detain NOT Released " +
                        "Successfully !!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("License Released " +
                        "Successfully !!",
                        "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            else
            {

                MessageBox.Show("Cancelled Operation " 
                        ,
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            linklblShowLicenseHistory.Enabled = true;
            linklblSowLicenseInfo.Enabled = true;
            btnRelease.Enabled = false;

        }

        private void ReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            linklblSowLicenseInfo.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;
            btnRelease.Enabled = true;
        }

        private void linklblSowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetLicenseInfoByLicenseID frm = new GetLicenseInfoByLicenseID(findLicenseByLID1.License);
            frm.ShowDialog();
        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this._PersonID = clsPerson.GetPersonIDByLicenseID(findLicenseByLID1.License.LicenseID);
            PersonLicensesHistory frm = new PersonLicensesHistory(this._PersonID);
            frm.ShowDialog();
        }
    }
}
