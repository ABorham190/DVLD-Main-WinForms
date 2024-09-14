using DVDLBussinessLayer;
using DVLD_My_Solution;
using DVLD_My_Solution.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDdataAccessLayer
{
    public partial class ScheduleTest2 : Form
    {
        int _DLAppID = 0;
        string _ClassTypeName = "";
        string _Name = "";
        int _TestTrials = 0;
        DateTime _Date = DateTime.MinValue;
        Decimal _TestFees = 0;
        Decimal _RetakeTestAppFees = 0;
        Decimal _TotalFees = 0;
        int _RetakeTestAppID = 0;
        string _Word = "";
        int _AppointmentID = 0;
        clsAppointments Appointment;
        clsOrders _RetakeApp=new clsOrders();
        enum enTestType { WrittenTest = 2, StreetTest = 3 }
        enTestType _TestType;
        enum enWhatToDo { takeTest = 1, RetakeTest = 2 };
        enWhatToDo _WhatToDo;

        enum enMode { enAddNewApp = 1, enUpdateApp = 2 }
        enMode _AddOrUpdateAppointment;

        public ScheduleTest2(int ldlappid, int TestType, int WhatToDo,
            string licenseType, string fullname, int AddOrUpdate)
        {
            InitializeComponent();

            _DLAppID = ldlappid;
            _ClassTypeName = licenseType;
            _Name = fullname;

            _TestType = (enTestType)TestType;
            _WhatToDo = (enWhatToDo)WhatToDo;
            _AddOrUpdateAppointment = (enMode)AddOrUpdate;

        }
        public ScheduleTest2(int appointmentid,int ldlappid, int TestType, int WhatToDo,
            string licenseType, string fullname, int AddOrUpdate)
        {
            InitializeComponent();

            _AppointmentID = appointmentid;
            _DLAppID = ldlappid;
            _ClassTypeName = licenseType;
            _Name = fullname;
            _TestType = (enTestType)TestType;
            _WhatToDo = (enWhatToDo)WhatToDo;
            _AddOrUpdateAppointment = (enMode)AddOrUpdate;

        }
        private void _GetTestTrials()
        {
            _TestTrials = clsTests.GetNumberOfFailedTests(_DLAppID, (int)_TestType);
            lblTrial.Text = _TestTrials.ToString();
        }
        private void _GetTestFees()
        {
            _TestFees = clsTestTypes.GetTestFees((int)_TestType);
            lblFees.Text = _TestFees.ToString();
        }
        private void _LoadBasicFormInfo()
        {
            lblDLAppID.Text = _DLAppID.ToString();
            lblName.Text = _Name.ToString();
            lblLicenseClass.Text = _ClassTypeName;
            _GetTestTrials();
            _GetTestFees();
        }
        private void _TakeTestSettings()
        {
            lblFormHeader2.Visible= false;
            lblFormHeader1.Visible= true;
            gbxRetakeTestInfo.Enabled = false;
        }
        private void _UploadRetakeAppInfoToObject()
        {
            int ApplicantID = 0;
            _RetakeApp.ApplicationDate = DateTime.Now;
           if( clsPerson.GetPersonIDUsingLDLAppID(_DLAppID,ref ApplicantID))
            {
                _RetakeApp.ApplicantID = ApplicantID;
            }
            _RetakeApp.ApplicationTypeID = 7;
            _RetakeApp.ApplicationStatus = 1;
            _RetakeApp.LastStatusDate = DateTime.Now;
            _RetakeApp.CreatedByUserID=Globals.CurrentUser.UserID;
            _RetakeApp.PaidFees = _RetakeTestAppFees;

           
        }
        private void _RetakeTestSettings()
        {
            string ServiceName = "";
            lblFormHeader2.Visible= true;
            lblFormHeader1.Visible= false;
            gbxRetakeTestInfo.Enabled= true;
            _TestTrials++;
            lblTrial.Text=_TestTrials.ToString();
            if (clsOrders.GetServiceNameAndApplicationFees(7, ref _RetakeTestAppFees, ref ServiceName)) {
                lblRetakeTestAppFees.Text = _RetakeTestAppFees.ToString();
             }
            _TotalFees = _TestFees + _RetakeTestAppFees;

            lblTotalFees.Text = _TotalFees.ToString();

            _UploadRetakeAppInfoToObject();
        }
        private void _TakeAndRetakeSettings()
        {
            switch (_WhatToDo)
            {
                case enWhatToDo.takeTest:
                    _TakeTestSettings();
                    break;
                case enWhatToDo.RetakeTest:
                    _RetakeTestSettings();
                    break;
            }
        }
        private void _WrittenTestSettings()
        {
            gbxTestType.Text = "Written Test";
            picboxTestImage.Image = Resources.Written_Test_512;
        }
        private void _StreetTestSettings()
        {
            gbxTestType.Text = "Street Test";
            picboxTestImage.Image = Resources.Street_Test_32;
        }
        private void _SetTestType()
        {
            switch (_TestType)
            {
                case enTestType.WrittenTest:
                    _WrittenTestSettings();
                    break;
                case enTestType.StreetTest:
                    _StreetTestSettings();
                    break;

                    

            }
        }

        private void _AddNewAppointmentSettings()
        {
            Appointment = new clsAppointments();

            Appointment.TestTypeID =(int) _TestType;
            Appointment.DLAppID = _DLAppID;
            Appointment.AppointmentDate=DateTime.Now;
            Appointment.PaidFees = _TestFees;
            Appointment.CreatedByUserID=Globals.CurrentUser.UserID;
            Appointment.IsAppointmentLocked = false;
            Appointment.RetakeTestAppID = _RetakeTestAppID;
            _Word = "Added";

        }
        private void _EditAppointmentSettings()
        {
            Appointment = clsAppointments.Find(_AppointmentID);
            if(Appointment != null)
            {
                Appointment.AppointmentDate = DTPTestDate.Value;
            }
            _Word = "Updated";
        }

        private void _AddNewOrUpdateSettings()
        {
            switch (_AddOrUpdateAppointment)
            {
                case enMode.enAddNewApp:
                    _AddNewAppointmentSettings();

                    break;
                case enMode.enUpdateApp:
                    _EditAppointmentSettings();
                    break;
            }
        }


        private void _TotalFormSetting()
        {
                _LoadBasicFormInfo();
                _TakeAndRetakeSettings();
                _SetTestType();

        }


            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void ScheduleTest2_Load(object sender, EventArgs e)
            {
                _TotalFormSetting();
            }

        private void _SaveRetakeTestApplicationToApplications()
        {
            if (!_RetakeApp.Save())
            {
                MessageBox.Show("Retake Test App Not saved Successfully"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
            lblRetakeTestAppID.Text = _RetakeApp.ApplicationID.ToString();
            _RetakeTestAppID = _RetakeApp.ApplicationID;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_WhatToDo == enWhatToDo.RetakeTest)
            {
                _SaveRetakeTestApplicationToApplications();
            }
            _AddNewOrUpdateSettings();
            if (Appointment.Save())
            {
                MessageBox.Show("Appointment " + _Word + " Successfully",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Appointment Not " + _Word + " Successfully",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
    }


