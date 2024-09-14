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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_My_Solution
{
    public partial class Manage_People : Form
    {
        //DataTable TableContainAllPersons = new DataTable();
       static DataTable _dtAllPeople = clsPerson.GetAllPersonsData();
        DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false,
            "PersonID","NationalNo","FirstName",
            "SecondName", "ThirdName", "LastName","Gendor","DateOfBirth",
            "CountryName","Phone","Email");



       
        

        public Manage_People()
        {
            InitializeComponent();
        }


        

        private void _LoadList()
        {
            
            dgvPersonList.DataSource=_dtPeople;
            lblRecords.Text=_dtPeople.DefaultView.Count.ToString();

            dgvPersonList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           
           
        }

        private void Manage_People_Load(object sender, EventArgs e)
        {
            
            tbxFiltreBy.Visible = false;
            cbxFilterBy.SelectedIndex = 0;
            _LoadList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditPersons frm= new AddEditPersons("Add New Person");
            frm.ShowDialog();
            _LoadList();
            
        }

        private void cbxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            tbxFiltreBy.Visible = (cbxFilterBy.SelectedIndex != 0);

            if (tbxFiltreBy.Visible)
            {
                tbxFiltreBy.Text = "";
                tbxFiltreBy.Focus();
            }
        }

       

        private void tbxFiltreBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxFilterBy.SelectedItem == "ApplicantID")
            {
                e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);
            }
        }

        private void tbxFiltreBy_TextChanged(object sender, EventArgs e)
        {
            //_RefreshList();
            string ColumnName = "";
            switch (cbxFilterBy.Text)
            {
                case "ApplicantID":
                    ColumnName = "PersonID";
                    break;
                case "National Number":
                    ColumnName = "NationalNo";
                    break;
                case "First Name":
                    ColumnName = "FirstName";
                    break;
                case "Second Name":
                    ColumnName = "SeconName";
                    break;
                case "Third Name":
                    ColumnName = "ThirdName";
                    break;
                case "Last Name":
                    ColumnName = "LastName";
                    break;
                case "Email":
                    ColumnName = "Email";
                    break;
                case "Phone":
                    ColumnName = "Phone";
                    break;
                case "Gender":
                    ColumnName = "Gendor";
                    break;
                default:
                    ColumnName = "None";
                    break;

            }

            if(ColumnName=="None"||tbxFiltreBy.Text.Trim()=="")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecords.Text=_dtPeople.DefaultView.Count.ToString();
                return;
            }
            if (ColumnName == "PersonID")
            {
                _dtPeople.DefaultView.RowFilter = String.Format("[{0}]={1}", ColumnName, tbxFiltreBy.Text.Trim());

            }
            else
            {
                _dtPeople.DefaultView.RowFilter = String.Format("[{0}] Like '{1}%'",
                    ColumnName, tbxFiltreBy.Text.Trim());
            }

            lblRecords.Text=_dtPeople.DefaultView.Count.ToString() ;

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPersons frm = new AddEditPersons("Add New Person");
            frm.ShowDialog();
            _LoadList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           Person_Details frm= new Person_Details((int)dgvPersonList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this person", "Delete Confirmation",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (clsPerson.DeletePerson((int)dgvPersonList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person deleted successfully","Delete Confirmation",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _LoadList();
                }
                else
                {
                    MessageBox.Show("Person not deleted successfully","Error",MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Delete Person Operation Cancelled!", "Cancelled Operation",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPersons frm = new AddEditPersons("Update Person");
            frm.PersonID =(int) dgvPersonList.CurrentRow.Cells[0].Value;
            frm.ShowDialog();
            _LoadList();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature till not emplemented");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature till not emplemented");
        }

        private void cbxFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
