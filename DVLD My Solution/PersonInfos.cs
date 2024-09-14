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
    public partial class PersonInfos : UserControl
    {
        public int _ID;
        public bool IsFound;
        
        public PersonInfos()
        {

            InitializeComponent();
            
           

        }
        public void LoadPersonInfo(int ID)
        {
            this._ID = ID;
            clsPerson _Person = clsPerson.FindPerson(ID);
            if (_Person != null)
            {
                IsFound = true;
                lblName.Text = _Person.FullName;
                lblPersonID.Text = _Person.ID.ToString();
                lblNationalNumber.Text = _Person.NationalNumber;
                lblEmail.Text = _Person.Email;
                lblPhone.Text = _Person.Phone;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToString("dd - MM - yyyy");
                if (_Person.Gender == 0)
                {
                    lblGender.Text = "Female";
                }
                else
                {
                    lblGender.Text = "Male";
                }
                lblCountry.Text = clsCountriesBussinessLayer.GetCountryName(_Person.NationalityCountryID);
                lblAddress.Text = _Person.Address;
                if (_Person.ImagePath != null)
                {
                    picBoxPesonImage.ImageLocation = _Person.ImagePath;
                    // picBoxPesonImage.Load(_Person.ImagePath);
                }
            }
            else
            {
                MessageBox.Show("Person Not found");
                IsFound = false;
                
            }
        }
        public void LoadPersonInfo(string NationalNumber)
        {
            //this._ID = ID;
            
            clsPerson _Person = clsPerson.FindPerson(NationalNumber);
            if (_Person != null)
            {
                IsFound = true;
                this._ID=_Person.ID;
                lblName.Text = _Person.FullName;
                lblPersonID.Text = _Person.ID.ToString();
                lblNationalNumber.Text = _Person.NationalNumber;
                lblEmail.Text = _Person.Email;
                lblPhone.Text = _Person.Phone;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToString("dd - MM - yyyy");
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
                    picBoxPesonImage.ImageLocation = _Person.ImagePath;
                    // picBoxPesonImage.Load(_Person.ImagePath);
                }
            }
            else
            {
                MessageBox.Show("Person Not found");
                IsFound=false;
            }
        }

        private void linklblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditPersons frm = new AddEditPersons("Update Person");
            frm.PersonID = _ID;
            frm.ShowDialog();
            
        }
    }
}
