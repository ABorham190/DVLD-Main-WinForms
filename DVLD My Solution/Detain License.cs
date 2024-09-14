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
    public partial class Detain_License : Form
    {
        int _LcenseID;
        Decimal _FineFees;
        int _PersonID;
        clsLicenses _License;
        clsDetain Detain= new clsDetain();
        public Detain_License()
        {
            InitializeComponent();
            
        }

        private void findLicenseByLID1_OnFindLicense(int obj)
        {

            //if (findLicenseByLID1.License.IsDetained)
            //{
            //    MessageBox.Show("This License is already Detained !!",
            //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            //    btnDetain.Enabled = false;
            //    linklblShowLicenseHistory.Enabled = false;
            //    linklblSowLicenseInfo.Enabled = false;

            //    return;
            //}

            if (findLicenseByLID1.License.IsDetained)
            {
                MessageBox.Show("This License Is Detained !! "
                     , "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            this._LcenseID = obj;
            this._License = findLicenseByLID1.License;

            _LoadInitialDetainAppInfoToControls();

            btnDetain.Enabled = true;
            //linklblShowLicenseHistory.Enabled = true;
            //linklblSowLicenseInfo.Enabled = true;


        }

        private void _LoadInitialDetainAppInfoToControls()
        {
            lblCreatedByUserName.Text=Globals.CurrentUser.UserName;
            lblLicenseID.Text = this._License.LicenseID.ToString();
            lblDetainDate.Text = DateTime.Now.ToString("dd - MMM - yyyy");
            
        }

        private void Detain_License_Load(object sender, EventArgs e)
        {
            btnDetain.Enabled = false;
            linklblShowLicenseHistory.Enabled = false;
            linklblSowLicenseInfo.Enabled = false;
        }

        private void _GetFineFees()
        {
            Decimal.TryParse(tbxFineFees.Text, out  this._FineFees);
            Detain.FineFees = this._FineFees;
        }
        private void _LoadDetainInfoToObject()
        {
            Detain.LicenseID=_License.LicenseID;
            Detain.DetainDate=DateTime.Now;
            _GetFineFees();
            Detain.CreatedByUserID=Globals.CurrentUser.UserID;
            Detain.IsRelease = false;

        }

        private bool _IsNecessaryFieldEmpty()
        {
            if (tbxFineFees.Text == "")
            {
                return true;
            }
            return false;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Detain this license??",
                "Confirm Detain", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                if (_IsNecessaryFieldEmpty())
                {
                    MessageBox.Show("Fill All Necessary Fields ", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                _LoadDetainInfoToObject();

                if (!this.Detain.Save())
                {
                    MessageBox.Show("License Not Detained Successfully!!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    linklblShowLicenseHistory.Enabled = false;
                    linklblSowLicenseInfo.Enabled = false;

                    return;
                }
                else
                {
                    MessageBox.Show("License Detained Successfully!!",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDetain.Enabled = false;
                    linklblShowLicenseHistory.Enabled = true;
                    linklblSowLicenseInfo.Enabled = true;

                }
            }
            else
            {

                MessageBox.Show("Cancelled Operation!!",
                       "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void linklblSowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GetLicenseInfoByLicenseID frm = new GetLicenseInfoByLicenseID(this._License);
            frm.ShowDialog();
        }

        private void tbxFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this._PersonID = clsPerson.GetPersonIDByLicenseID(this._License.LicenseID);
            PersonLicensesHistory frm = new PersonLicensesHistory(this._PersonID);
            frm.ShowDialog();
        }
    }
}
