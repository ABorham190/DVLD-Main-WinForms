using DVDLBussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_My_Solution
{
    public partial class PersonInfo : UserControl
    {
        clsPerson _Person;
        public PersonInfo()
        {
            InitializeComponent();
            
        }
        public void LoadPersonInfo()
        {
            //clsPerson _Person = clsPerson.FindPerson();
            if (_Person != null)
            {

                lblName.Text = _Person.FullName;
                lblPersonID.Text = _Person.ID.ToString();
                lblNationalNumber.Text = _Person.NationalNumber;
                lblEmail.Text = _Person.Email;
                lblPhone.Text = _Person.Phone;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
                if (_Person.Gender == 0)
                {
                    lblGender.Text = "Female";
                }
                else
                {
                    lblGender.Text = "Male";
                }
                lblCountry.Text = _Person.Country;
                lblAddress.Text = _Person.Address;
                if (_Person.ImagePath != null)
                {
                    //picBoxPesonImage.ImageLocation = _Person.ImagePath;
                    // picBoxPesonImage.Load(_Person.ImagePath);
                }
            }
            else
            {
                MessageBox.Show("Person Not found");
            }
        }

       

        private void PersonInfo_Load(object sender, EventArgs e)
        {

            
        }
    }
}
