using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_My_Solution
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Test(4046));
            //Application.Run(new Main());
            //Application.Run(new Add_New_User());
            //Application.Run(new UserDetails());
            //Application.Run(new ChangePassword(1));
            Application.Run(new LogIn_Screen());
            //Application.Run(new WrittenTestAppointment(37));
            //Application.Run(new PersonLicensesHistory());
            //Application.Run(new Manage_Application_Types());
            //Application.Run(new Manage_Tests());
            // Application.Run(new New_Local_Driving_license_Application());
            //Application.Run(new Local_Driving_License_Applications ());
            //Application.Run(new Vision_Test_Appointment(2004));
            //Application.Run(new ScheduleTest());
            //Application.Run(new Take_Test(1));
           // Application.Run(new NewInternationalLicenseApplication());



        }
    }
}
