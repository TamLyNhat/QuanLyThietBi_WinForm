using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;

namespace QuanLySuDungThietBi
{
    public partial class frmRptThietBi : Form
    {

        public CrystalReportViewer crvThietBi = new CrystalReportViewer();
        public frmRptThietBi()
        {
            InitializeComponent();
        }

        private void frmRptThietBi_Load(object sender, EventArgs e)
        {
            rptThietBi crThietBi = new rptThietBi();
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(crvThietBi);
            crvThietBi.Dock = DockStyle.Fill;
            TableLogOnInfo logonInfo = crThietBi.Database.Tables["THIETBI"].LogOnInfo;
            logonInfo.ConnectionInfo.ServerName = MyPublics.strServer;
            logonInfo.ConnectionInfo.DatabaseName = "QL_SuDungThietBi";
            logonInfo.ConnectionInfo.IntegratedSecurity = false;
            logonInfo.ConnectionInfo.UserID = "TN207User";
            logonInfo.ConnectionInfo.Password = "TN207User";
            crThietBi.Database.Tables[0].ApplyLogOnInfo(logonInfo);
            crvThietBi.ReportSource = crThietBi;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptThietBi));
            this.SuspendLayout();
            // 
            // frmRptThietBi
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptThietBi";
            this.Text = "Báo cáo - Danh sách thiết bị theo loại";
            this.Load += new System.EventHandler(this.frmRptThietBi_Load);
            this.ResumeLayout(false);

        }

        private void frmRptThietBi_Load_1(object sender, EventArgs e)
        {

        }
    }
}
