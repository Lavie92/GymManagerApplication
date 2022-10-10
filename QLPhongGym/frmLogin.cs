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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLPhongGym
{
    public partial class frmLogin : Form
    {
        GaYeuMeoContext gaYeuMeoContext = new GaYeuMeoContext();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUsername.Text;
                string password = txtPassword.Text;
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không được trống!");
                }
                else
                {

                }
                var myAccount = gaYeuMeoContext.Accounts.FirstOrDefault(x => x.UserName == userName && x.Password == password);
                if (myAccount != null)
                {
                    frmInterface frmInterface = new frmInterface();
                    this.Hide();
                    frmInterface.ShowDialog();
                    this.Close();
                }
                else
                {
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi đăng nhập!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
