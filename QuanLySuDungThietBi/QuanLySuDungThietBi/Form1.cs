using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySuDungThietBi;

namespace QuanLySuDungThietBi
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap fDangNhap = new frmDangNhap(this);
            fDangNhap.ShowDialog();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chương trình quản lý sử dụng thiết bị \n V1.0 \n Designed by: Chí Thanh & Chí Nguyễn", "Giới thiệu");
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap fDangNhap = new frmDangNhap(this);
            fDangNhap.ShowDialog();
        }

        private void mnuCanBoTheoBoMon_Click(object sender, EventArgs e)
        {
            frmCanBoTheoBoMon fCanBoTheoBoMon = new frmCanBoTheoBoMon();
            fCanBoTheoBoMon.ShowDialog();
        }

        private void mnuBoMon_Click(object sender, EventArgs e)
        {
            frmBoMon fBoMon = new frmBoMon();
            fBoMon.ShowDialog();
        }

        private void mnuPhong_Click(object sender, EventArgs e)
        {
            frmPhong fPhong = new frmPhong();
            fPhong.ShowDialog();
        }

        private void mnuThoatDangNhap_Click(object sender, EventArgs e)
        {
            DialogResult blnDongY;
            blnDongY = MessageBox.Show("Đã đăng xuất! \nBạn có muốn đăng nhập lại?", "Thông báo", MessageBoxButtons.YesNo);
            if (blnDongY == DialogResult.Yes)
            {
                frmDangNhap fDangNhap = new frmDangNhap(this);
                fDangNhap.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ứng dụng sẽ thoát!", "Thông báo");
                Application.Exit();
            }
        }

        private void mnuLoaiThietBi_Click(object sender, EventArgs e)
        {
            frmLoaiThietBi fLoaiThietBi = new frmLoaiThietBi();
            fLoaiThietBi.ShowDialog();
        }

        private void mnuThietBiTheoLoai_Click(object sender, EventArgs e)
        {
            frmThietBiTheoLoai fThietBiTheoLoai = new frmThietBiTheoLoai();
            fThietBiTheoLoai.ShowDialog();
        }

        private void mnuThietBiThanhLy_Click(object sender, EventArgs e)
        {
            frmThietBiThanhLy fThietBiThanhLy = new frmThietBiThanhLy();
            fThietBiThanhLy.ShowDialog();
        }

        private void mnuThanhLyThietBi_Click(object sender, EventArgs e)
        {
            frmThanhLyThietBi fThanhLyThietBi = new frmThanhLyThietBi();
            fThanhLyThietBi.ShowDialog();
        }

        //private void mnuDSCanBo_Click(object sender, EventArgs e)
        //{
        //    frmRptDSCanBo fRptDSCanBo = new frmRptDSCanBo();
        //    fRptDSCanBo.ShowDialog();
        //}

        //private void mnuDSThietBi_Click(object sender, EventArgs e)
        //{
        //    frmRptThietBi fRptThietBi = new frmRptThietBi();
        //    fRptThietBi.ShowDialog();
        //}

    }
}
