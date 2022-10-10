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
        public UserControlInformation()
        {
            InitializeComponent();
            txtCustomerID.Enabled = false;
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
            var customerUpdate = gaYeuMeoContext.Customers.FirstOrDefault(x => x.CustomerID == txtCustomerID.Text);
            if (customerUpdate != null)
            {
                customerUpdate.CustomerFirstName = txtCustomerFirstName.Text;
                customerUpdate.CustomerLastName = txtCustomerLastName.Text;
                if (radioFemale.Checked)
                {
                    customerUpdate.Gender = "Nữ";
                }
                else if (radioMale.Checked)
                {
                    customerUpdate.Gender = "Nam";
                }
                customerUpdate.DateOfBirth = dtpBirthDate.Value;
                customerUpdate.Phone = txtPhoneNumber.Text;
                customerUpdate.Address = txtAddress.Text;
                gaYeuMeoContext.SaveChanges();
                MessageBox.Show("Cập nhật thành công!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UserControlInformation_Load(object sender, EventArgs e)
        {
            
        }


    }
}
