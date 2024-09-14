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
    public partial class AddEditPersons : Form
    {
        public delegate void DataBackEventHandler( int PersonID);
        public event DataBackEventHandler GetPersonID;

        string _WhatToDo;
        public int PersonID;

        public AddEditPersons(string WhatToDo)
        {
            InitializeComponent();
            _WhatToDo = WhatToDo;
        }

        private void AddEditPersons_Load(object sender, EventArgs e)
        {
            lblFormHeader.Text = _WhatToDo;
            if(_WhatToDo=="Add New Person")
            {
                addEditPersonInfo1._LoadUserControlData();
                
            }else if(_WhatToDo=="Update Person")
            {
                addEditPersonInfo1._LoadPersonIfosToUserControl(PersonID);
                
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PersonID = addEditPersonInfo1._ID;
            GetPersonID?.Invoke(PersonID);
            this.Close();
        }

        
    }
}
