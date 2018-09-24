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
    public partial class frmThanhLyThietBi : Form
    {
        DataSet dsThietBi = new DataSet();
        DataSet dsLoaiThietBi = new DataSet();
        DataSet dsTinhTrang = new DataSet();
        DataView dvThietBi = new DataView();

        void DieuKhienKhiBinhThuong()
        {
            btnThanhLy.Enabled = true;
            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            txtMaThietBi.ReadOnly = true;
            cboTinhTrang.Enabled = false;
            txtGhiChu.ReadOnly = true;
            txtMaCanBo.ReadOnly = true;
            dtpNgayThanhLy.Enabled = false;
            cboLoaiThietBi.Enabled = true;
            dgvThietBi.Enabled = true;
            dgvThietBi.ForeColor = Color.Black;
            cboTinhTrang.SelectedIndex = -1;
        }
        
        void DieuKhienKhiThanhLy()
        {
            btnThanhLy.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = false;
            txtMaThietBi.ReadOnly = true;
            cboTinhTrang.Enabled = true;
            txtMaCanBo.ReadOnly = true;
            txtGhiChu.ReadOnly = false;
            cboLoaiThietBi.Enabled = false;
            dtpNgayThanhLy.Enabled = false;
            txtGhiChu.Focus();
            dgvThietBi.Enabled = false;
            dgvThietBi.ForeColor = Color.Gray;
            cboTinhTrang.SelectedIndex = 0;
        }
        void NhanDuLieu()
        {
            string strSelect = "exec Pro_ThietBi";
            MyPublics.OpenData(strSelect, dsThietBi, "ThietBi");
        }

        void GanDuLieu()
        {
            if (dvThietBi.Count > 0)
            {
                txtMaThietBi.Text = dgvThietBi[0, dgvThietBi.CurrentRow.Index].Value.ToString();
                txtMaCanBo.Text = MyPublics.strMaCanBo;
                dtpNgayThanhLy.Value = DateTime.Today;
                txtGhiChu.Text = "";
            }
            else
            {
                txtMaThietBi.Clear();
                txtMaCanBo.Clear();
            }
        }
        public frmThanhLyThietBi()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThanhLyThietBi_Load(object sender, EventArgs e)
        {
            string strSelect = "exec Pro_LoaiThietBi";
            MyPublics.OpenData(strSelect, dsLoaiThietBi, "LoaiThietBi");
            DataRow drMoiLoai = dsLoaiThietBi.Tables["LoaiThietBi"].NewRow();
            drMoiLoai["MA_LOAI"] = 0;
            drMoiLoai["TEN_LOAI"] = "Mọi loại";
            dsLoaiThietBi.Tables["LoaiThietBi"].Rows.InsertAt(drMoiLoai, 0);
            cboLoaiThietBi.DataSource = dsLoaiThietBi.Tables["LoaiThietBi"];
            cboLoaiThietBi.DisplayMember = "TEN_LOAI";
            cboLoaiThietBi.ValueMember = "MA_LOAI";
            dsTinhTrang.Tables.Add("DSTinhTrang");
            dsTinhTrang.Tables["DSTinhTrang"].Columns.Add("TinhTrang");
            dsTinhTrang.Tables["DSTinhTrang"].Rows.Add("Mới");
            dsTinhTrang.Tables["DSTinhTrang"].Rows.Add("Cũ");
            dsTinhTrang.Tables["DSTinhTrang"].Rows.Add("Hư");
            cboTinhTrang.DataSource = dsTinhTrang;
            cboTinhTrang.DisplayMember = "DSTinhTrang.TinhTrang";
            cboTinhTrang.ValueMember = "DSTinhTrang.TinhTrang";
            txtMaThietBi.MaxLength = 15;
            NhanDuLieu();
            dvThietBi.Table = dsThietBi.Tables["ThietBi"];
            if (cboLoaiThietBi.SelectedIndex != 0)
                dvThietBi.RowFilter = "MA_LOAI like '" + cboLoaiThietBi.SelectedValue + "' And TINHTRANG like 'Chờ thanh lý'";
            else
                dvThietBi.RowFilter = "MA_LOAI like '*' And TINHTRANG like 'Chờ thanh lý'";
            dgvThietBi.DataSource = dvThietBi;
            dgvThietBi.Width = 1158;
            dgvThietBi.AllowUserToAddRows = false;
            dgvThietBi.AllowUserToDeleteRows = false;
            dgvThietBi.Columns[0].Width = 120;
            dgvThietBi.Columns[0].HeaderText = "Mã số";
            dgvThietBi.Columns[1].Width = 95;
            dgvThietBi.Columns[1].HeaderText = "Mã Loại";
            dgvThietBi.Columns[2].Width = 100;
            dgvThietBi.Columns[2].HeaderText = "Tình Trạng";
            dgvThietBi.Columns[3].Width = 60;
            dgvThietBi.Columns[3].HeaderText = "TH Bảo Hành";
            dgvThietBi.Columns[4].Width = 60;
            dgvThietBi.Columns[4].HeaderText = "TL Hao Mòn";
            dgvThietBi.Columns[5].Width = 100;
            dgvThietBi.Columns[5].HeaderText = "Giá trị";
            dgvThietBi.Columns[6].Width = 270;
            dgvThietBi.Columns[6].HeaderText = "Tên Thiết Bị";
            dgvThietBi.Columns[7].Width = 80;
            dgvThietBi.Columns[7].HeaderText = "Mã Phòng";
            dgvThietBi.Columns[8].Width = 60;
            dgvThietBi.Columns[8].HeaderText = "Mã Bộ Môn";
            dgvThietBi.Columns[9].Width = 150;
            dgvThietBi.Columns[9].HeaderText = "Ngày Đặt";
            dgvThietBi.EditMode = DataGridViewEditMode.EditProgrammatically;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        void TimKiem()
        {
            if (cboLoaiThietBi.SelectedIndex != 0)
                dvThietBi.RowFilter = "MA_LOAI like '" + cboLoaiThietBi.SelectedValue + "' And TINHTRANG like 'Chờ thanh lý'";
            else
                dvThietBi.RowFilter = "MA_LOAI like '*' And TINHTRANG like 'Chờ thanh lý'";
            dgvThietBi.DataSource = dvThietBi;
        }

        private void cboLoaiThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {

            TimKiem();
            GanDuLieu();
        }

        private void dgvThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }

        private void btnThanhLy_Click(object sender, EventArgs e)
        {
            DieuKhienKhiThanhLy();
        }

        void ThucThiLuu()
        {
            string strInsert = "exec Pro_Insert_THIETBITHANHLY '" + txtMaThietBi.Text + "', '" + txtMaCanBo.Text + "', N'" + cboTinhTrang.SelectedValue + "', '" + txtGhiChu.Text + "'";
            //string strInsert = "Insert Into THIETBITHANHLY Values(@MaTB, @MaCanBo, @TinhTrang, GETDATE(), @GhiChu)";
            try
            {
                if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                    MyPublics.conMyConnection.Open();
                SqlCommand cmdCommand = new SqlCommand(strInsert, MyPublics.conMyConnection);
                //cmdCommand.Parameters.AddWithValue("@MaTB", txtMaThietBi.Text);
                //cmdCommand.Parameters.AddWithValue("@MaCanBo", txtMaCanBo.Text);
                //cmdCommand.Parameters.AddWithValue("@TinhTrang", cboTinhTrang.SelectedValue);
                //cmdCommand.Parameters.AddWithValue("@Ngay", dtpNgayThanhLy.Value);
                //cmdCommand.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                cmdCommand.ExecuteNonQuery();
                MyPublics.conMyConnection.Close();
                MessageBox.Show("Thanh lý thành công!", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra !", "Thông báo");
            }
            dsThietBi.Clear();
            NhanDuLieu();
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (MyPublics.TonTaiKhoaChinh(txtMaThietBi.Text, "MA_TB", "THIETBITHANHLY"))
                MessageBox.Show("Đã thanh lý thiết bị này rồi !", "Thông báo");
            else
                ThucThiLuu();
            
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            DieuKhienKhiBinhThuong();
            GanDuLieu();
        }
    }
}
