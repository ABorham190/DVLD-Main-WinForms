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
    public partial class ScheduleTest : Form
    {
        clsAppointments TestAppointment;
        clsTestTypes vtest;
        clsOrders RetakeApp;
        
        int _DLAppID = 0;
        string _DClass = "";
        string _Name = "";
        int _Trial = 0;
        Decimal _TestFees = 0;
        bool _IsLocked=false;
        int _RetakeTestAppID = 0;
        Decimal _RetakeTestAppFees = 0;
        string _ServiceName = "";
        Decimal _TotalFees = 0;
        string _WhatToDo;
        int _ApplicantID = 0;

        enum enMode { AddNew=0,Update=1};
        enMode _Mode;
        

        public ScheduleTest(int dlappID,string dclass,string name,string whattodo="")
        {
            InitializeComponent();
            _DLAppID=dlappID;
            _DClass=dclass;
            _Name=name;
            _WhatToDo=whattodo;
            _Mode=enMode.AddNew;
            
            
        }
        public ScheduleTest(int AppointmentID,int dlappID, string dclass, string name, bool isLocked,string whattodo="")
        {

            InitializeComponent();
            _Mode = enMode.Update;
            _DLAppID = dlappID;
            _DClass = dclass;
            _Name = name;

            TestAppointment = clsAppointments.Find(AppointmentID);
            _IsLocked = isLocked;
        }

        private void _GetTestFees()
        {
            if ((vtest=clsTestTypes.FindTestByID(1)) != null)
            {
                _TestFees = vtest.Fees;
                
                lblFees.Text=_TestFees.ToString();
            }
        }
        private void _GetTrials()
        {
            _Trial = clsTestTypes.GetTrials(_DLAppID);
            if (_Mode == enMode.AddNew)
            {
                lblTrial.Text = (_Trial+1).ToString();
            }
            else
            {
                lblTrial.Text=_Trial.ToString();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _RetakeTestSettings()
        {
            gbxRetakeTestInfo.Enabled = true;
            if (clsOrders.GetServiceNameAndApplicationFees(7, ref _RetakeTestAppFees, ref _ServiceName)) {
                lblRetakeTestAppFees.Text = _RetakeTestAppFees.ToString();
            }
            _TotalFees = _TestFees + _RetakeTestAppFees;
            lblTotalFees.Text = _TotalFees.ToString();
            lblFormHeader.Text = "Schedule Retake Test";
            
            RetakeApp = new clsOrders();
          
        }
        private void _UploadRetakeAppInfoToObject()
        {
            RetakeApp.ApplicationDate = DTPTestDate.Value;
            RetakeApp.ApplicationStatus = 1;
            if (clsPerson.GetPersonIDUsingLDLAppID(_DLAppID, ref _ApplicantID))
                RetakeApp.ApplicantID = _ApplicantID;
            RetakeApp.ApplicationTypeID = 7;
            RetakeApp.CreatedByUserID=Globals.CurrentUser.UserID;
            RetakeApp.LastStatusDate = DTPTestDate.Value;
            RetakeApp.PaidFees = 5;
        }
        private void _LoadInfo()
        {

            gbxRetakeTestInfo.Enabled = false;
            //DTPTestDate.MinDate = DateTime.Now;
            lblDLAppID.Text= _DLAppID.ToString();
            lblLicenseClass.Text= _DClass;
            lblName.Text= _Name;
            _GetTestFees();
            _GetTrials();
            if (_WhatToDo == "Retake")
                _RetakeTestSettings();

            if (_Mode == enMode.AddNew)
            {
                DTPTestDate.Value = DateTime.Now;
            }
            else
            {
                //DTPTestDate.MinDate = DateTime.MinValue;
                DTPTestDate.Value = TestAppointment.AppointmentDate;
            }
            if(_IsLocked==true)
            {
                DTPTestDate.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                DTPTestDate.Enabled= true;
                btnSave.Enabled= true;
            }
            
        }

        private void ScheduleTest_Load(object sender, EventArgs e)
        {
            _LoadInfo();
        }

        private void _LoadAppointmentDataToObject()
        {
            TestAppointment=new clsAppointments();
            TestAppointment.DLAppID = _DLAppID;
            TestAppointment.TestTypeID = 1;
            TestAppointment.AppointmentDate =(DateTime) DTPTestDate.Value;
            //TestAppointment.IsPassed = 0;
            TestAppointment.IsLocked = 0;
            TestAppointment.PaidFees = _TestFees;
            
            TestAppointment.CreatedByUserID=Globals.CurrentUser.UserID;
            if(_WhatToDo == "Retake")
            {
                _LoadRetakeTestAppIDToAppointmentObject();
            }
        }
        private void _LoadRetakeTestAppIDToAppointmentObject()
        {
            TestAppointment.RetakeTestAppID = RetakeApp.ApplicationID;
            lblRetakeTestAppID.Text = RetakeApp.ApplicationID.ToString();
        }
        private void _LoadAppointmentDateToObject()
        {
            TestAppointment.AppointmentDate=DTPTestDate.Value;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            string WhatToDo = "";
            switch (_Mode)
            {
                case enMode.AddNew:
                    _LoadAppointmentDataToObject();
                    WhatToDo = "added";
                    break;

                case enMode.Update:
                    _LoadAppointmentDateToObject();
                    WhatToDo = "updated";
                    break;

            }

            if (_WhatToDo == "Retake")
            {
                _UploadRetakeAppInfoToObject();
                if (!RetakeApp.Save())
                {
                    MessageBox.Show("Retake Test Application not" +
                        "Saved successfully", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                _LoadRetakeTestAppIDToAppointmentObject();
            }
            
            if (TestAppointment.Save())
            {
                
                MessageBox.Show("Appointment "+WhatToDo+" Successfully", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
                
            }
            else
            {
                MessageBox.Show("Appointment Not "+WhatToDo+" Added Successfully", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



    }
}
