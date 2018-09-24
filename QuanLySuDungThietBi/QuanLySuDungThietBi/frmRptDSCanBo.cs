using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using QuanLySuDungThietBi;
using CrystalDecisions.Windows.Forms;

namespace QuanLySuDungThietBi
{
    public partial class frmRptDSCanBo : Form
    {
        public CrystalReportViewer crvCanBo = new CrystalReportViewer();

        public frmRptDSCanBo()
        {
            InitializeComponent();
        }

        private void frmRptDSCanBo_Load(object sender, EventArgs e)
        {
            rptCanBo crCanBo = new rptCanBo();
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(crvCanBo);
            crvCanBo.Dock = DockStyle.Fill;
            TableLogOnInfo logonInfo = crCanBo.Database.Tables["CANBO"].LogOnInfo;
            logonInfo.ConnectionInfo.ServerName = MyPublics.strServer;
            logonInfo.ConnectionInfo.DatabaseName = "QL_SuDungThietBi";
            logonInfo.ConnectionInfo.IntegratedSecurity = false;
            logonInfo.ConnectionInfo.UserID = "TN207User";
            logonInfo.ConnectionInfo.Password = "TN207User";
            crCanBo.Database.Tables[0].ApplyLogOnInfo(logonInfo);
            crvCanBo.ReportSource = crCanBo;
        }
    }
}
