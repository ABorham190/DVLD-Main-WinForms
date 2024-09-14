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
    public partial class LicensesHistory : UserControl
    {
        DataTable LocalLicensesHistory = new DataTable();
        DataTable InternationalLicensesHistory=new DataTable();
        int _LocalDrivingLicenseRecords;
        int _InternationalLicensesHistoryRecords;
        public LicensesHistory()
        {
            InitializeComponent();
        }
        
        private void _LoadLocalDrivingLicensesHistory(int PersonID)
        {
            
            
                LocalLicensesHistory = clsLicenses.GetPersonLocalLicenseHistory(PersonID);
                DataView dv = new DataView(LocalLicensesHistory);
                dgvLocalLicenses.DataSource = dv;
                dgvLocalLicenses.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                _LocalDrivingLicenseRecords = dv.Count;
            lblRecords.Text=dv.Count.ToString();

        }
        private void _LoadInternationalLicensesHistory(int PersonId)
        {
            InternationalLicensesHistory = clsInternationalLicense.GetPersonInternationalLicenseHistory(PersonId);
            DataView dv = new DataView(InternationalLicensesHistory);
            dgvInternationlLicenses.DataSource = dv;
            _InternationalLicensesHistoryRecords = dv.Count;

        }

        public void LoadLicensesHistory(int PersonID)
        {
            _LoadLocalDrivingLicensesHistory(PersonID);
            _LoadInternationalLicensesHistory(PersonID);
        }

       

        private void tbcInternationalLicenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcInternationalLicenses.SelectedIndex == 0)
            {
                lblRecords.Text=_LocalDrivingLicenseRecords.ToString();
            }
            else
            {
                lblRecords.Text = _InternationalLicensesHistoryRecords.ToString();
            }
        }
    }
}
