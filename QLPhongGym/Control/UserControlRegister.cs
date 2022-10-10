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
                string value = DateTime.Now.ToFileTime().ToString();
                var customerUpdate = gaYeuMeoContext.Customers.FirstOrDefault(x => x.CustomerID == txtCustomerID.Text);
                if (customerUpdate == null)
                {
                    ///add customer
                    if (string.IsNullOrEmpty(txtCustomerLastName.Text) || string.IsNullOrEmpty(txtPhoneNumber.Text) || string.IsNullOrEmpty(txtAddress.Text))
                    {
                        throw new Exception("Nhập đầy đủ thông tin khách hàng!");
                    }
                    else
                    {
                        Customer customer = new Customer();
                        customer.CustomerID = "KH" + value.Substring(value.Length - 8, 8);
                        customer.CustomerFirstName = txtCustomerFirstName.Text;
                        customer.CustomerLastName = txtCustomerLastName.Text;
                        customer.Gender = radioFemale.Checked ? "Nữ" : "Nam";
                        customer.DateOfBirth = dtpBirthDate.Value;
                        customer.Phone = txtPhoneNumber.Text;
                        customer.Address = txtAddress.Text;
                        gaYeuMeoContext.Customers.Add(customer);
                        txtCustomerID.Text = customer.CustomerID;
                        gaYeuMeoContext.SaveChanges();
                        //add invoice
                        var invoiceUpdate = gaYeuMeoContext.Invoices.FirstOrDefault(x => x.InvoiceID == txtInvoiceID.Text);
                        if (invoiceUpdate == null)
                        {
                            Invoice invoice = new Invoice();
                            invoice.InvoiceID = "HD" + value.Substring(value.Length - 8, 8);
                            invoice.CustomerID = txtCustomerID.Text;
                            string subscriptionID = (string)cbxSubscription.SelectedValue;
                            invoice.SubscriptionID = subscriptionID;
                            invoice.CreateDate = DateTime.Now;
                            var total = gaYeuMeoContext.GymSubscriptions.FirstOrDefault(x => x.SubscriptionID == subscriptionID);
                            invoice.Total = (double)total.Price;
                            gaYeuMeoContext.Invoices.Add(invoice);
                            txtTotal.Text = total.Price.ToString();
                            txtInvoiceID.Text = invoice.InvoiceID;
                            gaYeuMeoContext.SaveChanges();
                        }

                        else if (string.IsNullOrEmpty(txtDuration.Text))
                        {
                            throw new Exception("Vui lòng nhập đầy đủ thông tin hoá đơn");
                            //gaYeuMeoContext.Customers.Remove(customerUpdate);

                        }
                        //add card
                        Card card = new Card();
                        card.CardID = txtInvoiceID.Text;
                        card.CustomerID = txtCustomerID.Text;
                        card.ReceiveDay = DateTime.Now;
                        card.ExpirationDay = card.ReceiveDay.Value.AddMonths(Convert.ToInt32(txtDuration.Text));
                        gaYeuMeoContext.Cards.Add(card);
                        gaYeuMeoContext.SaveChanges();
                        MessageBox.Show("Thêm Khách hàng thành công");
                        txtCustomerID.Text = "";
                        txtCustomerFirstName.Text = "";
                        txtCustomerLastName.Text = "";
                        txtAddress.Text = "";
                        dtpBirthDate.Value = DateTime.Now;
                        txtInvoiceID.Text = "";
                        txtPhoneNumber.Text = "";
                        txtTotal.Text = "";
                        txtDuration.Text = "";
                        dtpExpirationDay.Value = DateTime.Now;
                        dateTimePicker1.Value = DateTime.Now;
                        dateTimePicker3.Value = DateTime.Now;
                        dateTimePicker4.Value = DateTime.Now;
                    }
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
                dtpExpirationDay.Value = DateTime.Now.AddMonths(Convert.ToInt32(txtDuration.Text));
            }
        }


    }
}
