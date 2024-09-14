using DVDLBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_My_Solution
{
    public partial class FindLicenseByLID : UserControl
    {

        public string NationalNumber = "";
        // Define a custom event handler delegate with parameters
        public event Action<int> OnFindLicense;
        // Create a protected method to raise the event with a parameter
        protected virtual void FindLicenseComplete(int LicenseID,int DriverID)
        {
            Action<int> handler = OnFindLicense;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }






        public clsLicenses License;
        public DateTime LicenseExpirationDate;
        public string ClassName;
        public int DriverID;
        public FindLicenseByLID()
        {
            InitializeComponent();
        }
        private bool _CheckNessesaryFields()
        {
            if (tbxLicenseID.Text == "")
            {
                return true;
            }
            return false;
        }

        public void PerformProcess()
        {
            if (_CheckNessesaryFields())
            {
                MessageBox.Show("You must enter LICENSE ID !!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                driverLicenseInfoUsingLID1.ResetControls();
                return;
            }

            int.TryParse(tbxLicenseID.Text, out int _LicenseID);
            if ((License = clsLicenses.GetLicenseDetailsByLLicenseID(_LicenseID)) == null)
            {
                MessageBox.Show("There is no License with this LICENSE ID !!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                driverLicenseInfoUsingLID1.ResetControls();
                return;
            }
            else
            {
                driverLicenseInfoUsingLID1.LoadLicenseInfo(License);
                this.NationalNumber = License.NationalNo;
            }

            if (!License.IsActive)
            {
                MessageBox.Show("This License Is Not Active , You must " +
                    "Activate it firstly .", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            this.LicenseExpirationDate = License.ExpirationDate;
            this.ClassName = License.ClassName;
            this.DriverID = License.DriverID;

            if (OnFindLicense != null)
                FindLicenseComplete(License.LicenseID, License.DriverID);
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (_CheckNessesaryFields())
            {
                MessageBox.Show("You must enter LICENSE ID !!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                driverLicenseInfoUsingLID1.ResetControls();
                return;
            }

            int.TryParse(tbxLicenseID.Text, out int _LicenseID);
            if ((License = clsLicenses.GetLicenseDetailsByLLicenseID(_LicenseID)) == null)
            {
                MessageBox.Show("There is no License with this LICENSE ID !!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                driverLicenseInfoUsingLID1.ResetControls();
                return;
            }
            else
            {
                 driverLicenseInfoUsingLID1.LoadLicenseInfo(License);
                 this.NationalNumber = License.NationalNo;
            }

            if (!License.IsActive)
            {
                MessageBox.Show("This License Is Not Active , You must " +
                    "Activate it firstly .", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           

            this.LicenseExpirationDate = License.ExpirationDate;
            this.ClassName = License.ClassName;
            this.DriverID= License.DriverID;

            if (OnFindLicense != null)
                FindLicenseComplete(License.LicenseID,License.DriverID);
        }
    }
}
