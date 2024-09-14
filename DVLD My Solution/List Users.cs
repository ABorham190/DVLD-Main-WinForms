using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVDLBussinessLayer;

namespace DVLD_My_Solution
{
    public partial class List_Users : Form
    {
        DataTable TableContainAllUsers = new DataTable();
        enum enFilterByMode { enPersonID=1,enUserID=2,enFullName=4,enUserName=3,enIsActive=5}
      
        public List_Users()
        {
            InitializeComponent();
        }

        private void _SettbxFilterByVisibility()
        {
            if (cbxFilterUsersBy.SelectedItem == "None"||
                cbxFilterUsersBy.SelectedItem=="Is Active")
            {
                tbxFilterBy.Visible = false;
            }
            else
            {
                tbxFilterBy.Visible = true;
                tbxFilterBy.Focus();
            }
        }
        private void _SetcbxIsActiveVisibility()
        {
            if(cbxFilterUsersBy.SelectedItem=="Is Active")
            {
                cbxIsActiveFilter.Visible = true;
                cbxIsActiveFilter.SelectedIndex = 0;
            }
            else
            {
                cbxIsActiveFilter.Visible = false;
            }
        }
        private void _FilterByFullNameAndUserName(string FullNameOrUserName)
        {
            
            DataView dataview = new DataView(TableContainAllUsers);
            dataview.RowFilter = string.Format(FullNameOrUserName+" like '%{0}%'", tbxFilterBy.Text);
            
           
            dgvListUsers.DataSource = dataview;
            dgvListUsers.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lblRecords.Text = dataview.Count.ToString();
            


        }
        private void _FilterByPersonIDAndUserID(string PersonIDOrUserName)
        {
            
            DataView dataview = new DataView(TableContainAllUsers);
            if(tbxFilterBy.Text!="")
            dataview.RowFilter =PersonIDOrUserName+" = "+int.Parse(tbxFilterBy.Text);

            
            
            dgvListUsers.DataSource = dataview;
            dgvListUsers.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lblRecords.Text = dataview.Count.ToString();
            


        }
        
        private void _FilterByIsActive()
        {
           
            DataView dataview = new DataView(TableContainAllUsers);
          
            lblRecords.Text = dataview.Count.ToString();
            
            if (cbxIsActiveFilter.SelectedIndex == 1)
            {
                dataview.RowFilter = "IsActive=" + true;
            }else if (cbxIsActiveFilter.SelectedIndex == 2)
            {
                dataview.RowFilter = "IsActive=" + false;
            }
            dgvListUsers.DataSource = dataview;
            dgvListUsers.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lblRecords.Text = dataview.Count.ToString();
            
        }
       
        private void _SetFilterMode()
        {
            

            switch ((enFilterByMode)cbxFilterUsersBy.SelectedIndex)
            {
                case enFilterByMode.enPersonID:
                    _FilterByPersonIDAndUserID("ApplicantID");
                    break;
                case enFilterByMode.enUserID:
                    _FilterByPersonIDAndUserID("UserID");
                    break;
                case enFilterByMode.enFullName:
                    _FilterByFullNameAndUserName("FullName");
                    break;
                case enFilterByMode.enUserName:
                    _FilterByFullNameAndUserName("UserName");
                    break;
                case enFilterByMode.enIsActive:
                    
                    break;

            }
        }
        private void _SetFilterByVisibility()
        {
            _SettbxFilterByVisibility();
            _SetcbxIsActiveVisibility();
        }
        private void _RefreshUsersList()
        {
            TableContainAllUsers = clsUsers.GetAllUsersList();
            
            DataView dataview= new DataView(TableContainAllUsers);
            dgvListUsers.DataSource = dataview;
            dgvListUsers.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lblRecords.Text=dataview.Count.ToString();
            tbxFilterBy.Text = "";
           
        }

        private void List_Users_Load(object sender, EventArgs e)
        {
            cbxFilterUsersBy.SelectedItem = "None";
            //cbxIsActiveFilter.Visible = false;
            _RefreshUsersList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxFilterUsersBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _SetFilterByVisibility();
        }

        private void tbxFilterBy_TextChanged(object sender, EventArgs e)
        {
            _SetFilterMode();
        }

        private void tbxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxFilterUsersBy.SelectedItem == "ApplicantID" ||
               cbxFilterUsersBy.SelectedItem == "UserID")
            {
                e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
            }
        }

        private void cbxIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterByIsActive();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Add_New_User frm= new Add_New_User();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_New_User frm = new Add_New_User();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this user ?",
                "Delete Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                if (clsUsers.DeleteUser((int)dgvListUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully");
                    
                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("User Not Deleted Successfully");
                }
            }
            else
            {
                MessageBox.Show("Cncelled Operation!!");
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_New_User frm=new Add_New_User((int)dgvListUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDetails frm = new UserDetails((int)dgvListUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword frm = new ChangePassword((int)dgvListUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void cbxFilterUsersBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
