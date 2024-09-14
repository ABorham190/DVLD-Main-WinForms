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
    public partial class Vision_Test_Appointment : Form
    {
        DataTable TableContainAppoinments = new DataTable();
        int LDLAppID = 0;
        int _TestTypeID = 1;
        public Vision_Test_Appointment(int ldlappID)
        {
            InitializeComponent();
            LDLAppID=ldlappID;
        }
        private void _RefreshVisionAppointmentsList()
        {
            if (!clsAppointments.IsDLAppIDHasVisionAppointments(LDLAppID))
            {
                return;
            }
            TableContainAppoinments = clsAppointments.GetVisionAppointmentsForDLAppID(LDLAppID);
           
            DataView dataview = new DataView(TableContainAppoinments);
            
            dgvVisionTestAppointmentsList.DataSource = dataview;
           
            lblRecords.Text=dataview.Count.ToString();


        }

        private void Vision_Test_Appointment_Load(object sender, EventArgs e)
        {
            ldlAppAndAppInfo1.LoadInfo(LDLAppID);
           _RefreshVisionAppointmentsList();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddVisionTestAppointment_Click(object sender, EventArgs e)
        {

            if (clsAppointments.IsDLAppHasAnyActiveVissionAppointments(LDLAppID))
            {
                MessageBox.Show("There is already active appointment for this Applicant", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (clsAppointments.IsThisDLAppIDPassVisionTest(LDLAppID))
            {
                MessageBox.Show("This Applicant already pass vision test",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsAppointments.IsThereVisionAppointmentsForThisDLAppID(LDLAppID))
            {
                ScheduleTest frm1 = new ScheduleTest(LDLAppID,
                   ldlAppAndAppInfo1.LicenseType,
                   ldlAppAndAppInfo1.ApplicantFullName);

                frm1.ShowDialog();
                _RefreshVisionAppointmentsList();
                return;

            }

            ScheduleTest frm = new ScheduleTest(LDLAppID,
                   ldlAppAndAppInfo1.LicenseType,
                   ldlAppAndAppInfo1.ApplicantFullName,"Retake");

            frm.ShowDialog();
            _RefreshVisionAppointmentsList();
            return;



        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScheduleTest frm = new ScheduleTest((int)dgvVisionTestAppointmentsList.CurrentRow.Cells[0].Value,
                LDLAppID, ldlAppAndAppInfo1.LicenseType, ldlAppAndAppInfo1.ApplicantFullName,
                (bool)dgvVisionTestAppointmentsList.CurrentRow.Cells[3].Value);
            
            frm.ShowDialog();
            _RefreshVisionAppointmentsList();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Take_Test frm = new Take_Test((int)dgvVisionTestAppointmentsList.CurrentRow.Cells[0].Value,_TestTypeID);
            frm.ShowDialog();
            _RefreshVisionAppointmentsList();
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if ((bool)dgvVisionTestAppointmentsList.CurrentRow.Cells[3].Value == true)
            {
                contextMenuStrip1.Items[1].Enabled = false;
            }
        }
    }
}
