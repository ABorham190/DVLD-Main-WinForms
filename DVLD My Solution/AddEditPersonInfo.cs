using DVDLBussinessLayer;
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
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_My_Solution
{
    public partial class AddEditPersonInfo : UserControl
    {
       public clsPerson Person=new clsPerson();
        string _FileName = "";
        public int _ID ;
        enum enMode { AddNew=0,Update=1};
        //enMode _Mode = enMode.AddNew;
        public AddEditPersonInfo()
        {
            InitializeComponent();
        }
        public AddEditPersonInfo(int PersonID)
        {
            InitializeComponent();
            _ID = PersonID;
           

        }

        private void _LoadCountriesTocbxCountries()
        {
            DataTable dt = clsCountriesBussinessLayer.GetAllCountries();
            
            

            foreach(DataRow row in dt.Rows)
            {
                cbxCountries.Items.Add(row["CountryName"]);
            }

            cbxCountries.SelectedItem = "Egypt";
        }

       
       
       
        public void _LoadUserControlData()
        {
            
            rbtnMale.Checked = true;
            DTPickerDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            picBoxPersonImage.InitialImage = Resources.man;
            
        }
        private void _LoadGender(int Gender)
        {
            if(Gender == 0)
            {
                rbtnFemale.Checked = true;
            }
            else
            {
                rbtnMale.Checked = true;
            }
        }
        public void _LoadPersonIfosToUserControl(int ID)
        {
            Person = clsPerson.FindPerson(ID);
            if (Person != null)
            {
                lblPersonID.Text=ID.ToString();
                tbxFirstName.Text = Person.FirstName;
                tbxLastName.Text = Person.LastName;
                tbxSecondName.Text = Person.SecondName;
                tbxThirdName.Text = Person.ThirdName;
                tbxPhone.Text = Person.Phone;
                tbxEmail.Text = Person.Email;
                tbxAddress.Text = Person.Address;
                
                tbxNationalNumber.Text = Person.NationalNumber;
                _LoadGender(Person.Gender);
                DTPickerDateOfBirth.Text = Person.DateOfBirth.ToString();
                
                if(Person.ImagePath != null)
                {
                    picBoxPersonImage.ImageLocation=Person.ImagePath;
                }
                else
                {
                    if (rbtnMale.Checked)
                    {
                        picBoxPersonImage.Image=Resources.man;
                    }
                    else
                    {
                        picBoxPersonImage.Image = Resources.Woman2;
                    }
                }

                cbxCountries.SelectedIndex = (Person.NationalityCountryID - 1);
            }
        }

        private void AddEditPersonInfo_Load(object sender, EventArgs e)
        {
            _LoadCountriesTocbxCountries();
            //_LoadUserControlData();
        }
       

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            picBoxPersonImage.Image = Resources.man;
        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            picBoxPersonImage.Image = Resources.Woman2;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory=@"E:\";
            openFileDialog1.Title = "Choose a photo";
            openFileDialog1.DefaultExt = "JPG";
            openFileDialog1.Filter = "JPG files (*.JPG)|*.JPG|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
            {

                picBoxPersonImage.Load(openFileDialog1.FileName);
                _FileName= openFileDialog1.FileName;
               // picBoxPersonImage.Image.Save("Persons Images"+"E:\\programming main\\Course 19"+openFileDialog1.FileName);
               
                

            }
        }

       private bool _CheckNecessaryFields()
        {
            if (tbxFirstName.Text == "")
            {
                return true;
            }
            if(tbxLastName.Text == "")
            {
                return true;
            }
            if (tbxSecondName.Text == "")
            {
                return true;
            }
            if( tbxThirdName.Text == "")
            {
                return true;
            }
            if (tbxPhone.Text == "")
            {
                return true;
            }
            if (tbxAddress.Text == "")
            {
                return true;
            }
            //if (tbxCountry.Text == "")
            //{
            //    return true;
            //}
            if (tbxNationalNumber.Text == "")
            {
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_CheckNecessaryFields())
            {
                MessageBox.Show("You must fill all neccessary fields",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to add this person?",
                "Add Person Confirmation", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Person._Mode == clsPerson.enMode.enAddNewMode)
                {
                    if (clsPerson.IsPersonExistsInSystem(tbxNationalNumber.Text))
                    {
                        MessageBox.Show("Person have this national number " +
                            "already exists on the system!!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Person=new clsPerson();
                if (rbtnFemale.Checked)
                {
                    Person.Gender = 0;
                }
                else
                {
                    Person.Gender = 1;
                }
                Person.FirstName = tbxFirstName.Text.ToString();
                Person.SecondName = tbxSecondName.Text.ToString();
                Person.ThirdName = tbxThirdName.Text.ToString();
                Person.LastName = tbxLastName.Text.ToString();
                Person.NationalNumber = tbxNationalNumber.Text.ToString();
                Person.Email = tbxEmail.Text.ToString();
                Person.Address = tbxAddress.Text.ToString();
                Person.DateOfBirth = (DateTime)DTPickerDateOfBirth.Value;
                Person.Phone = tbxPhone.Text.ToString();
                //Person.Country = tbxCountry.Text.ToString();
                Person.NationalityCountryID = cbxCountries.SelectedIndex + 1;
                if (Person._Mode == clsPerson.enMode.enAddNewMode)
                {
                    if (_FileName != "")
                    {
                        Person.ImagePath = picBoxPersonImage.ImageLocation;

                    }
                    else
                    {
                        Person.ImagePath = "";
                    }
                }
                else
                {
                    Person.ImagePath = picBoxPersonImage.ImageLocation;
                }


                if (Person.Save())
                {
                    lblPersonID.Text = Person.ID.ToString();
                    _ID = Person.ID;

                    MessageBox.Show("Person Saved successfully");
                    
                    
                }
                else
                {
                    MessageBox.Show("Person not saved successfully");
                }
            }
            else
            {
                MessageBox.Show("Cancelled Operation!");
            }
        }

        private void tbxNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if (clsPerson.IsPersonExistsInSystem(tbxNationalNumber.Text))
            {
                errorProvider1.SetError(tbxNationalNumber,"This National number already exists in system");
                tbxNationalNumber.Focus();
            }
        }

        private void cbxCountries_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private bool IsEmailFormatCorrect()
        {
            int count = 0;
            for(int i=0;i<tbxEmail.Text.Length;i++)
            {
                if (tbxEmail.Text[i] == '@')
                {
                    count++;
                }
            }
            if(count==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void tbxEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!IsEmailFormatCorrect())
            {
                errorProvider1.SetError(tbxEmail, "Invalid Email Format");
                tbxEmail.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
