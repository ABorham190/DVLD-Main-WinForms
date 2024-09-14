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
    public partial class Update_Application_Type : Form
    {
        private int _ID;
        clsServices service = new clsServices();
        public Update_Application_Type(int iD)
        {
            InitializeComponent();
            _ID = iD;
        }

        private void _LoadApplicationInfo()
        {
             service = clsServices.FindServiceByID(_ID);
            if(service != null)
            {
                lblID.Text = service.ID.ToString();
                tbxTitle.Text = service.Name;
                tbxFees.Text = service.Fees.ToString();
            }
            else
            {
                MessageBox.Show("There is no Service with this ID", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void Update_Application_Type_Load(object sender, EventArgs e)
        {
            _LoadApplicationInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _IsAnyNecessaryFieldsEmpty()
        {
            if (tbxTitle.Text == "" || tbxFees.Text == "")
            {
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsAnyNecessaryFieldsEmpty())
            {
                MessageBox.Show("You must fill necessary fields", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Are you sure you want to update this " +
                "service details?", "Update Confirmation",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                service.Name = tbxTitle.Text;
                float.TryParse(tbxFees.Text, out float fees);
                service.Fees = fees;

                if (service.UpdateServiceDetails())
                {

                    MessageBox.Show("Service details updated successfully");
                    

                }
                else
                {
                    MessageBox.Show("Service details not updated successfully");
                }
            }
            else
            {
                MessageBox.Show("Cancelled Operation", "Cancelled", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
