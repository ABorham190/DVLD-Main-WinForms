using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVDLBussinessLayer;

namespace DVLD_My_Solution
{
    public partial class Manage_Application_Types : Form
    {
        DataTable TableContainAllServices=new DataTable();
        public Manage_Application_Types()
        {
            InitializeComponent();
        }
        private void _RefreshServicesList()
        {
            TableContainAllServices = clsServices.GetServicesList();
            DataView dataView = new DataView(TableContainAllServices);
            dgvServicesList.DataSource = dataView;
            dgvServicesList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvServicesList.Columns[0].DividerWidth = 100;
            
            lblRecords.Text=dataView.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Manage_Application_Types_Load(object sender, EventArgs e)
        {
            _RefreshServicesList(); 
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Application_Type frm = new Update_Application_Type((int)dgvServicesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshServicesList();
        }
    }
}
