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
    public partial class ListDetainedLicenses : Form
    {
        DataTable TableContainAllDetainedLiceneses =
            clsDetain.GetAllDetainedLicenses();
        
        public ListDetainedLicenses()
        {
            InitializeComponent();
        }
        enum enFilterBy { enFilterBy=0,enDetainID=1,enIsReleased=2,
        enNationalNumber=3,enFullName=4,enReleaseAppID=5}

        enum enIsFilterByIsReleased { All = 0, Released = 1, NonReleased = 2 }

        private void _FilterByControlsSettings()
        {
            tbxFilterItem.Visible = false;
            tbxFilterItem.Text = string.Empty;
            cbxFilterBy.SelectedIndex = 0;
            cbxFilterByReleaseOptions.SelectedIndex = 0;
        }
        private void _FilterByDetainIDOrReleaseAppID(string ColumnName)
        {
            DataView dv = new DataView(TableContainAllDetainedLiceneses);
            int.TryParse(tbxFilterItem.Text, out int DetainID);
            dv.RowFilter = String.Format(ColumnName + " =" + DetainID);
            dgvDetainedLicenseList.DataSource = dv;
            lblRecords.Text=dv.Count.ToString();

        }
        private void _FilterByNationalNoOrName(string ColumnName)
        {
            DataView dv = new DataView(TableContainAllDetainedLiceneses);
            dv.RowFilter = String.Format(ColumnName + " like '%{0}%'", tbxFilterItem.Text);
            dgvDetainedLicenseList.DataSource= dv;
            lblRecords.Text = dv.Count.ToString();
        }
        private void _FilterByReleased()
        {
            DataView dv = new DataView(TableContainAllDetainedLiceneses);
            dv.RowFilter =("IsReleased = " + true);
            dgvDetainedLicenseList.DataSource=dv;
            lblRecords.Text=dv.Count.ToString();
        }
        private void _FilterByNonReleased()
        {
            DataView dv = new DataView(TableContainAllDetainedLiceneses);
            dv.RowFilter = ("IsReleased = " + false);
            dgvDetainedLicenseList.DataSource = dv;
            lblRecords.Text = dv.Count.ToString();
        }
        private void _FilterByIsReleased()
        {
            switch (cbxFilterByReleaseOptions.SelectedIndex)
            {
                case (int)enIsFilterByIsReleased.Released:
                    _FilterByReleased();
                    break;
                case (int)enIsFilterByIsReleased.NonReleased:
                    _FilterByNonReleased();
                    break;
                case (int)enIsFilterByIsReleased.All:
                    _LoadDetainedList();
                    break;

            }
        }
        private void _SetFilter()
        {
            switch (cbxFilterBy.SelectedIndex)
            {
                case (int)enFilterBy.enDetainID:
                    _FilterByDetainIDOrReleaseAppID("DetainID");
                    break;
                case (int)enFilterBy.enReleaseAppID:
                    _FilterByDetainIDOrReleaseAppID("ReleaseApplicationID");
                    break;
                case (int)enFilterBy.enNationalNumber:
                    _FilterByNationalNoOrName("NationalNo");
                    break;
                case (int)enFilterBy.enFullName:
                    _FilterByNationalNoOrName("Name");
                    break;
                default:
                    _LoadDetainedList();
                    break;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.ShowDialog();
        }
        private void _LoadDetainedList()
        {
            DataView dv = new DataView(TableContainAllDetainedLiceneses);
            dgvDetainedLicenseList.DataSource = dv;
            lblRecords.Text=dv.Count.ToString();
            dgvDetainedLicenseList.Columns[7].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
            _FilterByControlsSettings();


        }
        private void ListDetainedLicenses_Load(object sender, EventArgs e)
        {
            tbxFilterItem.Visible = false;
            cbxFilterByReleaseOptions.Visible = false;
            _LoadDetainedList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            Detain_License frm=new Detain_License();
            frm.ShowDialog();
        }

        private void tbxFilterItem_TextChanged(object sender, EventArgs e)
        {
            if (tbxFilterItem.Text == "")
            {
                DataView dataView = new DataView(TableContainAllDetainedLiceneses);
                dgvDetainedLicenseList.DataSource= dataView;
                return;
            }
            _SetFilter();
        }

        private void cbxFilterByReleaseOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterByIsReleased();
        }

        private void cbxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxFilterBy.SelectedIndex)
            {
                case 0:
                    tbxFilterItem.Visible= false;
                    cbxFilterByReleaseOptions.Visible= false;
                    break;
                case 2:
                    cbxFilterByReleaseOptions.Visible = true ;
                    tbxFilterItem.Visible = false;
                    break;

                default:
                    tbxFilterItem.Visible = true;
                    cbxFilterByReleaseOptions.Visible = false;
                    break;
            }
        }

        private void cbxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbxFilterByReleaseOptions_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled= true;
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense((int)dgvDetainedLicenseList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void _SetCMSReleaseDetainedLicense()
        {
            if ((bool)dgvDetainedLicenseList.CurrentRow.Cells[3].Value==true)
            {
                contextMenuStrip1.Items[4].Enabled = false;
            }
            else
            {
                contextMenuStrip1.Items[4].Enabled=true;
            }
        }
        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            _SetCMSReleaseDetainedLicense();
        }
    }
}
