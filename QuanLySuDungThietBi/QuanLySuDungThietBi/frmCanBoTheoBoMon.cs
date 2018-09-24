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
    public partial class frmCanBoTheoBoMon : Form
    {
        DataSet dsCanBo = new DataSet();
        DataSet dsBoMon = new DataSet();
        DataView dvCanBo = new DataView();
        DataSet dsQuyenSudung = new DataSet();
        int ViTriBoMon, ThemSua=0;

        void NhanDuLieu()
        {
            string strSelect = "Select * From CANBO";
            MyPublics.OpenData(strSelect, dsCanBo, "CANBO");
        }

        void GanDuLieu()
        {
            if (dvCanBo.Count > 0)
            {
                txtMaCanBo.Text = dgvCanBo[0, dgvCanBo.CurrentRow.Index].Value.ToString();
                txtTenCanBo.Text = dgvCanBo[1, dgvCanBo.CurrentRow.Index].Value.ToString();
                cboQuyenSuDung.SelectedIndex = cboQuyenSuDung.FindString(dgvCanBo[4, dgvCanBo.CurrentRow.Index].Value.ToString());

            }
            else
            {
                txtMaCanBo.Clear();
                txtTenCanBo.Clear();
                cboQuyenSuDung.SelectedIndex = -1;
            }
        }


        public frmCanBoTheoBoMon()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCanBoTheoBoMon_Load(object sender, EventArgs e)
        {
            string strSelect = "Select MA_BM, TEN_BM From BOMON";
            MyPublics.OpenData(strSelect, dsBoMon, "BOMON");
            cboTenBoMon.DataSource = dsBoMon.Tables["BOMON"];
            cboTenBoMon.DisplayMember = "TEN_BM";
            cboTenBoMon.ValueMember = "MA_BM";
            dsQuyenSudung.Tables.Add("DSQuyenSuDung");
            dsQuyenSudung.Tables["DSQuyenSuDung"].Columns.Add("QUYENSD");
            dsQuyenSudung.Tables["DSQuyenSuDung"].Rows.Add("AllAdmin");
            dsQuyenSudung.Tables["DSQuyenSuDung"].Rows.Add("Admin");
            dsQuyenSudung.Tables["DSQuyenSuDung"].Rows.Add("User");
            cboQuyenSuDung.DataSource = dsQuyenSudung;
            cboQuyenSuDung.DisplayMember = "DSQuyenSuDung.QUYENSD";
            cboQuyenSuDung.ValueMember = "DSQuyenSuDung.QUYENSD";
            txtMaCanBo.MaxLength = 5;
            txtTenCanBo.MaxLength = 30;
            NhanDuLieu();
            dvCanBo.Table = dsCanBo.Tables["CANBO"];
            dvCanBo.RowFilter = "MA_BM like '" + cboTenBoMon.SelectedValue + "'";
            dgvCanBo.DataSource = dvCanBo;
            dgvCanBo.Width = 808;
            dgvCanBo.AllowUserToAddRows = false;
            dgvCanBo.AllowUserToDeleteRows = false;
            dgvCanBo.Columns[0].Width=117;
            dgvCanBo.Columns[0].HeaderText="Mã cán bộ";
            dgvCanBo.Columns[1].Width=220;
            dgvCanBo.Columns[1].HeaderText="Tên cán bộ";
            dgvCanBo.Columns[2].Width=150;
            dgvCanBo.Columns[2].HeaderText="Bộ môn";
            dgvCanBo.Columns[3].Width=120;
            dgvCanBo.Columns[3].HeaderText="Mật khẩu";
            dgvCanBo.Columns[4].Width=140;
            dgvCanBo.Columns[4].HeaderText="Quyền sử dụng";

            dgvCanBo.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvCanBo.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvCanBo_CellFormatting);
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void dgvCanBo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }

        private void dgvCanBo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSua = 1;
            DieuKhienKhiThem();
        }

        void ThucThiLuu()
        {
            string strSql, strMatKhau;
            if (ThemSua == 1)
                strSql = "Insert Into CANBO Values(@MA_CB, @TEN_CB, @MA_BM, @MATKHAU, @QUYENSD)";
            else
                strSql = "Update CANBO Set TEN_CB = @TEN_CB, MA_BM = @MA_BM, MATKHAU = @MATKHAU, QUYENSD = @QUYENSD Where MA_CB = @MA_CB";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MA_CB", txtMaCanBo.Text);
            cmdCommand.Parameters.AddWithValue("@TEN_CB", txtTenCanBo.Text);
            cmdCommand.Parameters.AddWithValue("@MA_BM", cboTenBoMon.SelectedValue.ToString());
            if (ThemSua == 1)
            {
                strMatKhau = txtMaCanBo.Text;
                cmdCommand.Parameters.AddWithValue("@MATKHAU", strMatKhau);
            }
            else
            {
                cmdCommand.Parameters.AddWithValue("@MATKHAU", txtMaCanBo.Text);
            }
            cmdCommand.Parameters.AddWithValue("@QUYENSD", cboQuyenSuDung.SelectedValue.ToString());
            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsCanBo.Clear();
            NhanDuLieu();
            cboTenBoMon.SelectedIndex = ViTriBoMon;
            GanDuLieu();
            ThemSua = 0;
            DieuKhienKhiBinhThuong();
        }



        void DieuKhienKhiThem()
        {
            
            txtMaCanBo.Focus();
            txtMaCanBo.Clear();
            txtTenCanBo.Clear();
            txtMaCanBo.ReadOnly = false;
            txtTenCanBo.ReadOnly = false;
            cboQuyenSuDung.Enabled = true;
            cboQuyenSuDung.SelectedValue = -1;
            cboTenBoMon.Enabled = false;
            btnChinhSua.Enabled = false;
            btnXoa.Enabled = false;
            dgvCanBo.ReadOnly = true;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnThem.Enabled = false;
            if ((MyPublics.strQuyenSuDung == "Admin"))
            {
                cboQuyenSuDung.SelectedIndex = 2;
                cboQuyenSuDung.Enabled = false;
            }
        }

        void DieuKhienKhiBinhThuong()
        {

            if (MyPublics.strQuyenSuDung == "AllAdmin")
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnChinhSua.Enabled = true;
                
            }
            else
            {
                if ((MyPublics.strQuyenSuDung == "Admin") && (MyPublics.strMaBoMon == cboTenBoMon.SelectedValue.ToString()))
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
                
            }
            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            txtMaCanBo.ReadOnly = true;
            txtTenCanBo.ReadOnly = true;
            txtMaCanBo.BackColor = Color.White;
            txtTenCanBo.BackColor = Color.White;
            cboTenBoMon.Enabled = true;
            cboQuyenSuDung.Enabled = false;
            cboQuyenSuDung.BackColor = Color.White;
            
        }

        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = true;
            txtMaCanBo.Enabled = false;
            txtTenCanBo.ReadOnly = false;
            cboTenBoMon.Enabled = false;
            cboQuyenSuDung.Enabled = true;
            btnChinhSua.Enabled = false;
            if ((MyPublics.strQuyenSuDung == "Admin"))
            {
                cboQuyenSuDung.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if ((txtMaCanBo.Text == "") || (txtTenCanBo.Text == "") || (cboTenBoMon.SelectedIndex == -1) || (cboQuyenSuDung.SelectedIndex == -1))
                MessageBox.Show("Lỗi nhập dữ liệu!");
            else
                if ((ThemSua == 1) && (MyPublics.TonTaiKhoaChinh(txtMaCanBo.Text, "MA_CB", "CANBO")))
                {
                    MessageBox.Show("Mã cán bộ này đã tồn tại, vui lòng nhập mã khác!");
                    txtMaCanBo.Focus();
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

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            ThemSua = 2;
            ViTriBoMon = cboTenBoMon.SelectedIndex;
            DieuKhienKhiChinhSua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MyPublics.TonTaiKhoaChinh(txtMaCanBo.Text, "MA_CB", "THIETBITHANHLY"))
                MessageBox.Show("Phải xóa những thiết bị do cán bộ này thanh lý trước!");
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (blnDongY == DialogResult.Yes)
                {
                    string strDelete = "Delete CANBO Where MA_CB = @MA_CB";
                    if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                        MyPublics.conMyConnection.Open();
                    SqlCommand cmdCommand = new SqlCommand(strDelete, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MA_CB", txtMaCanBo.Text);
                    cmdCommand.ExecuteNonQuery();
                    MyPublics.conMyConnection.Close();
                    dgvCanBo.Rows.RemoveAt(dgvCanBo.CurrentRow.Index);
                    GanDuLieu();
                }
            }
            DieuKhienKhiBinhThuong();
        }

        private void cboTenBoMon_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ((cboTenBoMon.SelectedIndex != -1) && (ThemSua == 0))
            {
                dvCanBo.RowFilter = "MA_BM like '" + cboTenBoMon.SelectedValue + "'";
                dgvCanBo.DataSource = dvCanBo;
                GanDuLieu();
                if ((MyPublics.strQuyenSuDung == "Admin") && (MyPublics.strMaBoMon == cboTenBoMon.SelectedValue.ToString()))
                {
                    btnThem.Enabled = true;
                    btnChinhSua.Enabled = true;
                    cboQuyenSuDung.Enabled = false;
                    btnXoa.Enabled = true;
                }
                else
                {
                    btnThem.Enabled = false;
                    btnChinhSua.Enabled = false;
                    cboQuyenSuDung.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
        }


    }
}
