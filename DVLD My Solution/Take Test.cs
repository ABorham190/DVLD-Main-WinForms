using DVDLBussinessLayer;
using DVLD_My_Solution.Properties;
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
    public partial class Take_Test : Form
    {
        clsAppointments Appointment=new clsAppointments();
        GeneralStructs TakeTestDetails = new GeneralStructs();
        clsTests Test=  new clsTests();
        int _AppointmentID = 0;
        int _TestTrials = 0;
        enum enTestType { enVisionTest = 1, enWrittenTest = 2, enStreetTest = 3 }
        enTestType _TestType;
        //enum enWhatToDo { TakeTest=0,RetakeTest=1};
        //enWhatToDo WhatToDo;
        public Take_Test(int appointmentID,int testtypeid)
        {
            InitializeComponent();
            _AppointmentID = appointmentID;
            _TestType = (enTestType)testtypeid;
        }
        private void _SetTestType()
        {
            switch (_TestType)
            {
                case enTestType.enVisionTest:
                    gbxTestType.Text = "Vission Test";

                    break;
                case enTestType.enWrittenTest:
                    gbxTestType.Text = "Written Test";
                    picBoxTestImage.Image = Resources.Written_Test_512;
                    break;
                case enTestType.enStreetTest:
                    gbxTestType.Text = "Street Test";
                    picBoxTestImage.Image = Resources.Street_Test_32;
                    break;
            }
        }
        private void _LoadInfo()
        {
            
            if(clsAppointments.GetTakeTestDetails(_AppointmentID,ref TakeTestDetails))
            {
                lblDLAppID.Text=TakeTestDetails.DLAppID.ToString();
                lblDate.Text=TakeTestDetails.Date.ToString();
                lblFees.Text=TakeTestDetails.Fees.ToString();
                lblLicenseClass.Text=TakeTestDetails.ClassName.ToString();
                lblName.Text=TakeTestDetails.ApplicantName.ToString();
                _TestTrials = clsTests.GetNumberOfFailedTests(TakeTestDetails.DLAppID,(int)_TestType);
                lblTrial.Text=(_TestTrials+1).ToString();
            }
            //lblDLAppID.Text = Appointment.DLAppID.ToString();
            
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Take_Test_Load(object sender, EventArgs e)
        {
            _SetTestType();
            _LoadInfo();
        }

        private void _LoadTestInfoToObject()
        {
           Test.TestAppointmentID = _AppointmentID;
            if(rbtnFail.Checked)
            {
                Test.TestResult = false;
            }
            else
            {
                Test.TestResult= true;
            }
            Test.Notes=tbxNotes.Text;
            Test.CreatedByUserID=Globals.CurrentUser.UserID;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to record this test record?"
                    , "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _LoadTestInfoToObject();
                if (Test.AddNewTakenTest())
                {


                    MessageBox.Show("Test Result Confirmed Successfully");

                    lblTestID.Text=Test.TestID.ToString();
                    if (!clsAppointments.LockAppointment(_AppointmentID))
                    {
                        MessageBox.Show("Appointment NOT locked successfully",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Test Result NOT Confirmed Successfully");

                }
            }
            else
            {
                MessageBox.Show("Cancelled operation!!");
            }
            this.Close();
        }
    }
}
