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
    public partial class UserControlSearch : UserControl
    {
        //public UserControlInformation UCI;
        GaYeuMeoContext gaYeuMeoContext = new GaYeuMeoContext();
        public frmInterface GiaoDien;
        public UserControlSearch()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            GiaoDien.UCI.BringToFront();
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            UserControlInformation userControlInformation = new UserControlInformation();
            userControlInformation.Dock = DockStyle.Fill;
            Controls.Add(userControlInformation);
            userControlInformation.BringToFront(); 
        }

        private void UserControlSearch_Load(object sender, EventArgs e)
        {
            var listCustomer = gaYeuMeoContext.Customers.ToList().Select((x, i) => new
            {
                Number = i + 1,
                CustomerID = x.CustomerID,
                CustomerName = x.CustomerName,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                Phone = x.Phone,
                Address = x.Address
            }).ToList();
            dgvCustomer.DataSource = listCustomer.ToList();
            txtTotal.Text = dgvCustomer.RowCount.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Customer> result = gaYeuMeoContext.Customers.Where(x => x.CustomerID.Contains(txtCustomerID.Text) && x.CustomerName.Contains(txtCustomerName.Text) && x.Phone.Contains(txtCustomerPhoneNumber.Text)).ToList();
            dgvCustomer.DataSource = result.ToList().Select((x, i) => new
            {
                Number = i + 1,
                CustomerID = x.CustomerID,
                CustomerName = x.CustomerName,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                Phone = x.Phone,
                Address = x.Address
            }).ToList();
        }

        private void btnAscSort_Click(object sender, EventArgs e)
        {
            var gymCustomer = gaYeuMeoContext.Customers.OrderBy(x => x.CustomerName).ToList().Select((x, i) => new
            {
                Number = i + 1,
                CustomerID = x.CustomerID,
                CustomerName = x.CustomerName,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                Phone = x.Phone,
                Address = x.Address
            }).ToList();
            if (gymCustomer.Count > 0)
            {
                dgvCustomer.DataSource = gymCustomer.ToList();
                CellClick();
            }
        }
        private void btnDesSort_Click(object sender, EventArgs e)
        {
            var gymCustomer = gaYeuMeoContext.Customers.OrderByDescending(x => x.CustomerName).ToList().Select((x, i) => new
            {
                Number = i + 1,
                CustomerID = x.CustomerID,
                CustomerName = x.CustomerName,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                Phone = x.Phone,
                Address = x.Address
            }).ToList();
            if (gymCustomer.Count > 0)
            {
                dgvCustomer.DataSource = gymCustomer.ToList();
                CellClick();
            }
        }
        private void CellClick()
        {
            if (dgvCustomer.RowCount > 0)
            {
                txtCustomerID.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
                txtCustomerName.Text = dgvCustomer.CurrentRow.Cells[2].Value.ToString();
                txtCustomerPhoneNumber.Text = dgvCustomer.CurrentRow.Cells[5].Value.ToString();
            }
        }
        
    private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick();
        }
    }
}
