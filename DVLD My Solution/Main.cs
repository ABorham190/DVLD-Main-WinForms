using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVDLBussinessLayer;

namespace DVLD_My_Solution
{
    
    public partial class Main : Form
    {
        public delegate void ThisFormDelg();
        public event ThisFormDelg MakeLogInFormVisible;
        public Main()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_People frm= new Manage_People();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List_Users frm= new List_Users();
            frm.ShowDialog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            MakeLogInFormVisible?.Invoke();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDetails frm = new UserDetails(Globals.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void chngePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword frm = new ChangePassword(Globals.CurrentUser.UserID);
            frm.ShowDialog();
            MakeLogInFormVisible?.Invoke();
            this.Close();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MakeLogInFormVisible?.Invoke();
            this.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Application_Types frm= new Manage_Application_Types();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Tests frm= new Manage_Tests();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Local_Driving_license_Application frm = new New_Local_Driving_license_Application();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Local_Driving_License_Applications frm = new Local_Driving_License_Applications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDrivers frm = new ManageDrivers();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInternationalLicenseApplication frm = new NewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            International_Licenses_Applicatoins frm = new International_Licenses_Applicatoins();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Renew_License frm=new Renew_License();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replacement_For_Damaged_Or_Lost_Licenses frm = new Replacement_For_Damaged_Or_Lost_Licenses();
            frm.ShowDialog();
        }

        private void detailLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detain_License detain_License = new Detain_License();
            detain_License.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDetainedLicenses frm=new ListDetainedLicenses();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm=new ReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Local_Driving_License_Applications frm=new Local_Driving_License_Applications();
            frm.ShowDialog();
        }
    }
}
