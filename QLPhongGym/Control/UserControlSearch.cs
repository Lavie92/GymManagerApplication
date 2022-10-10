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
            string customerID = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
            userControlInformation.txtCustomerID.Text = customerID;
            var customer = gaYeuMeoContext.Customers.FirstOrDefault(x => x.CustomerID == customerID);
            userControlInformation.txtCustomerFirstName.Text = customer.CustomerFirstName.ToString();
            userControlInformation.txtCustomerLastName.Text = customer.CustomerLastName.ToString();
            if (dgvCustomer.CurrentRow.Cells[3].Value.ToString() == "Nam")
            {
                userControlInformation.radioMale.Checked = true;
            }
            else
            {
                userControlInformation.radioFemale.Checked = true;
            }
            userControlInformation.dtpBirthDate.Value = (DateTime)dgvCustomer.CurrentRow.Cells[4].Value;
            userControlInformation.txtPhoneNumber.Text = dgvCustomer.CurrentRow.Cells[5].Value.ToString();
            userControlInformation.txtAddress.Text = dgvCustomer.CurrentRow.Cells[6].Value.ToString();
            userControlInformation.cbxGymSubscription.DataSource = gaYeuMeoContext.GymSubscriptions.ToList();
            userControlInformation.cbxGymSubscription.DisplayMember = "SubscriptionName";
            userControlInformation.cbxGymSubscription.ValueMember = "SubscriptionID";
            var subscriptionID = gaYeuMeoContext.Invoices.FirstOrDefault(x => x.CustomerID == customerID).SubscriptionID;
            if (subscriptionID != null)
            {
                userControlInformation.cbxGymSubscription.SelectedValue = subscriptionID;
            }
           DateTime createDate = gaYeuMeoContext.Cards.FirstOrDefault(x => x.CustomerID == customerID).ReceiveDay.Value;
            userControlInformation.dtpCreateDate.Value = createDate;
            DateTime expired = gaYeuMeoContext.Cards.FirstOrDefault(x => x.CustomerID == customerID).ExpirationDay.Value;
            userControlInformation.dtpExpired.Value = expired;
            var remaining = (expired - createDate).TotalDays;
            userControlInformation.txtRemaining.Text = remaining.ToString();
            var invoiceID = gaYeuMeoContext.Invoices.FirstOrDefault(x => x.CustomerID == customerID).InvoiceID;
            if (invoiceID != null)
            {
                userControlInformation.txtInvoiceID.Text = invoiceID.ToString();
            }
        }

        private void UserControlSearch_Load(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            var listCustomer = gaYeuMeoContext.Customers.ToList().Select((x, i) => new
            {
                Number = i + 1,
                CustomerID = x.CustomerID,
                CustomerName = x.CustomerFirstName + " " + x.CustomerLastName,

                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                Phone = x.Phone,
                Address = x.Address
            }).ToList();
            dgvCustomer.DataSource = listCustomer.ToList();
            txtTotal.Text = dgvCustomer.RowCount.ToString();
        }
        //show user control Customer Information
        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Customer> result = gaYeuMeoContext.Customers.Where(x => x.CustomerID.Contains(txtCustomerID.Text) && x.CustomerLastName.Contains(txtCustomerName.Text) && x.Phone.Contains(txtCustomerPhoneNumber.Text)).ToList();
            dgvCustomer.DataSource = result.ToList().Select((x, i) => new
            {
                Number = i + 1,
                CustomerID = x.CustomerID,
                CustomerName = x.CustomerFirstName + " " + x.CustomerLastName,
                Gender = x.Gender,
                DateOfBirth = x.DateOfBirth,
                Phone = x.Phone,
                Address = x.Address
            }).ToList();
        }

        private void btnAscSort_Click(object sender, EventArgs e)
        {
            var gymCustomer = gaYeuMeoContext.Customers.OrderBy(x => x.CustomerLastName).ToList().Select((x, i) => new
            {
                Number = i + 1,
                CustomerID = x.CustomerID,
                CustomerName = x.CustomerFirstName + " " + x.CustomerLastName,
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
            var gymCustomer = gaYeuMeoContext.Customers.OrderByDescending(x => x.CustomerLastName).ToList().Select((x, i) => new
            {
                Number = i + 1,
                CustomerID = x.CustomerID,
                CustomerName = x.CustomerFirstName + " " + x.CustomerLastName,
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
