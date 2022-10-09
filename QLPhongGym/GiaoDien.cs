using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using QLPhongGym.Control;


namespace QLPhongGym
{
    public partial class frmInterface : Form
    {
        public UserControlHomePage UCHP;
        public UserControlSearch UCS;
        public UserControlRegister UCR;
        public UserControlPay UCP;
        public UserControlReport UCRE;
        public UserControlGymEquipment UCGE;
        public UserControlSystem UCSY;
        public UserControlInformation UCI;

        public frmInterface()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }
        private void btnResetColor()
        {
            this.btnHomePage.Normalcolor = Color.Transparent;
            this.btnSearch.Normalcolor = Color.Transparent;
            this.btnRegister.Normalcolor = Color.Transparent;
            this.btnPay.Normalcolor = Color.Transparent;
            this.btnReport.Normalcolor = Color.Transparent;
            this.btnEquipment.Normalcolor = Color.Transparent;
            this.btnSystem.Normalcolor = Color.Transparent;
           
        }
        internal void PanelMain(string panelName)
        {
            this.btnResetColor();
            this.pnlMain.Controls.Clear();
            switch (panelName)
            {
                case "HomePage":
                    if (this.UCHP == null)
                    {
                        this.UCHP = new UserControlHomePage();
                        this.pnlMain.Controls.Add(UCHP);
                        this.UCHP.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.UCHP.Location = new System.Drawing.Point(0, 0);
                        this.UCHP.Name = "UCHP";
                        this.UCHP.Size = new System.Drawing.Size(250, 776);
                        this.UCHP.TabIndex = 0;
                    }
                    else
                    {
                        this.pnlMain.Controls.Add(UCHP);
                    }
                    this.btnHomePage.Normalcolor = Color.FromArgb(15, 25, 33);
                    break;
                case "Search":
                    if (this.UCS == null)
                    {
                        this.UCS = new UserControlSearch();
                        this.pnlMain.Controls.Add(UCS);
                        this.UCS.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.UCS.Location = new System.Drawing.Point(0, 0);
                        this.UCS.Name = "UCS";
                        this.UCS.Size = new System.Drawing.Size(250, 776);
                        this.UCS.TabIndex = 0;
                    }
                    else
                    {
                        this.pnlMain.Controls.Add(UCS);
                    }
                    this.btnSearch.Normalcolor = Color.FromArgb(15, 25, 33);
                    break;
                case "Register":
                    if (this.UCR == null)
                    {
                        this.UCR = new UserControlRegister();
                        this.pnlMain.Controls.Add(UCR);
                        this.UCR.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.UCR.Location = new System.Drawing.Point(0, 0);
                        this.UCR.Name = "UCR";
                        this.UCR.Size = new System.Drawing.Size(250, 776);
                        this.UCR.TabIndex = 0;
                    }
                    else
                    {
                        this.pnlMain.Controls.Add(UCR);
                    }
                    this.btnRegister.Normalcolor = Color.FromArgb(15, 25, 33);
                    break;
                case "Pay":
                    if (this.UCP == null)
                    {
                        this.UCP = new UserControlPay();
                        this.pnlMain.Controls.Add(UCP);
                        this.UCP.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.UCP.Location = new System.Drawing.Point(0, 0);
                        this.UCP.Name = "UCP";
                        this.UCP.Size = new System.Drawing.Size(250, 776);
                        this.UCP.TabIndex = 0;
                    }
                    else
                    {
                        this.pnlMain.Controls.Add(UCP);
                    }
                    this.btnPay.Normalcolor = Color.FromArgb(15, 25, 33);
                    break;
                case "Report":
                    if (this.UCRE == null)
                    {
                        this.UCRE = new UserControlReport();
                        this.pnlMain.Controls.Add(UCRE);
                        this.UCRE.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.UCRE.Location = new System.Drawing.Point(0, 0);
                        this.UCRE.Name = "UCRE";
                        this.UCRE.Size = new System.Drawing.Size(250, 776);
                        this.UCRE.TabIndex = 0;
                    }
                    else
                    {
                        this.pnlMain.Controls.Add(UCRE);
                    }
                    this.btnReport.Normalcolor = Color.FromArgb(15, 25, 33);
                    break;
                case "GymEquipment":
                    if (this.UCGE == null)
                    {
                        this.UCGE = new UserControlGymEquipment();
                        this.pnlMain.Controls.Add(UCGE);
                        this.UCGE.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.UCGE.Location = new System.Drawing.Point(0, 0);
                        this.UCGE.Name = "UCGE";
                        this.UCGE.Size = new System.Drawing.Size(250, 776);
                        this.UCGE.TabIndex = 0;
                    }
                    else
                    {
                        this.pnlMain.Controls.Add(UCGE);
                    }
                    this.btnEquipment.Normalcolor = Color.FromArgb(15, 25, 33);
                    break;
                case "System":
                    if (this.UCSY == null)
                    {
                        this.UCSY = new UserControlSystem();
                        this.pnlMain.Controls.Add(UCSY);
                        this.UCSY.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.UCSY.Location = new System.Drawing.Point(0, 0);
                        this.UCSY.Name = "UCGE";
                        this.UCSY.Size = new System.Drawing.Size(250, 776);
                        this.UCSY.TabIndex = 0;
                    }
                    else
                    {
                        this.pnlMain.Controls.Add(UCSY);
                    }
                    this.btnSystem.Normalcolor = Color.FromArgb(15, 25, 33);
                    break;
                default:
                    break;

            }
        }
        private void btnHomePage_Click(object sender, EventArgs e)
        {
            this.pnlMenuActive.Location = new Point(btnHomePage.Location.X, btnHomePage.Location.Y);
            this.PanelMain("HomePage");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.pnlMenuActive.Location = new Point(btnSearch.Location.X, btnSearch.Location.Y);
            this.PanelMain("Search");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.pnlMenuActive.Location = new Point(btnRegister.Location.X, btnRegister.Location.Y);
            this.PanelMain("Register");
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            this.pnlMenuActive.Location = new Point(btnPay.Location.X, btnPay.Location.Y);
            this.PanelMain("Pay");
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.pnlMenuActive.Location = new Point(btnReport.Location.X, btnReport.Location.Y);
            this.PanelMain("Report");
        }
        private void btnEquipment_Click(object sender, EventArgs e)
        {
            this.pnlMenuActive.Location = new Point(btnReport.Location.X, btnReport.Location.Y);
            this.PanelMain("GymEquipment");
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            this.pnlMenuActive.Location = new Point(btnReport.Location.X, btnReport.Location.Y);
            this.PanelMain("System");
        }

        private void GiaoDien_Load(object sender, EventArgs e)
        {
           
        }
    }
}
