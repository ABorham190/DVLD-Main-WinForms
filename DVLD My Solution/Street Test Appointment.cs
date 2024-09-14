using DVDLBussinessLayer;
using DVLDdataAccessLayer;
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
    public partial class Street_Test_Appointment : Form
    {
        DataTable TableContailAllStreetTestAppointments = new DataTable();
        int _LDLAppID = 0;
        enum enTakeOrRetake { TakeTest = 1, RetakeTest = 2 };
        enTakeOrRetake _WhatToDo;
        enum enAddNewOrUpdateApp { AddNewApp = 1, UpdateApp = 2 };
        enAddNewOrUpdateApp _AddOrUpdate;

        int _TestTypeID = 3;
        public Street_Test_Appointment(int ldlappid)
        {
            InitializeComponent();
            _LDLAppID=ldlappid;
        }
        private void _RefreshAppointmentsList()
        {
            TableContailAllStreetTestAppointments =
                clsAppointments.GetAllStreetAppointments(_LDLAppID);

            DataView dv = new DataView(TableContailAllStreetTestAppointments);
            dgvStreetTestAppointmentsList.DataSource = dv;
            lblRecords.Text = dv.Count.ToString();

        }

        private void Street_Test_Appointment_Load(object sender, EventArgs e)
        {
            ldlAppAndAppInfo1.LoadInfo(_LDLAppID);
            _RefreshAppointmentsList();
        }

        private void btnAddVisionTestAppointment_Click(object sender, EventArgs e)
        {
            if (clsAppointments.IsThisLDAppIDPassedTest(_LDLAppID, _TestTypeID))
            {
                MessageBox.Show("This applicant Already passed Street test !!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int AppointmentID = 0;
            if (clsAppointments.IsThisLDAppIDHasAnyActiveAppointments(_LDLAppID, _TestTypeID, ref AppointmentID))
            {
                MessageBox.Show("This applicant already has an active appointment with ID = " + AppointmentID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsAppointments.IsThereAnyAppointmentsForThisLDLAppID(_LDLAppID, _TestTypeID))
            {
                _WhatToDo = enTakeOrRetake.RetakeTest;
            }
            else
            {
                _WhatToDo = enTakeOrRetake.TakeTest;
            }
            _AddOrUpdate = enAddNewOrUpdateApp.AddNewApp;
            ScheduleTest2 frm = new ScheduleTest2(_LDLAppID, _TestTypeID, (int)_WhatToDo
                , ldlAppAndAppInfo1.LicenseType, ldlAppAndAppInfo1.ApplicantFullName, (int)_AddOrUpdate);
            frm.ShowDialog();
            _WhatToDo = enTakeOrRetake.TakeTest;
            _RefreshAppointmentsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddOrUpdate = enAddNewOrUpdateApp.UpdateApp;
            DataView dv = new DataView(TableContailAllStreetTestAppointments);
            if (dv.Count > 1)
            {
                _WhatToDo = enTakeOrRetake.RetakeTest;
            }
            else
            {
                _WhatToDo = enTakeOrRetake.TakeTest;
            }
            ScheduleTest2 frm = new ScheduleTest2((int)dgvStreetTestAppointmentsList.
                CurrentRow.Cells[0].Value, _LDLAppID, _TestTypeID, (int)_WhatToDo
                , ldlAppAndAppInfo1.LicenseType, ldlAppAndAppInfo1.ApplicantFullName, (int)_AddOrUpdate);
            frm.ShowDialog();
            _RefreshAppointmentsList();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Take_Test frm = new Take_Test((int)dgvStreetTestAppointmentsList.
               CurrentRow.Cells[0].Value, _TestTypeID);
            frm.ShowDialog();
            _RefreshAppointmentsList();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if ((bool)dgvStreetTestAppointmentsList.CurrentRow
               .Cells[3].Value == true)
            {
                contextMenuStrip1.Items[0].Enabled = false;
                contextMenuStrip1.Items[1].Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
