using QLPhongGym.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongGym.Control
{
    public partial class UserControlInformation : UserControl
    {
        GaYeuMeoContext gaYeuMeoContext = new GaYeuMeoContext();
        UserControlSearch userControlSearch = new UserControlSearch();
        public UserControlInformation()
        {
            InitializeComponent();
        }
        public UserControlInformation(UserControlSearch userControlSearch)
        {
            
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //var customerUpdate = gaYeuMeoContext.Customers.FirstOrDefault(x => x.) 
        }

        private void UserControlInformation_Load(object sender, EventArgs e)
        {
            txtCustomerID.Text = userControlSearch.dgvCustomer.Rows[1].Cells[1].Value.ToString();
        }
    }
}
