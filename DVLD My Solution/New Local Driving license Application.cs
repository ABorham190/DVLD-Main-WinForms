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
    public partial class New_Local_Driving_license_Application : Form
    {
        DataTable TableContainLicensesClasses=clsLicenses.GetLicenseClasses();
        clsOrders Order;
        public New_Local_Driving_license_Application()
        {
            InitializeComponent();
        }
        private void _FillCbxLiceseClasses()
        {
            DataView dv = new DataView(TableContainLicensesClasses);
            for (int i = 0; i < dv.Count; i++)
            {
                cbxLicenseClass.Items.Add(dv[i][0].ToString());
            }

            cbxLicenseClass.SelectedIndex = 2;
        }
        private void _SetDate()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd - MM - yyyy");
        }
        private void _SetCreatedByLabel()
        {
            lblCreatedBy.Text=Globals.CurrentUser.UserName;
        }

       private bool _PersonFound()
        {
            if (personFilter1.ID == -1)
            {
                return false;
            }
            return true;
        }

        private void New_Local_Driving_license_Application_Load(object sender, EventArgs e)
        {
            float ServiceFees = 0;
            _FillCbxLiceseClasses();
            _SetDate();
            _SetCreatedByLabel();
            btnSave.Enabled = false;
            if (clsOrders.GetAppFees("New Local Driving License Service", ref ServiceFees)) {
                lblApplicationFees.Text = ServiceFees.ToString();
            }
            else
            {
                lblApplicationFees.Text = "UnKonwn";
            }
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!_PersonFound())
            {
                MessageBox.Show("Please Select A Person !!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           tabControl1.SelectedIndex = 1;
            btnSave.Enabled = true; 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxLicenseClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseID = 0;
            if(clsLicenses.IsThisPersonHasLicenseFromThisType(personFilter1.ID,
                cbxLicenseClass.SelectedIndex+1,ref LicenseID))
            {
                MessageBox.Show("This Person Already Has License From " +
                    "This Type With LicenseID = " + LicenseID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ApplicationID = -1;
            if (clsOrders.IsApplicationExist(personFilter1.ID,cbxLicenseClass.SelectedIndex+1,ref ApplicationID))
            {
                MessageBox.Show("This Person is already has an application " +
                    "for this License type with ID = "+ApplicationID,"Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            Order = new clsOrders();
           Order.ApplicationDate=DateTime.Now;
            //Order.PassedTests = 0;
            Order.ApplicationStatus = 1;
            //Order.LicesneTypeID = cbxLicenseClass.SelectedIndex + 1;
            Order.ApplicantID = personFilter1.ID;
            Order.ApplicationTypeID = 1;
            Order.LastStatusDate = DateTime.Now;
            Order.CreatedByUserID=Globals.CurrentUser.UserID;

            
           

            if (Order.Save())
            {
                LDLApp ldlApp = new LDLApp();
                ldlApp.AppID=Order.ApplicationID;
                ldlApp.LicenseTypeID=cbxLicenseClass.SelectedIndex+1;

                lblApplicationID.Text =Order.ApplicationID.ToString();
                MessageBox.Show("Order Added Successfully","Data saved",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (!ldlApp.Save())
                {
                    MessageBox.Show("Application not Added to LDLApps Table",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Order Not Added Successfully","Data Not Saved"
                    ,MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
        }

    }
}
