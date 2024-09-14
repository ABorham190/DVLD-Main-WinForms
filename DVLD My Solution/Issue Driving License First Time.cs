using DVDLBussinessLayer;
using GlobalStructs;
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
    public partial class Issue_Driving_License_First_Time : Form
    {
        clsLicenses License;
        clsDriver Driver;
        int _LDLAppID = 0;
        int _PersonID = 0;
        int _DriverID = 0;
        public Issue_Driving_License_First_Time(int lDLAppID)
        {
            InitializeComponent();
            _LDLAppID = lDLAppID;
        }
        private void _LoadFormData()
        {
            ldlAppAndAppInfo1.LoadInfo(_LDLAppID);
        }

        private void Issue_Driving_License_First_Time_Load(object sender, EventArgs e)
        {

            ldlAppAndAppInfo1.LoadInfo(_LDLAppID);
            _GetPersonID();
        }
        private void _GetPersonID()
        {
            int PersID = 0;
            if (clsPerson.GetPersonIDUsingLDLAppID(_LDLAppID, ref PersID))
            {
                _PersonID = PersID;
            }
        }
        private void _LoadDriverInfoToObject()

        {
           
                Driver = new clsDriver();
                Driver.PersonID = _PersonID;
                Driver.CreatedDate = DateTime.Now;
                Driver.CreatedByUserID = Globals.CurrentUser.UserID;
           
            

        }
        private void _LoadLicenseInfoToObject()
        {
            License = new clsLicenses();
            License.ApplicationID = ldlAppAndAppInfo1.ApplicationID;
            License.DriverID = _DriverID;
            License.LicenseClassID = ldlAppAndAppInfo1.LicenseClassID;
            License.IssueDate=DateTime.Now;
            License.ExpirationDate = License.IssueDate.AddYears(10);
            License.Notes=tbxNotes.Text;
            License.PaidFees = 15;
            License.IsActive = true;
            License.IssueReason = 1;
            License.CreatedByUserID = Globals.CurrentUser.UserID;

        }

        private void _SetDriverAndLicenseObjects()
        {
            _LoadDriverInfoToObject();
            _DriverID = Driver.DriverID;
            _LoadLicenseInfoToObject();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            int Driverid = 0;
            _SetDriverAndLicenseObjects();
            if (!clsPerson.IsThisPersonADriver(_PersonID,ref Driverid))
            {
                if (!Driver.AddNewDriver())
                {
                    MessageBox.Show("Driver NOT Added Successfully!!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                License.DriverID = Driver.DriverID;
            }
            else
            {
                License.DriverID = Driverid;
            }
            if (!License.Save())
            {
                MessageBox.Show("License NOT Added Successfully!!",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("License ADDED Successfully with ID="+
                    License.LicenseID,
                   "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!clsOrders.CompleteOrder(ldlAppAndAppInfo1.ApplicationID))
                {
                    MessageBox.Show("Application NOT Completed Successfully!!",
                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();
            
        }
    }
}
