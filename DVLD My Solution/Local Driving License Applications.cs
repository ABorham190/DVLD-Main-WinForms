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
    public partial class Local_Driving_License_Applications : Form
    {
        DataTable TableContainAllApplications=new DataTable();
        int _PersonID;
       
        public Local_Driving_License_Applications()
        {
            InitializeComponent();
        }

        private void _SetCMSEditApplication()
        {
            if ((string)dgvApplicationList.CurrentRow.Cells[6].Value == "New")
            {
                contextMenuStrip1.Items[2].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[2].Enabled=false;
            }
        }
        private void _SetCMSDeleteApplication()
        {
            if ((string)dgvApplicationList.CurrentRow.Cells[6].Value == "Cancelled")
            {
                contextMenuStrip1.Items[3].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[3].Enabled=false;
            }
        }
        private void _SetCMSCancellApplication()
        {
            if ((string)dgvApplicationList.CurrentRow.Cells[6].Value == "New")
            {
                contextMenuStrip1.Items[5].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[5].Enabled=false;
            }
        }
        private void _SetCMSScheduleTest()
        {
            if ((string)dgvApplicationList.CurrentRow.Cells[6].Value == "New")
            {
                contextMenuStrip1.Items[7].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[7].Enabled = false;
            }
            if ((int)dgvApplicationList.CurrentRow.Cells[5].Value == 3)
            {
                contextMenuStrip1.Items[7].Enabled = false;
            }
        }
        private void _SetCMSIssueDrivingLicenseFirstTime()
        {
            if ((int)dgvApplicationList.CurrentRow.Cells[5].Value == 3)
            {
                contextMenuStrip1.Items[9].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[9].Enabled = false;
            }
            if ((string)dgvApplicationList.CurrentRow.Cells[6].Value == "Completed")
            {
                contextMenuStrip1.Items[9].Enabled=false;
            }
        }
        private void _SetCMSShowLicense()
        {
            if ((string)dgvApplicationList.CurrentRow.Cells[6].Value == "Completed")
            {
                contextMenuStrip1.Items[11].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items[11].Enabled = false;
            }
        }

      
        private void _FilterByLDLAppID()
        {
            int.TryParse(tbxFilterItem.Text, out int ID);
            DataView dv = new DataView(TableContainAllApplications);
            dv.RowFilter ="LDLAppID=" + ID;
            //dv.RowFilter = string.Format("LDLAppID like '%{0}%'", tbxFilterItem.Text);
            dgvApplicationList.DataSource = dv;
            lblRecords.Text=dv.Count.ToString();
        }
        private void _FilterByFullName()
        {
            DataView dv = new DataView(TableContainAllApplications);
            dv.RowFilter =string.Format( "FullName like '%{0}%'",tbxFilterItem.Text);
            dgvApplicationList.DataSource = dv;
            lblRecords.Text = dv.Count.ToString();

        }
        private void _FilterByNationalNumber()
        {
            DataView dv=new DataView(TableContainAllApplications);
            dv.RowFilter = string.Format("NationalNo like '%{0}%'",tbxFilterItem.Text);
            dgvApplicationList.DataSource= dv;
            lblRecords.Text = dv.Count.ToString();

        }
        private void _FilterByStatus()
        {
            DataView dv=new DataView(TableContainAllApplications);
            dv.RowFilter = string.Format("Status like '%{0}%'", tbxFilterItem.Text);
            dgvApplicationList.DataSource=dv;
        }

        private void _RefreshList()
        {

            switch (cbxFilterBy.SelectedIndex)
            {
                case 1:
                    _FilterByLDLAppID();
                    break;

                case 3:
                    _FilterByFullName();
                    break;
                case 2:
                    _FilterByNationalNumber();
                    break;
                case 4:
                    _FilterByStatus();
                    break;
            }

        }
        private void _TableSettings()
        {
            TableContainAllApplications = LDLApp.GetAllLDLApps();

        }

        private void _LoadApplicationList()
        {
            
            _TableSettings();
            cbxFilterBy.SelectedIndex = 0;

            DataView dataView = new DataView(TableContainAllApplications);
            dgvApplicationList.DataSource = dataView;
            dgvApplicationList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvApplicationList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cbxFilterBy.SelectedIndex = 0;
            tbxFilterItem.Text = string.Empty;
            lblRecords.Text=dataView.Count.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Local_Driving_License_Applications_Load(object sender, EventArgs e)
        {
            
            _LoadApplicationList();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            New_Local_Driving_license_Application frm = new New_Local_Driving_license_Application();
            frm.ShowDialog();
            _LoadApplicationList();
        }

        private void cbxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(cbxFilterBy.SelectedIndex == 0)
            {
                tbxFilterItem.Visible = false;
            }
            else
            {
                tbxFilterItem.Visible = true;
                tbxFilterItem.Focus();
            }

        }

        private void tbxFilterItem_TextChanged(object sender, EventArgs e)
        {
            
            _RefreshList();
        }

        private void tbxFilterItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxFilterBy.SelectedIndex == 1)
            {
                e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
            }
        }

        private void cbxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(
            MessageBox.Show("Are you sure you want to cancel this " +
                "application ?","Cancel Confirmation",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)==
                DialogResult.Yes)
            {
                LDLApp ldlapp = LDLApp.FindLDLApp((int)dgvApplicationList.CurrentRow.Cells[0].Value);
                if (clsOrders.CancelApplication(ldlapp.AppID))
                {
                    _LoadApplicationList();
                    MessageBox.Show("Application cancelled successfully",
                        "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Application not cancelled successfully",
                        "not Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vision_Test_Appointment frm = new Vision_Test_Appointment((int)dgvApplicationList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadApplicationList();
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            _SetCMSEditApplication();
            _SetCMSDeleteApplication();
            _SetCMSCancellApplication();
            _SetCMSScheduleTest();
            _SetCMSIssueDrivingLicenseFirstTime();
            _SetCMSShowLicense();
        }

        private void scheduleTestToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            if ((int)dgvApplicationList.CurrentRow.Cells[5].Value == 0)
            {
                scheduleTestToolStripMenuItem.DropDownItems[0].Enabled = true;
                scheduleTestToolStripMenuItem.DropDownItems[2].Enabled = false;
                scheduleTestToolStripMenuItem.DropDownItems[4].Enabled = false;

            }
            if ((int)dgvApplicationList.CurrentRow.Cells[5].Value == 1)
            {
                scheduleTestToolStripMenuItem.DropDownItems[0].Enabled = false;
                scheduleTestToolStripMenuItem.DropDownItems[2].Enabled = true;
                scheduleTestToolStripMenuItem.DropDownItems[4].Enabled = false;
            }
            if ((int)dgvApplicationList.CurrentRow.Cells[5].Value == 2)
            {
                scheduleTestToolStripMenuItem.DropDownItems[0].Enabled = false;
                scheduleTestToolStripMenuItem.DropDownItems[2].Enabled = false;
                scheduleTestToolStripMenuItem.DropDownItems[4].Enabled = true;
            }
            if ((int)dgvApplicationList.CurrentRow.Cells[5].Value == 3)
            {
                scheduleTestToolStripMenuItem.DropDownItems[0].Enabled = false;
                scheduleTestToolStripMenuItem.DropDownItems[2].Enabled = false;
                scheduleTestToolStripMenuItem.DropDownItems[4].Enabled = false;
            }

        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WrittenTestAppointment frm = new WrittenTestAppointment((int)dgvApplicationList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadApplicationList();

        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Street_Test_Appointment frm = new Street_Test_Appointment((int)dgvApplicationList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadApplicationList();
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Issue_Driving_License_First_Time frm = new Issue_Driving_License_First_Time(
                (int)dgvApplicationList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadApplicationList();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DrivingLicenseInfo frm = new DrivingLicenseInfo((int)dgvApplicationList
                .CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsPerson.GetPersonIDUsingNationalNumber((string)dgvApplicationList.CurrentRow.Cells[2].Value, ref _PersonID))
            {
                PersonLicensesHistory frm = new PersonLicensesHistory(_PersonID);
                frm.ShowDialog();
            }

        }
    }
}
