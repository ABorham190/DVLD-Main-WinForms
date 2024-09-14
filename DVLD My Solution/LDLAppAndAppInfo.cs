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
    public partial class LDLAppAndAppInfo : UserControl
    {
        LDLApp ldlicenseapp =new LDLApp();
        clsOrders Order=new clsOrders();
        public string LicenseType = "";
        Decimal ApplicationFees = 0;
        string ServiceName = "";
        public string ApplicantFullName = "";
        public int TestNameID = 0;
        public int ApplicationID = 0;
        public int LicenseClassID = 0;
        public LDLAppAndAppInfo()
        {
            InitializeComponent();
        }
        //Done
        private void _GetLicenseType()
        {
            if (clsLicenses.GetLicenseClass(ldlicenseapp.LicenseTypeID, ref LicenseType))
            {
                lblLicenseName.Text = LicenseType;
            }
        }

        private void GetLDLAppAndAppObject(int LDLAppID )
        {
            //Done
            ldlicenseapp = LDLApp.FindLDLApp(LDLAppID);

            Order = clsOrders.FindOrder(ldlicenseapp.AppID);


        }

        //Done
        private void _GetServiceNameAndFees()
        {
            if(clsOrders.GetServiceNameAndApplicationFees(Order.ApplicationTypeID,ref ApplicationFees,ref ServiceName))
            {
                lblFees.Text = ApplicationFees.ToString();
                lblType.Text= ServiceName.ToString();
            }
        }
        //Done
        private void _GetApplicantFullName()
        {
            if(clsPerson.GetFullName(Order.ApplicantID,ref ApplicantFullName))
            {
                lblApplicant.Text = ApplicantFullName.ToString();
            }
        }
       
        public void LoadInfo(int LDLAppID)
        {
            GetLDLAppAndAppObject(LDLAppID);
            ApplicationID = Order.ApplicationID;
            LicenseClassID = ldlicenseapp.LicenseTypeID;
            
            _GetLicenseType();
            lblDLAppID.Text = ldlicenseapp.LDLAppID.ToString();
            
            lblPassedTests.Text = clsTestTypes.GetPassedTests(ldlicenseapp.LDLAppID).ToString() + "/3"; 
            

            //App Info text box

            lblAppID.Text=Order.ApplicationID.ToString();
            //string Status = "";
            
                lblStatus.Text = Order.AppStatus;
            
            _GetServiceNameAndFees();
            _GetApplicantFullName();

            lblStatusDate.Text=Order.ApplicationDate.ToString("dd - MM - yyyy");
            lblDate.Text = DateTime.Now.ToString("dd - MM - yyyy");
            lblCreatedBy.Text = Globals.CurrentUser.UserName;


        }
      

        public void LoadUserControlData()
        {
            LinklblShowLicenseDetails.Enabled = false;

        }

        private void llabelViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Person_Details frm = new Person_Details(Order.ApplicantID);
            frm.ShowDialog();
        }
    }
}
