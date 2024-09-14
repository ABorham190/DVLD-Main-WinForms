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
    public partial class Manage_Tests : Form
    {
        DataTable tableContainTestsDetails=new DataTable();
        public Manage_Tests()
        {
            InitializeComponent();
        }
        private void _RefreshList()
        {
            tableContainTestsDetails = clsTestTypes.GetTestsList();
            DataView dataView = new DataView(tableContainTestsDetails);
            dgvTestsList.DataSource = dataView;
            lblRecords.Text=dataView.Count.ToString();
            dgvTestsList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Manage_Tests_Load(object sender, EventArgs e)
        {
            _RefreshList();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Test_Type frm = new Update_Test_Type((int)dgvTestsList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshList();
        }
    }
}
