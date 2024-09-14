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
    public partial class ManageDrivers : Form
    {
        DataTable TableContainAllDriversDetails = clsDriver.GetAllDriversDetails();
        enum enFilterBy { FilterBy = 0, DriverID = 1, NationalNumber = 2, Name = 3 }
        enFilterBy _enFilterMode;
        public ManageDrivers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _FilterByDriverID()
        {
            DataView dv = new DataView(TableContainAllDriversDetails);
            int.TryParse(tbxFilterBy.Text, out int ID);
            dv.RowFilter = string.Format("DriverID = '{0}'",ID);
            dgvDriversList.DataSource = dv;
            lblRecords.Text = dv.Count.ToString();

        }
        private void _FilterByNationalNo() 
        {
          DataView dv=new DataView(TableContainAllDriversDetails);
            dv.RowFilter = String.Format("NationalNo like '%{0}%'", tbxFilterBy.Text);
            dgvDriversList.DataSource= dv;
            lblRecords.Text= dv.Count.ToString();
        
        }
        private void _FilterByName()
        {
            DataView dv = new DataView(TableContainAllDriversDetails);
            dv.RowFilter = String.Format("Name like '%{0}%'", tbxFilterBy.Text);
            dgvDriversList.DataSource = dv;
            lblRecords.Text = dv.Count.ToString();
        }
        private void _FilterByLogic()
        {
            switch (cbxFilterBy.SelectedIndex)
            {
                case (int)enFilterBy.FilterBy:
                    _LoadDriversDetailsList();
                    break;
                case (int)enFilterBy.DriverID:
                    _FilterByDriverID();
                    break;
                case (int)enFilterBy.NationalNumber:
                    _FilterByNationalNo();
                    break;
                case (int)enFilterBy.Name:
                    _FilterByName();
                    break;

            }
        }
        private void _SetFilterBycbx()
        {
            cbxFilterBy.SelectedIndex = 0;
        }
        private void _LoadDriversDetailsList()
        {
            DataView dv = new DataView(TableContainAllDriversDetails);
            dgvDriversList.DataSource = dv;
            dgvDriversList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            lblRecords.Text=dv.Count.ToString();
            tbxFilterBy.Text = "";
        }
        private void _LoadAllFormInfo()
        {
            _SetFilterBycbx();
            _LoadDriversDetailsList();
        }

        private void ManageDrivers_Load(object sender, EventArgs e)
        {
            _LoadAllFormInfo();
        }

        private void cbxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxFilterBy.SelectedIndex == 0)
            {
                _LoadDriversDetailsList();
                tbxFilterBy.Visible = false;
            }
            else
            {
                tbxFilterBy.Visible=true;
                tbxFilterBy.Focus();
            }
        }

        private void tbxFilterBy_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void tbxFilterBy_TextChanged(object sender, EventArgs e)
        {
            _FilterByLogic();
        }

        private void tbxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxFilterBy.SelectedIndex == 1)
            {
                e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
            }
        }
    }
}
