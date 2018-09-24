using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLySuDungThietBi
{
    public partial class frmThietBiTheoLoai : Form
    {
        public frmThietBiTheoLoai()
        {
            InitializeComponent();
        }

        DataSet dsThietBi = new DataSet();
        DataSet dsLoaiThietBi = new DataSet();
        DataSet dsPhong = new DataSet();
        DataView dvThietBi = new DataView();
        DataSet dsTinhTrang = new DataSet();
        int ViTriThietBi, ThemSua = 0;


        void QuyenAdmin()
        {
            if (ThemSua == 0)
                if ((MyPublics.strQuyenSuDung != "AllAdmin") && (MyPublics.strQuyenSuDung != "User"))
                    if ((MyPublics.strQuyenSuDung == "Admin") && (MyPublics.strMaBoMon == txtBoMon.Text))
                    {
                        btnChinhSua.Enabled = true;
                        btnXoa.Enabled = true;
                    }
                    else
                    {
                        btnChinhSua.Enabled = false;
                        btnXoa.Enabled = false;
                    }
        }
        void DieuKhienKhiBinhThuong()
        {
            if (MyPublics.strQuyenSuDung == "AllAdmin")
            {
                btnThem.Enabled = true;
                btnChinhSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
                btnChinhSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            QuyenAdmin();
            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            txtBoMon.ReadOnly = true;
            txtGiaTri.ReadOnly = true; 
            txtMaPhong.ReadOnly = true;
            txtMaThietBi.ReadOnly = true;
            txtTenThietBi.ReadOnly = true; 
            txtThoiGianBaoHanh.ReadOnly = true;
            txtTiLeHaoMon.ReadOnly = true;
            cboTinhTrang.Enabled = false;
            cboTenPhong.Enabled = false;
            dtpNgayDatThietBi.Enabled = false;
            cboLoaiThietBi.Enabled = true;
            dgvThietBi.Enabled = true;
            dgvThietBi.ForeColor = Color.Black;
        }

        void DieuKhienKhiThem()
        {
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtBoMon.ReadOnly = true;
            txtGiaTri.ReadOnly = false;
            txtMaPhong.ReadOnly = true;
            txtMaThietBi.ReadOnly = false;
            txtTenThietBi.ReadOnly = false;
            txtThoiGianBaoHanh.ReadOnly = false;
            txtTiLeHaoMon.ReadOnly = false;
            cboTinhTrang.Enabled = true;
            cboTenPhong.Enabled = true;
            dtpNgayDatThietBi.Enabled = true;
            cboLoaiThietBi.Enabled = true;
            txtGiaTri.Clear();
            txtMaThietBi.Clear();
            txtTenThietBi.Clear();
            txtThoiGianBaoHanh.Clear();
            txtTiLeHaoMon.Clear();
            dtpNgayDatThietBi.Value = DateTime.Today;
            txtMaThietBi.Focus();
            btnXoa.Enabled = false;
            dgvThietBi.Enabled = false;
            dgvThietBi.ForeColor = Color.Gray;
        }

        void DieuKhienKhiChinhSua()
        {
            btnChinhSua.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtBoMon.ReadOnly = true;
            txtGiaTri.ReadOnly = false;
            txtMaPhong.ReadOnly = true;
            txtMaThietBi.ReadOnly = true;
            txtTenThietBi.ReadOnly = false;
            txtThoiGianBaoHanh.ReadOnly = false;
            txtTiLeHaoMon.ReadOnly = false;
            cboTinhTrang.Enabled = true;
            cboTenPhong.Enabled = true;
            dtpNgayDatThietBi.Enabled = true;
            cboLoaiThietBi.Enabled = true;
            cboTinhTrang.Focus();
            dgvThietBi.Enabled = false;
            dgvThietBi.ForeColor = Color.Gray;
            if ((MyPublics.strQuyenSuDung != "AllAdmin") && (MyPublics.strQuyenSuDung != "User"))
                if ((MyPublics.strQuyenSuDung == "Admin") && (MyPublics.strMaBoMon == txtBoMon.Text))
                {
                    cboTenPhong.Enabled = false;
                }
        }

        void NhanDuLieu()
        {
            string strSelect = "Select * From THIETBI";
            MyPublics.OpenData(strSelect, dsThietBi, "ThietBi");
        }

        void GanDuLieu()
        {
            if (dvThietBi.Count > 0)
            {
                txtMaThietBi.Text = dgvThietBi[0, dgvThietBi.CurrentRow.Index].Value.ToString();
                txtThoiGianBaoHanh.Text = dgvThietBi[3, dgvThietBi.CurrentRow.Index].Value.ToString();
                txtTiLeHaoMon.Text = dgvThietBi[4, dgvThietBi.CurrentRow.Index].Value.ToString();
                txtGiaTri.Text = dgvThietBi[5, dgvThietBi.CurrentRow.Index].Value.ToString();
                txtTenThietBi.Text = dgvThietBi[6, dgvThietBi.CurrentRow.Index].Value.ToString();
                dtpNgayDatThietBi.Value = DateTime.Parse(dgvThietBi[9, dgvThietBi.CurrentRow.Index].Value.ToString());
                txtMaPhong.Text = dgvThietBi[7, dgvThietBi.CurrentRow.Index].Value.ToString();
                txtBoMon.Text = dgvThietBi[8, dgvThietBi.CurrentRow.Index].Value.ToString();
                cboTenPhong.SelectedValue = txtMaPhong.Text + "," + txtBoMon.Text;
                cboTinhTrang.SelectedValue = dgvThietBi[2, dgvThietBi.CurrentRow.Index].Value.ToString();
            }
            else
            {
                txtMaThietBi.Clear();
                txtThoiGianBaoHanh.Clear();
                txtTiLeHaoMon.Clear();
                txtGiaTri.Clear();
                txtTenThietBi.Clear();
                dtpNgayDatThietBi.Value = DateTime.Today;
            }
        }
        private void frmThietBiTheoLoai_Load(object sender, EventArgs e)
        {
            string strSelect = "Select MA_LOAI, TEN_LOAI From LOAITHIETBI";
            MyPublics.OpenData(strSelect, dsLoaiThietBi, "LoaiThietBi");
            cboLoaiThietBi.DataSource = dsLoaiThietBi.Tables["LoaiThietBi"];
            cboLoaiThietBi.DisplayMember = "TEN_LOAI";
            cboLoaiThietBi.ValueMember = "MA_LOAI";
            strSelect = "Select MA_PHONG, MA_BM, TEN_PHONG From PHONG";
            try
            {
                if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                    MyPublics.conMyConnection.Open();
                SqlCommand cmdCommand = new SqlCommand(strSelect, MyPublics.conMyConnection);
                SqlDataReader drPhong = cmdCommand.ExecuteReader();
                dsPhong.Tables.Add("Phong");
                dsPhong.Tables["Phong"].Columns.Add("KHOA_CHINH");
                dsPhong.Tables["Phong"].Columns.Add("TEN_PHONG");
                if (drPhong.HasRows)
                    while (drPhong.Read())
                        dsPhong.Tables["Phong"].Rows.Add(drPhong.GetString(0) + "," + drPhong.GetString(1), drPhong.GetString(2));
                MyPublics.conMyConnection.Close();
            }
            catch (Exception)
            {
            }
            cboTenPhong.DataSource = dsPhong.Tables["Phong"];
            cboTenPhong.DisplayMember = "TEN_PHONG";
            cboTenPhong.ValueMember = "KHOA_CHINH";
            dsTinhTrang.Tables.Add("DSTinhTrang");
            dsTinhTrang.Tables["DSTinhTrang"].Columns.Add("TinhTrang");
            dsTinhTrang.Tables["DSTinhTrang"].Rows.Add("Chờ thanh lý");
            dsTinhTrang.Tables["DSTinhTrang"].Rows.Add("Mới");
            dsTinhTrang.Tables["DSTinhTrang"].Rows.Add("Cũ");
            dsTinhTrang.Tables["DSTinhTrang"].Rows.Add("Hư");
            cboTinhTrang.DataSource = dsTinhTrang;
            cboTinhTrang.DisplayMember = "DSTinhTrang.TinhTrang";
            cboTinhTrang.ValueMember = "DSTinhTrang.TinhTrang";
            txtMaThietBi.MaxLength = 15;
            txtTenThietBi.MaxLength = 200;
            NhanDuLieu();
            dvThietBi.Table = dsThietBi.Tables["ThietBi"];
            dvThietBi.RowFilter = "MA_LOAI like '" + cboLoaiThietBi.SelectedValue + "'";
            dgvThietBi.DataSource = dvThietBi;
            dgvThietBi.Width = 1250;
            dgvThietBi.AllowUserToAddRows = false;
            dgvThietBi.AllowUserToDeleteRows = false;
            dgvThietBi.Columns[0].Width = 130;
            dgvThietBi.Columns[0].HeaderText = "Mã số";
            dgvThietBi.Columns[1].Width = 115;
            dgvThietBi.Columns[1].HeaderText = "Mã Loại";
            dgvThietBi.Columns[2].Width = 120;
            dgvThietBi.Columns[2].HeaderText = "Tình Trạng";
            dgvThietBi.Columns[3].Width = 100;
            dgvThietBi.Columns[3].HeaderText = "TH Bảo Hành";
            dgvThietBi.Columns[4].Width = 100;
            dgvThietBi.Columns[4].HeaderText = "TL Hao Mòn";
            dgvThietBi.Columns[5].Width = 100;
            dgvThietBi.Columns[5].HeaderText = "Giá trị";
            dgvThietBi.Columns[6].Width = 250;
            dgvThietBi.Columns[6].HeaderText = "Tên Thiết Bị";
            dgvThietBi.Columns[7].Width = 100;
            dgvThietBi.Columns[7].HeaderText = "Mã Phòng";
            dgvThietBi.Columns[8].Width = 100;
            dgvThietBi.Columns[8].HeaderText = "Mã Bộ Môn";
            dgvThietBi.Columns[9].Width = 170;
            dgvThietBi.Columns[9].HeaderText = "Ngày Đặt";
            dgvThietBi.EditMode = DataGridViewEditMode.EditProgrammatically;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void dgvThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
            QuyenAdmin();
        }

        private void cboLoaiThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboLoaiThietBi.SelectedIndex != -1) && (ThemSua == 0))
            {
                dvThietBi.RowFilter = "MA_LOAI like '" + cboLoaiThietBi.SelectedValue + "'";
                dgvThietBi.DataSource = dvThietBi;
                GanDuLieu();   
            }
            QuyenAdmin();
        }

        private void cboTenPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboTenPhong.SelectedIndex != -1) && (ThemSua > 0))
            {
                string strKhoaChinh = cboTenPhong.SelectedValue.ToString();
                txtBoMon.Text = strKhoaChinh.Substring(strKhoaChinh.IndexOf(',') + 1);
                txtMaPhong.Text = strKhoaChinh.Substring(0, strKhoaChinh.Length - (txtBoMon.Text.Length + 1));
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSua = 1;
            DieuKhienKhiThem();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            ThemSua = 2;
            DieuKhienKhiChinhSua();
        }

        void ThucThiLuu()
        {
            string strSql;
            if (ThemSua == 1)
                strSql = "Insert Into THIETBI Values(@MaTB, @MaLoai, @TinhTrang, @TGBaoHanh, @TLHaoMon, @GiaTri, @TenTB, @MaPhong, @MaBM, @NgayDat)";
            else
                strSql = "Update THIETBI Set MA_LOAI = @MaLoai, TINHTRANG = @TinhTrang, TGBAOHANH = @TGBaoHanh, TILEHAOMON = @TLHaoMon, GIATRI = @GiaTri, TEN_TB = @TenTB, MA_PHONG = @MaPhong, MA_BM = @MaBM, NGAYDAT_TB = @NgayDat Where MA_TB = @MaTB";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MaTB", txtMaThietBi.Text);
            cmdCommand.Parameters.AddWithValue("@MaLoai", cboLoaiThietBi.SelectedValue.ToString());
            cmdCommand.Parameters.AddWithValue("@TinhTrang", cboTinhTrang.SelectedValue.ToString());
            cmdCommand.Parameters.AddWithValue("@TGBaoHanh", txtThoiGianBaoHanh.Text);
            cmdCommand.Parameters.AddWithValue("@TLHaoMon", txtTiLeHaoMon.Text);
            cmdCommand.Parameters.AddWithValue("@GiaTri", txtGiaTri.Text);
            cmdCommand.Parameters.AddWithValue("@TenTB", txtTenThietBi.Text);
            cmdCommand.Parameters.AddWithValue("@MaPhong", txtMaPhong.Text);
            cmdCommand.Parameters.AddWithValue("@MaBM", txtBoMon.Text);
            cmdCommand.Parameters.AddWithValue("@NgayDat", dtpNgayDatThietBi.Value);
            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsThietBi.Clear();
            NhanDuLieu();
            ViTriThietBi = cboLoaiThietBi.SelectedIndex;
            cboLoaiThietBi.SelectedIndex = -1;
            ThemSua = 0;
            DieuKhienKhiBinhThuong();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            float TGBaoHanh, TLHaoMon, GiaTri;
            if ((txtMaThietBi.Text == "") || (txtBoMon.Text == "") || (txtGiaTri.Text == "")
                || (txtMaPhong.Text == "") || (txtTenThietBi.Text == "") || (txtThoiGianBaoHanh.Text == "")
                || (txtTiLeHaoMon.Text == "") || (cboTinhTrang.SelectedIndex == -1) || (cboLoaiThietBi.SelectedIndex == -1)
                || (!float.TryParse(txtThoiGianBaoHanh.Text, out TGBaoHanh)) || (TGBaoHanh < 0)
                || (!float.TryParse(txtTiLeHaoMon.Text, out TLHaoMon)) || (TLHaoMon < 0)
                || (!float.TryParse(txtGiaTri.Text, out GiaTri)) || (GiaTri < 0))
                MessageBox.Show("Lỗi nhập dữ liệu !");
            else
                if ((ThemSua == 1) && ((MyPublics.TonTaiKhoaChinh(txtMaThietBi.Text, "MA_TB", "THIETBI"))))
                {
                    MessageBox.Show("Mã thiết bị này đã có rồi !");
                    txtMaThietBi.Focus();
                }
                else
                {
                    ThucThiLuu();
                    cboLoaiThietBi.SelectedIndex = ViTriThietBi;
                }
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            ThemSua = 0;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MyPublics.TonTaiKhoaChinh(txtMaThietBi.Text, "MA_TB", "THIETBITHANHLY"))
                MessageBox.Show("Thiết bị này đang thanh lý, vui lòng hủy thanh lý trước khi xóa !", "Thông báo");
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn thật sự muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo);
                if (blnDongY == DialogResult.Yes)
                {
                    string strSelect = "Delete THIETBI Where MA_TB = @MaThietBi";
                    if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                        MyPublics.conMyConnection.Open();
                    SqlCommand cmdCommand = new SqlCommand(strSelect, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MaThietBi", txtMaThietBi.Text);
                    cmdCommand.ExecuteNonQuery();
                    MyPublics.conMyConnection.Close();
                    dgvThietBi.Rows.RemoveAt(dgvThietBi.CurrentRow.Index);
                    GanDuLieu();
                }
            }
            DieuKhienKhiBinhThuong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
