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
    public partial class personFilter : UserControl
    {
        enum enFilterMode { enNationalNumber=0,enPersonID=1}

        public clsPerson Person;
        public int ID = -1;
        public personFilter()
        {
            InitializeComponent();
        }
        

        public void LoadPersonInfoToPersonInfosControl(int ID)
        {
            groupBox1.Enabled = false;
            personInfos1.LoadPersonInfo(ID);
            this.ID = ID;
        }

        private void LoadUserControlInfo()
        {
            cbxFilterBy.SelectedItem = "National Number";
        }

        private void tbxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbxFilterBy.SelectedItem == "Person ID")
            {
                e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
            }

        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            switch ((enFilterMode)cbxFilterBy.SelectedIndex)
            {
                case enFilterMode.enPersonID:
                    int.TryParse(tbxFilterBy.Text, out int ID);
                    //Person = clsPerson.FindPerson(ID);
                    personInfos1.LoadPersonInfo(ID);
                    if (personInfos1.IsFound == true)
                    {
                        this.ID = ID;
                    }

                    //MessageBox.Show("ID =" + this.ID);
                    break;
                case enFilterMode.enNationalNumber:
                    personInfos1.LoadPersonInfo(tbxFilterBy.Text);
                    if (personInfos1.IsFound == true)
                    {
                        this.ID = personInfos1._ID;
                    }
                    //MessageBox.Show("ID =" + this.ID);
                    break;
            }
        }

        private void personFilter_Load(object sender, EventArgs e)
        {
            LoadUserControlInfo();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddEditPersons frm = new AddEditPersons("Add New Person");
            frm.GetPersonID += GetPersonID;
            frm.ShowDialog();
            
        }
        private void GetPersonID(int PersonID)
        {
            ID= PersonID;
            personInfos1.LoadPersonInfo(ID);

        }
    }
}
