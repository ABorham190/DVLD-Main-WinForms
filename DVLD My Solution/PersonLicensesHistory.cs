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
    public partial class PersonLicensesHistory : Form
    {
        string _NationalNo;
        int _PersonID;
        public PersonLicensesHistory(int personid)
        {
            InitializeComponent();
            this._PersonID = personid;
            
        }
       

        private void PersonLicensesHistory_Load(object sender, EventArgs e)
        {

            
            personFilter1.LoadPersonInfoToPersonInfosControl(_PersonID);
            licensesHistory1.LoadLicensesHistory(_PersonID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
