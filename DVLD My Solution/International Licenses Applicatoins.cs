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
    public partial class International_Licenses_Applicatoins : Form
    {
        DataTable TableContainAllInternationalApps=clsOrders.GetAllInternationalApplications();
        int _PersonID;
        enum enFilterBy { IntLID=1,DriverID=2,LLicenseID=3}

        public International_Licenses_Applicatoins()
        {
            InitializeComponent();
        }

        private void _FilterByLicenseIDOrDriverID(string ColumnName,string IDText)
        {
            int.TryParse(IDText, out int ID);
            DataView dv=new DataView(TableContainAllInternationalApps);
            dv.RowFilter = (ColumnName+" = " + ID);
            dgvApplicationList.DataSource = dv;
            lblRecords.Text = dv.Count.ToString();

        }
        private void _SetFilter()
        {
            if (tbxFilterItem.Text == "")
            {
                _LoadApplicationsList();
                return;
            }

            switch (cbxFilterBy.SelectedIndex)
            {

                case (int)enFilterBy.IntLID:
                    _FilterByLicenseIDOrDriverID("Int.L.ID",tbxFilterItem.Text);
                    break;

                case (int)enFilterBy.DriverID:
                    _FilterByLicenseIDOrDriverID("DriverID", tbxFilterItem.Text);
                    break;

                case (int)enFilterBy.LLicenseID:
                    _FilterByLicenseIDOrDriverID("L.LicenseID", tbxFilterItem.Text);
                    break;

            }

        }
        private void _SetControls()
        {
            cbxFilterBy.SelectedIndex = 0;
            tbxFilterItem.Text = string.Empty;
            tbxFilterItem.Visible = false;

        }

        private void _LoadApplicationsList()
        {

            _SetControls();
            TableContainAllInternationalApps.Columns[0].ColumnName = "Int.L.ID";
            TableContainAllInternationalApps.Columns[3].ColumnName = "L.LicenseID";
            DataView dv=new DataView(TableContainAllInternationalApps);
            dgvApplicationList.DataSource = dv;
            dgvApplicationList.Columns.RemoveAt(7);
            
            lblRecords.Text=dv.Count.ToString();

        }

        private void International_Licenses_Applicatoins_Load(object sender, EventArgs e)
        {
            _LoadApplicationsList();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            NewInternationalLicenseApplication frm= new NewInternationalLicenseApplication();
            frm.ShowDialog();
            _LoadApplicationsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbxFilterItem_TextChanged(object sender, EventArgs e)
        {
            _SetFilter();
        }

        private void cbxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxFilterBy.SelectedIndex != 0)
            {
                tbxFilterItem.Visible = true;
            }
            else
            {
                tbxFilterItem.Visible=false;
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Driver_International_Driving_License_Info frm = new Driver_International_Driving_License_Info(
                (int)dgvApplicationList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _PersonID = clsPerson.GetPersonIDByLicenseID((int)dgvApplicationList.CurrentRow.Cells[3].Value);
            Person_Details frm = new Person_Details(_PersonID);
            frm.ShowDialog();
        }

        private void showPerosnLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _PersonID = clsPerson.GetPersonIDByLicenseID((int)dgvApplicationList.CurrentRow.Cells[3].Value);

            PersonLicensesHistory frm = new PersonLicensesHistory(_PersonID);
            frm.ShowDialog();
        }
    }
}
