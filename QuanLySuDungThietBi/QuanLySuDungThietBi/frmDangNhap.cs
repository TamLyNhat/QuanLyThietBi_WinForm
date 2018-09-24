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
using System.Data.SqlClient;

namespace QuanLySuDungThietBi
{
    public partial class frmDangNhap : Form
    {
        int intSoLanDangNhap;
        private frmMain fMain;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        public frmDangNhap(frmMain fm) :this()
        {
            fMain = fm;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MyPublics.conMyConnection != null)
                MyPublics.conMyConnection = null;
            fMain.mnuBoMon.Enabled = false;
            fMain.mnuCanBo.Enabled = false;
            fMain.mnuCanBoTheoBoMon.Enabled = false;
            fMain.mnuDangNhap.Enabled = true;
            fMain.mnuThoatDangNhap.Enabled = false;
            fMain.mnuTienIch.Enabled = true;
            fMain.mnuThoat.Enabled = true;
            fMain.mnuGioiThieu.Enabled = false;
            fMain.mnuPhong.Enabled = false;
            MessageBox.Show("Ứng dụng sẽ thoát!", "Thông báo");
            Application.Exit();

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            intSoLanDangNhap = 0;
            txtMayChu.Text = "ALEXANDER\\";
            txtMayChu.Enabled = false;
            txtMatKhau.PasswordChar = '*';
            txtMaCanBo.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlCommand cmdCommand;
            SqlDataReader drReader;
            string sqlSelect;
            MyPublics.strServer = txtMayChu.Text;
            try
            {
                MyPublics.ConnectDatabase();
                if (MyPublics.conMyConnection.State == ConnectionState.Open)
                {
                    MyPublics.strMaCanBo = txtMaCanBo.Text;
                    sqlSelect = "Select MA_CB, QUYENSD, MA_BM From CANBO Where MA_CB = @MA_CB And MATKHAU = @MATKHAU";
                    cmdCommand = new SqlCommand(sqlSelect, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MA_CB", txtMaCanBo.Text);
                    cmdCommand.Parameters.AddWithValue("@MATKHAU", txtMatKhau.Text);
                    drReader = cmdCommand.ExecuteReader();
                    if (drReader.HasRows)
                    {
                        drReader.Read();
                        MyPublics.strMaBoMon = drReader.GetString(2);
                        MyPublics.strTenCanBo = drReader.GetString(0);
                        MyPublics.strQuyenSuDung = drReader.GetString(1);
                        drReader.Close();
                        MessageBox.Show("Đăng nhập thành công.", "Thông báo");
                        fMain.mnuBoMon.Enabled = true;
                        fMain.mnuCanBo.Enabled = true;
                        fMain.mnuPhong.Enabled = true;
                        fMain.mnuCanBoTheoBoMon.Enabled = true;
                        fMain.mnuDangNhap.Enabled = false;
                        fMain.mnuThoatDangNhap.Enabled = true;
                        fMain.mnuTienIch.Enabled = true;
                        fMain.mnuThoat.Enabled = true;
                        fMain.mnuGioiThieu.Enabled = true;
                        MyPublics.conMyConnection.Close();
                        this.Close();
                    }
                    else
                        if (intSoLanDangNhap < 2)
                        {
                            MessageBox.Show("Mã cán bộ hoặc mật khẩu sai!", "Thông báo");
                            intSoLanDangNhap++;
                            txtMaCanBo.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi đăng nhập, form sẽ đóng!", "Thông báo");
                            MyPublics.conMyConnection.Close();
                            fMain.mnuBoMon.Enabled = false;
                            fMain.mnuCanBo.Enabled = false;
                            fMain.mnuCanBoTheoBoMon.Enabled = false;
                            fMain.mnuDangNhap.Enabled = true;
                            fMain.mnuThoatDangNhap.Enabled = false;
                            fMain.mnuTienIch.Enabled = true;
                            fMain.mnuThoat.Enabled = true;
                            fMain.mnuGioiThieu.Enabled = false;
                            fMain.mnuPhong.Enabled = false;
                            this.Close();
                        }
                }
                else
                {
                    MessageBox.Show("Kết nối không thành công!", "Thông báo");
                }

            }

            catch (Exception)
            {
                MessageBox.Show("Lỗi khi thực hiện kết nối!", "Thông báo");
            }
        }

    }
}
