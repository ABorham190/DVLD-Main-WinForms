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
    public partial class Person_Details : Form
    {
        int _ID;
        public Person_Details(int iD)
        {
            InitializeComponent();
            _ID = iD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Person_Details_Load(object sender, EventArgs e)
        {
            personInfos1.LoadPersonInfo(_ID);
        }
    }
}
