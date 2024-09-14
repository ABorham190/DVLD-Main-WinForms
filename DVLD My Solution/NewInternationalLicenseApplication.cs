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
    public partial class NewInternationalLicenseApplication : Form
    {
        clsInternationalLicense InternationalLicense;
        clsOrders Application;
        
        int _LocalLicenseID = -1;
        int _DriverID=-1;
        int _InternationalLicneseID=-1;
        int _PersonID=-1;
        public NewInternationalLicenseApplication()
        {
            InitializeComponent();
        }
        private void _LoadApplicationInfoToObject()
        {
            Application = new clsOrders();
            Application.ApplicantID = clsPerson.GetPersonIDByLicenseID(_LocalLicenseID);
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = 6;
            Application.ApplicationStatus = 3;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = 50;
            Application.CreatedByUserID=Globals.CurrentUser.UserID;
        }

        private void _LoadInternationalLicenseInfoToObject()
        {
            InternationalLicense = new clsInternationalLicense();
            InternationalLicense.DriverID = 
                clsLicenses.GetDriverIDByLocalLicenseID(_LocalLicenseID);
            InternationalLicense.LocalLicenseID = _LocalLicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = InternationalLicense.IssueDate.AddYears(1);
            InternationalLicense.IsActive = true;
            InternationalLicense.CreatedByUserID = Globals.CurrentUser.UserID;
            
        }
        private void _LoadInternationalLicenseInfoToControls()
        {
            lblInternationalLicenseAppID.Text=Application.ApplicationID.ToString();
            lblInternationalLicenseID.Text=InternationalLicense.LicenseID.ToString();   
            lblIssueDate.Text=InternationalLicense.IssueDate.ToString();
            lblExpirationDate.Text=InternationalLicense.ExpirationDate.ToString();
            lblApplicationDate.Text=Application.ApplicationDate.ToString();
            lblLocalLicenseID.Text=InternationalLicense.LocalLicenseID.ToString();
            lblCreatedByUserID.Text=InternationalLicense.CreatedByUserID.ToString();
            lblApplicationFees.Text=Application.PaidFees.ToString();
        }
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ResetgbxInternationalLicenseInfo()
        {
            lblInternationalLicenseAppID.Text = "[????]";
            lblInternationalLicenseID.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            lblApplicationDate.Text = "[????]";
            lblApplicationFees.Text = "[????]";
            lblCreatedByUserID.Text = "[????]";
            lblLocalLicenseID.Text = "[????]";
        }
        private void findLicenseByLID1_OnFindLicense(int obj)
        {
            _LocalLicenseID= obj;
            
            
            if ((InternationalLicense = clsInternationalLicense.FindInterNationalLicense(_LocalLicenseID)) != null)
            {
                MessageBox.Show("There is an INTERNATIONAL license for " +
                    "this Local license With ID = " + InternationalLicense.LicenseID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this._InternationalLicneseID = InternationalLicense.LicenseID;
                linklblShowLicenseInfo.Enabled = true;
                linklblShowLicenseHistory.Enabled = true;
                _ResetgbxInternationalLicenseInfo();



                return;
            }

            btnIssue.Enabled = true;
        }

        private void NewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            linklblShowLicenseInfo.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;
            btnIssue.Enabled = false;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _LoadApplicationInfoToObject();
            _LoadInternationalLicenseInfoToObject();
            if (Application.Save())  
            {

                InternationalLicense.ApplicationID = Application.ApplicationID;

                
            }
            else
            {
                MessageBox.Show("Application Not Saved Successfully!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (InternationalLicense.Save())
            {
                MessageBox.Show("International License ISSUED successfully" +
                    "with ID = " + InternationalLicense.LicenseID,
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //this._LocalLicenseID = InternationalLicense.LicenseID;

            }
            else
            {
                MessageBox.Show("International License NOT ISSUED successfully" +
                    "with ID = " + InternationalLicense.LicenseID,
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            btnIssue.Enabled = false;
            linklblShowLicenseInfo.Enabled= true;
            linklblShowLicenseHistory.Enabled= true;
            this._InternationalLicneseID = InternationalLicense.LicenseID;

            _LoadInternationalLicenseInfoToControls();

        }

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Driver_International_Driving_License_Info frm =
                new Driver_International_Driving_License_Info(this._InternationalLicneseID);
            frm.ShowDialog();
        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (clsPerson.GetPersonIDUsingNationalNumber(findLicenseByLID1.NationalNumber, ref _PersonID))
            {


                PersonLicensesHistory frm = new PersonLicensesHistory(_PersonID);
                frm.ShowDialog();
            }
        }

       
    }
}
