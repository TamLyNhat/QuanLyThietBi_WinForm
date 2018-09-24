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
    public partial class frmPhong : Form
    {
        DataSet dsPhong = new DataSet();
        DataSet dsBoMon = new DataSet();
        DataView dvPhong = new DataView();
        int ViTriBoMon=0, ThemSua = 0;

        void NhanDuLieu()
        {
            string strSelect = "Select * From PHONG";
            MyPublics.OpenData(strSelect, dsPhong, "PHONG");
        }

        void GanDuLieu()
        {
            if (dvPhong.Count > 0)
            {
                txtMaPhong.Text = dgvPhongTheoBoMon[0, dgvPhongTheoBoMon.CurrentRow.Index].Value.ToString();
                txtTenPhong.Text = dgvPhongTheoBoMon[2, dgvPhongTheoBoMon.CurrentRow.Index].Value.ToString();
               
            }
            else
            {
                txtTenPhong.Clear();
                txtMaPhong.Clear();
            }
        }

        void DieuKhienKhiThem()
        {
            txtMaPhong.Focus();
            txtTenPhong.Clear();
            txtMaPhong.Clear();
            btnChinhSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            dgvPhongTheoBoMon.ReadOnly = true;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            cboTenBoMon.Enabled = false;
            txtMaPhong.ReadOnly = false;
            txtTenPhong.ReadOnly = false;
        }

        void DieuKhienKhiBinhThuong()
        {
            if (MyPublics.strQuyenSuDung == "AllAdmin")
            {

                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnChinhSua.Enabled = true;
                btnLuu.Enabled = false;
                btnKhongLuu.Enabled = false;
                btnDong.Enabled = true;
                cboTenBoMon.Enabled = true;
                txtMaPhong.ReadOnly = true;
                txtTenPhong.ReadOnly = true;
            }
            else
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnChinhSua.Enabled = false;
                btnLuu.Enabled = false;
                btnKhongLuu.Enabled = false;
                btnDong.Enabled = true;
                txtMaPhong.ReadOnly = true;
                txtTenPhong.ReadOnly = true;
                txtMaPhong.BackColor = Color.White;
                txtTenPhong.BackColor = Color.White;
                cboTenBoMon.Enabled = true;
            }
            if ((MyPublics.strQuyenSuDung == "Admin") && (MyPublics.strMaBoMon == cboTenBoMon.SelectedValue.ToString()))
            {
                btnThem.Enabled = true;
                btnChinhSua.Enabled = true;
                txtMaPhong.ReadOnly = false;
                txtTenPhong.ReadOnly = false;
            }
        }

        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = true;
            txtMaPhong.ReadOnly = true;
            txtTenPhong.ReadOnly = false;
            cboTenBoMon.Enabled = false;
            cboTenBoMon.BackColor = Color.White;
        }



        public frmPhong()
        {
            InitializeComponent();
        }

        private void frmPhong_Load(object sender, EventArgs e)
        {
            string strSelect = "Select MA_BM, TEN_BM From BOMON";
            MyPublics.OpenData(strSelect, dsBoMon, "BOMON");
            cboTenBoMon.DataSource = dsBoMon.Tables["BOMON"];
            cboTenBoMon.DisplayMember = "TEN_BM";
            cboTenBoMon.ValueMember = "MA_BM";
            
            txtMaPhong.MaxLength = 5;
            txtTenPhong.MaxLength = 30;
            NhanDuLieu();
            dvPhong.Table = dsPhong.Tables["PHONG"];
            dvPhong.RowFilter = "MA_BM like '" + cboTenBoMon.SelectedValue + "'";
            dgvPhongTheoBoMon.DataSource = dvPhong;
            dgvPhongTheoBoMon.Width = 550;
            dgvPhongTheoBoMon.AllowUserToAddRows = false;
            dgvPhongTheoBoMon.AllowUserToDeleteRows = false;
            dgvPhongTheoBoMon.Columns[0].Width = 100;
            dgvPhongTheoBoMon.Columns[0].HeaderText = "Mã phòng";
            dgvPhongTheoBoMon.Columns[1].Width = 150;
            dgvPhongTheoBoMon.Columns[1].HeaderText = "Mã bộ môn";
            dgvPhongTheoBoMon.Columns[2].Width = 261;
            dgvPhongTheoBoMon.Columns[2].HeaderText = "Tên Phòng";

            dgvPhongTheoBoMon.EditMode = DataGridViewEditMode.EditProgrammatically;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPhongTheoBoMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSua = 1;
            DieuKhienKhiThem();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            ThemSua = 0;
            GanDuLieu();
            DieuKhienKhiChinhSua();
        }

        void ThucThiLuu()
        {
            string strSql;
            if (ThemSua == 1)
                strSql = "Insert Into PHONG Values(@MA_PHONG,@MA_BM, @TEN_PHONG)";
            else
                strSql = "Update PHONG Set TEN_PHONG = @TEN_PHONG Where MA_PHONG = @MA_PHONG And MA_BM = @MA_BM";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MA_PHONG", txtMaPhong.Text);
            cmdCommand.Parameters.AddWithValue("@TEN_PHONG", txtTenPhong.Text);
            cmdCommand.Parameters.AddWithValue("@MA_BM", cboTenBoMon.SelectedValue.ToString());

            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsPhong.Clear();
            NhanDuLieu();
            cboTenBoMon.SelectedIndex = ViTriBoMon;
            GanDuLieu();
            ThemSua = 0;
            DieuKhienKhiBinhThuong();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if ((txtMaPhong.Text == "") || (txtTenPhong.Text == "") || (cboTenBoMon.SelectedIndex == -1))
                MessageBox.Show("Lỗi nhập dữ liệu!");
            else
                if ((ThemSua == 1) && (MyPublics.TonTaiKhoaChinh(txtMaPhong.Text, "MA_PHONG", "PHONG")) && (MyPublics.TonTaiKhoaChinh(cboTenBoMon.SelectedValue.ToString(), "MA_BM", "PHONG")))
                {
                    MessageBox.Show("Mã phòng thuộc bộ môn này đã tồn tại, vui lòng nhập mã khác!", "Thông báo");
                    txtMaPhong.Focus();
                }
                else
                    ThucThiLuu();
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            ThemSua = 0;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MyPublics.TonTaiKhoaChinh(txtMaPhong.Text, "MA_PHONG", "THIETBI"))
                MessageBox.Show("Phải xóa những thiết bị thuộc phòng này trước!");
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (blnDongY == DialogResult.Yes)
                {
                    string strDelete = "Delete PHONG Where MA_PHONG = @MA_PHONG";
                    if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                        MyPublics.conMyConnection.Open();
                    SqlCommand cmdCommand = new SqlCommand(strDelete, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MA_PHONG", txtMaPhong.Text);
                    cmdCommand.ExecuteNonQuery();
                    MyPublics.conMyConnection.Close();
                    dgvPhongTheoBoMon.Rows.RemoveAt(dgvPhongTheoBoMon.CurrentRow.Index);
                    GanDuLieu();
                }
            }
            DieuKhienKhiBinhThuong();
        }

        private void cboTenBoMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboTenBoMon.SelectedIndex != -1) && (ThemSua == 0))
            {
                dvPhong.RowFilter = "MA_BM like '" + cboTenBoMon.SelectedValue + "'";
                dgvPhongTheoBoMon.DataSource = dvPhong;
                GanDuLieu();
                if ((MyPublics.strQuyenSuDung == "Admin") && (MyPublics.strMaBoMon == cboTenBoMon.SelectedValue.ToString()))
                {
                    btnThem.Enabled = true;
                    btnChinhSua.Enabled = true;
                    btnXoa.Enabled = true;

                }
            }
        }



    }
}
