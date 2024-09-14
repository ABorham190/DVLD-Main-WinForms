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
    public partial class Update_Test_Type : Form
    {
        int _TestID;
        clsTestTypes test = new clsTestTypes();
        public Update_Test_Type(int testID)
        {
            InitializeComponent();
            _TestID = testID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadTestInfo()
        {
            test = clsTestTypes.FindTestByID(_TestID);
            lblID.Text=test.TestID.ToString();
            tbxTitle.Text = test.Title;
            tbxDescribtion.Text = test.Description;
            tbxFees.Text = test.Fees.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void Update_Test_Type_Load(object sender, EventArgs e)
        {
            _LoadTestInfo();
        }
        private bool _IsNessecaryFieldEmpty()
        {
            if (tbxTitle.Text == "" || tbxDescribtion.Text == "" || tbxFees.Text == "")
            {
                return true;
            }
            return false;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (_IsNessecaryFieldEmpty())
            {
                MessageBox.Show("You must fill All neccessary fields",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            test.Title = tbxTitle.Text;
            test.Description = tbxDescribtion.Text;
            Decimal.TryParse(tbxFees.Text, out Decimal fees);
            test.Fees = fees;
            if (MessageBox.Show("Are you sure you want to update this test details", "" +
                "Update Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (test.UpdateTestDetails())
                {
                    MessageBox.Show("Test Updated Successfully", "Updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Test not updated successfully", "Not updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Cancelled Operation", "Cancelled",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
