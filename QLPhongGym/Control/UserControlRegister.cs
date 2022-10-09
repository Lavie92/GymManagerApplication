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
    public partial class UserControlRegister : UserControl
    {
        GaYeuMeoContext gaYeuMeoContext = new GaYeuMeoContext();
        public UserControlRegister()
        {
            InitializeComponent();
        }
        private void UserControlRegister_Load(object sender, EventArgs e)
        {
            cbxSubscription.DataSource = gaYeuMeoContext.GymSubscriptions.ToList();
            cbxSubscription.DisplayMember = "SubscriptionName";
            cbxSubscription.ValueMember = "SubscriptionID";
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var customerUpdate = gaYeuMeoContext.Customers.FirstOrDefault(x => x.CustomerID == txtCustomerID.Text);
                if (customerUpdate == null)
                {
                    //add customer
                    if (string.IsNullOrEmpty(txtCustomerID.Text) || string.IsNullOrEmpty(txtCustomerName.Text) || string.IsNullOrEmpty(txtPhoneNumber.Text) || string.IsNullOrEmpty(txtAddress.Text))
                    {
                        throw new Exception("Nhập đầy đủ thông tin khách hàng!");
                    }
                    Customer customer = new Customer();
                    customer.CustomerID = txtCustomerID.Text;
                    customer.CustomerName = txtCustomerName.Text;
                    customer.Gender = radioFemale.Checked ? "Nữ" : "Nam";
                    customer.DateOfBirth = dtpBirthDate.Value;
                    customer.Phone = txtPhoneNumber.Text;
                    customer.Address = txtAddress.Text;
                    gaYeuMeoContext.Customers.Add(customer);
                    gaYeuMeoContext.SaveChanges();
                    //add invoice
                    var invoiceUpdate = gaYeuMeoContext.Invoices.FirstOrDefault(x => x.InvoiceID == txtInvoiceID.Text);
                    if (invoiceUpdate != null)
                    {
                        throw new Exception("Mã hoá đơn đã tồn tại");
                    }
                    else if (string.IsNullOrEmpty(txtInvoiceID.Text) || string.IsNullOrEmpty(txtDuration.Text))
                    {
                        throw new Exception("Vui lòng nhập đầy đủ thông tin hoá đơn");                  
                        gaYeuMeoContext.Customers.Remove(customerUpdate);
                        gaYeuMeoContext.SaveChanges();
                    }
                    else
                    {
                        Invoice invoice = new Invoice();
                        invoice.CustomerID = txtCustomerID.Text;
                        invoice.InvoiceID = txtInvoiceID.Text;
                        string subscriptionID = (string)cbxSubscription.SelectedValue;
                        invoice.SubscriptionID = subscriptionID;
                        invoice.CreateDate = DateTime.Now;
                        var total = gaYeuMeoContext.GymSubscriptions.FirstOrDefault(x => x.SubscriptionID == subscriptionID);
                        invoice.Total = (double)total.Price;
                        gaYeuMeoContext.Invoices.Add(invoice);
                        txtTotal.Text = total.Price.ToString();
                    }
                    //add card
                    Card card = new Card();
                    card.CardID = txtInvoiceID.Text;
                    card.CustomerID = txtCustomerID.Text;
                    card.ReceiveDay = DateTime.Now;
                    card.ExpirationDay = card.ReceiveDay.Value.AddDays(Convert.ToDouble( txtDuration.Text) * 30);
                    gaYeuMeoContext.Cards.Add(card);
                    gaYeuMeoContext.SaveChanges();
                    MessageBox.Show("Thêm Khách hàng thành công");
                    txtCustomerID.Text = "";
                    txtCustomerName.Text = "";
                    txtInvoiceID.Text = "";
                    txtPhoneNumber.Text = "";
                    txtTotal.Text = "";
                    txtAddress.Text = "";
                    txtDuration.Text = "";
                    dtpBirthDate.Value = DateTime.Now;
                    dtpExpirationDay.Value = DateTime.Now;
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker3.Value = DateTime.Now;
                    dateTimePicker4.Value = DateTime.Now;
                }
                else
                {
                    throw new Exception("Khách hàng đã tồn tại");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                
            }
        }

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDuration.Text))
            {
                dtpExpirationDay.Value = DateTime.Now.AddDays(30 * Convert.ToDouble(txtDuration.Text));
            }
        }
    }
}
