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
using System.IO;



namespace DVLD_My_Solution
{
    public partial class Test : Form
    {
        int DLAppID;
        
        public Test(int dlappid)
        {
            InitializeComponent();
            DLAppID = dlappid;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            
        }
    }
}
