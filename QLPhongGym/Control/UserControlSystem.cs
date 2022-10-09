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
    public partial class UserControlSystem : UserControl
    {
        public UserControlSystem()
        {
            InitializeComponent();
        }
        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlStaff userControlStaff = new UserControlStaff();
            userControlStaff.Dock = DockStyle.Fill;
            Controls.Add(userControlStaff);
            userControlStaff.BringToFront();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlAccount userControlAccount = new UserControlAccount();
            userControlAccount.Dock = DockStyle.Fill;
            Controls.Add(userControlAccount);
            userControlAccount.BringToFront();
        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlCreate userControlCreate = new UserControlCreate();
            userControlCreate.Dock = DockStyle.Fill;
            Controls.Add(userControlCreate);
            userControlCreate.BringToFront();
        }
    }
}
