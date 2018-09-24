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
    public partial class frmLoaiThietBi : Form
    {
        public frmLoaiThietBi()
        {
            InitializeComponent();
        }

        DataSet dsLoaiThietBi = new DataSet();
        SqlDataAdapter daLoaiThietBi = new SqlDataAdapter();
        BindingSource bsLoaiThietBi = new BindingSource();
        bool blnThem = false;
        void DieuKhienTheoViTri()
        {
            if (bsLoaiThietBi.Position > 0)
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }
            else
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            if (bsLoaiThietBi.Position < bsLoaiThietBi.Count - 1)
            {
                btnKe.Enabled = true;
                btnCuoi.Enabled = true;
            }
            else
            {
                btnKe.Enabled = false;
                btnCuoi.Enabled = false;
            }
            txtViTri.Text = (bsLoaiThietBi.Position + 1) + " / " + bsLoaiThietBi.Count;
        }
        void DieuKhienKhiBinhThuong()
        {
            if (MyPublics.strQuyenSuDung != "AllAdmin")
            {
                btnThem.Enabled = false;
                btnChinhSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnThem.Enabled = true;
                btnChinhSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            txtMaLoai.ReadOnly = true;
            txtTenLoai.ReadOnly = true;
            DieuKhienTheoViTri();
        }

        void DieuKhienKhiThem()
        {
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
            btnKe.Enabled = false;
            btnCuoi.Enabled = false;
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtMaLoai.ReadOnly = false;
            txtTenLoai.ReadOnly = false;
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtViTri.Text = bsLoaiThietBi.Count + " / " + bsLoaiThietBi.Count;
            txtMaLoai.Focus();
        }

        void DieuKhienKhiChinhSua()
        {
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
            btnKe.Enabled = false;
            btnCuoi.Enabled = false;
            btnThem.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtMaLoai.ReadOnly = true;
            txtTenLoai.ReadOnly = false;
            txtViTri.Text = bsLoaiThietBi.Count + " / " + bsLoaiThietBi.Count;
            txtMaLoai.Focus();
        }
        void GanDuLieu()
        {
            txtMaLoai.DataBindings.Add(new Binding("Text", bsLoaiThietBi, "MA_LOAI"));
            txtTenLoai.DataBindings.Add(new Binding("Text", bsLoaiThietBi, "TEN_LOAI"));
        }
        private void frmLoaiThietBi_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * From LOAITHIETBI";
            MyPublics.OpenData(strSelect, dsLoaiThietBi, "LoaiThietBi", daLoaiThietBi);
            bsLoaiThietBi.DataSource = dsLoaiThietBi;
            bsLoaiThietBi.DataMember = "LoaiThietBi";
            txtMaLoai.MaxLength = 15;
            txtTenLoai.MaxLength = 200;
            txtViTri.Enabled = false;
            txtViTri.BackColor = Color.White;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            bsLoaiThietBi.MovePrevious();
            btnKe.Enabled = true;
            btnCuoi.Enabled = true;
            if (bsLoaiThietBi.Position == 0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            txtViTri.Text = (bsLoaiThietBi.Position + 1) + " / " + bsLoaiThietBi.Count;
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            bsLoaiThietBi.MoveFirst();
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
            btnKe.Enabled = true;
            btnCuoi.Enabled = true;
            txtViTri.Text = (bsLoaiThietBi.Position + 1) + " / " + bsLoaiThietBi.Count;
        }

        
        private void btnKe_Click(object sender, EventArgs e)
        {
            bsLoaiThietBi.MoveNext();
            btnDau.Enabled = true;
            btnTruoc.Enabled = true;
            if (bsLoaiThietBi.Position == bsLoaiThietBi.Count - 1)
            {
                btnKe.Enabled = false;
                btnCuoi.Enabled = false;
            }
            txtViTri.Text = (bsLoaiThietBi.Position + 1) + " / " + bsLoaiThietBi.Count;
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bsLoaiThietBi.MoveLast();
            btnDau.Enabled = true;
            btnTruoc.Enabled = true;
            btnKe.Enabled = false;
            btnCuoi.Enabled = false;
            txtViTri.Text = (bsLoaiThietBi.Position + 1) + " / " + bsLoaiThietBi.Count;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            bsLoaiThietBi.AddNew();
            DieuKhienKhiThem();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            DieuKhienKhiChinhSua();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if ((txtMaLoai.Text == "") || (txtTenLoai.Text == ""))
                MessageBox.Show("Lỗi nhập dữ liệu !");
            else
                if (blnThem && MyPublics.TonTaiKhoaChinh(txtMaLoai.Text, "MA_LOAI", "LoaiThietBi"))
                {
                    MessageBox.Show("Mã loại này đã có rồi!");
                    txtMaLoai.Focus();
                }
                else
                {
                    bsLoaiThietBi.EndEdit();
                    daLoaiThietBi.Update(dsLoaiThietBi, "LoaiThietBi");
                    dsLoaiThietBi.AcceptChanges();
                    blnThem = false;
                    DieuKhienKhiBinhThuong();
                }
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            bsLoaiThietBi.EndEdit();
            dsLoaiThietBi.RejectChanges();
            blnThem = false;
            DieuKhienKhiBinhThuong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MyPublics.TonTaiKhoaChinh(txtMaLoai.Text, "MA_LOAI", "THIETBI"))
                MessageBox.Show("Phải xóa thiết bị thuộc loại này trước !");
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn thật sự muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo);
                if (blnDongY == DialogResult.Yes)
                {
                    bsLoaiThietBi.RemoveCurrent();
                    daLoaiThietBi.Update(dsLoaiThietBi, "LoaiThietBi");
                    dsLoaiThietBi.AcceptChanges();
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
