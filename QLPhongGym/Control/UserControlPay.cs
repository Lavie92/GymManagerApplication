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
    public partial class UserControlPay : UserControl
    {
        GaYeuMeoContext gaYeuMeoContext = new GaYeuMeoContext();
        public UserControlPay()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            var gymSubscription = gaYeuMeoContext.GymSubscriptions.ToList().Select((x, i) => new
            {
                Number = i + 1,
                SubscriptionID = x.SubscriptionID,
                SubscriptionName = x.SubscriptionName,
                Price = x.Price,
            }).ToList();
            dgvSubscription.DataSource = gymSubscription.ToList();
            txtTotal.Text = dgvSubscription.RowCount.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var subscriptionUpdate = gaYeuMeoContext.GymSubscriptions.FirstOrDefault(x => x.SubscriptionID == txtSubscriptionID.Text);
                if (subscriptionUpdate == null)
                {
                    if (string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtSubscriptionID.Text) || string.IsNullOrEmpty(txtSubscriptionName.Text))
                    {
                        throw new Exception("Vui lòng điền đầy đủ thông tin gói tập");
                    }
                    if (txtSubscriptionID.Text.Length > 10)
                    {
                        throw new Exception("Mã gói tập tối đa 10 ký tự thôi ba");
                    }
                    GymSubscription gymSubscription = new GymSubscription();
                    gymSubscription.SubscriptionID = txtSubscriptionID.Text;
                    gymSubscription.SubscriptionName = txtSubscriptionName.Text;
                    double parseDouble = 0;
                    bool successful = double.TryParse(txtPrice.Text, out parseDouble);
                    if (successful && parseDouble > 0)
                    {
                        gymSubscription.Price = parseDouble;
                    }
                    else
                    {
                        throw new Exception("Vui lòng nhập giá hợp lệ");
                    }
                    gaYeuMeoContext.GymSubscriptions.Add(gymSubscription);
                    gaYeuMeoContext.SaveChanges();
                    MessageBox.Show("Thêm gói tập thành công!", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSubscriptionID.Text = "";
                    txtSubscriptionName.Text = "";
                    txtPrice.Text = "";
                    Refresh();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserControlPay_Load(object sender, EventArgs e)
        {
            Refresh();
            this.dgvSubscription.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var subscriptionUpdate = gaYeuMeoContext.GymSubscriptions.FirstOrDefault(x => x.SubscriptionID == txtSubscriptionID.Text);
                if (subscriptionUpdate != null)
                {
                    if (string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtSubscriptionID.Text) || string.IsNullOrEmpty(txtSubscriptionName.Text))
                    {
                        throw new Exception("Vui lòng điền đầy đủ thông tin gói tập");
                    }
                    if (txtSubscriptionID.Text.Length > 10)
                    {
                        throw new Exception("Mã gói tập tối đa 10 ký tự thôi ba");
                    }
                    subscriptionUpdate.SubscriptionID = txtSubscriptionID.Text;
                    subscriptionUpdate.SubscriptionName = txtSubscriptionName.Text;
                    double parseDouble = 0;
                    bool successful = double.TryParse(txtPrice.Text, out parseDouble);
                    if (successful && parseDouble > 0)
                    {
                        subscriptionUpdate.Price = parseDouble;
                    }
                    else
                    {
                        throw new Exception("Vui lòng nhập giá hợp lệ");
                    }
                    gaYeuMeoContext.SaveChanges();
                    MessageBox.Show("Cập nhật gói tập thành công!", "Cập nhật thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSubscriptionID.Text = "";
                    txtSubscriptionName.Text = "";
                    txtPrice.Text = "";
                    Refresh();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var subscriptionRemove = gaYeuMeoContext.GymSubscriptions.FirstOrDefault(x => x.SubscriptionID == txtSubscriptionID.Text);
                if (subscriptionRemove != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá gói tập này?", "Ảe you sủe?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        gaYeuMeoContext.GymSubscriptions.Remove(subscriptionRemove);
                        gaYeuMeoContext.SaveChanges();
                        Refresh();
                    }
                }
                else
                {
                    throw new Exception("Không tìm thấy gói tập cần xoá");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Không thể xoá", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAscSort_Click(object sender, EventArgs e)
        {
            var gymSubscription = gaYeuMeoContext.GymSubscriptions.OrderBy(x => x.SubscriptionName).ToList().Select((x, i) => new
            {
                Number = i + 1,
                SubscriptionID = x.SubscriptionID,
                SubscriptionName = x.SubscriptionName,
                Price = x.Price,
            }).ToList();
            if (gymSubscription.Count > 0)
            {
                dgvSubscription.DataSource = gymSubscription.ToList();
                CellClick();
            }
        }

        private void btnDesSort_Click(object sender, EventArgs e)
        {
            var gymSubscription = gaYeuMeoContext.GymSubscriptions.OrderByDescending(x => x.SubscriptionName).ToList().Select((x, i) => new
            {
                Number = i + 1,
                SubscriptionID = x.SubscriptionID,
                SubscriptionName = x.SubscriptionName,
                Price = x.Price,
            }).ToList();
            if (gymSubscription.Count > 0)
            {
                dgvSubscription.DataSource = gymSubscription.ToList();
                CellClick();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }
        private void CellClick()
        {
            if (dgvSubscription.RowCount > 0)
            {
                txtSubscriptionID.Text = dgvSubscription.CurrentRow.Cells[1].Value.ToString();
                txtSubscriptionName.Text = dgvSubscription.CurrentRow.Cells[2].Value.ToString();
                txtPrice.Text = dgvSubscription.CurrentRow.Cells[3].Value.ToString();
            }
        }
        private void dgvSubscription_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick();
        }
    }
}
