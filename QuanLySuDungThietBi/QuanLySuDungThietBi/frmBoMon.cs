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
    public partial class frmBoMon : Form
    {

        DataSet dsBoMon = new DataSet();
        SqlDataAdapter daBoMon = new SqlDataAdapter();
        BindingSource bsBoMon = new BindingSource();
        bool blnThem = false;

        void DieuKhienTheoViTri()
        {
            if (bsBoMon.Position > 0)
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }
            else
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            if (bsBoMon.Position < bsBoMon.Count - 1)
            {
                btnCuoi.Enabled = true;
                btnKe.Enabled = true;
            }
            else
            {
                btnCuoi.Enabled = false;
                btnKe.Enabled = false;
            }
            SoCanBo();
            txtViTri.Text = (bsBoMon.Position + 1) + " / " + bsBoMon.Count;
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
                btnXoa.Enabled = false;
                btnThem.Enabled = false;
                btnChinhSua.Enabled = false;

            }
            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            cboBoMon.Enabled = true;
            txtMaBoMon.ReadOnly = true;
            txtMaBoMon.BackColor = Color.White;
            txtTenBoMon.ReadOnly = true;
            txtTenBoMon.BackColor = Color.White;
            txtViTri.ReadOnly = true;
            txtViTri.BackColor = Color.White;
            txtSoCanBo.ReadOnly = true;
            txtSoCanBo.BackColor = Color.White;
            DieuKhienTheoViTri();
           
        }

        void DieuKhienKhiThem()
        {
            btnChinhSua.Enabled = false;
            btnCuoi.Enabled = false;
            btnDau.Enabled = false;
            btnKe.Enabled = false;
            btnTruoc.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtMaBoMon.Enabled = true;
            txtTenBoMon.ReadOnly = false;
            txtViTri.ReadOnly = true;
            txtMaBoMon.Clear();
            txtTenBoMon.Clear();
            txtSoCanBo.Clear();
            cboBoMon.Enabled = false;
            cboBoMon.SelectedIndex = -1;
            txtViTri.Text = bsBoMon.Count + " / " + bsBoMon.Count;
            txtViTri.BackColor = Color.White;
            txtSoCanBo.ReadOnly = true;
            txtSoCanBo.BackColor = Color.White;
            txtMaBoMon.Focus();
        }

        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnCuoi.Enabled = false;
            btnDau.Enabled = false;
            btnKe.Enabled = false;
            btnTruoc.Enabled = false;
            btnChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtMaBoMon.Enabled = false;
            txtTenBoMon.ReadOnly = false;
            txtViTri.ReadOnly = true;
            txtViTri.BackColor = Color.White;
            txtSoCanBo.ReadOnly = true;
            txtSoCanBo.BackColor = Color.White;
            cboBoMon.Enabled = false;
            txtTenBoMon.Focus();
        }

        void GanDuLieu()
        {
            txtMaBoMon.DataBindings.Add(new Binding("Text", bsBoMon, "MA_BM"));
            txtTenBoMon.DataBindings.Add(new Binding("Text", bsBoMon, "TEN_BM"));
        }

        void SoCanBo()
        {
            DataSet dsCanBo = new DataSet();
            DataView dvSoCanBo = new DataView();
            string strSelect = "Select * From CANBO";
            MyPublics.OpenData(strSelect, dsCanBo, "CANBO");
            dvSoCanBo.Table = dsCanBo.Tables["CANBO"];
            dvSoCanBo.RowFilter = "MA_BM Like '" + cboBoMon.SelectedValue.ToString() + "'";
            txtSoCanBo.Text = dvSoCanBo.Count.ToString();
        }

        public frmBoMon()
        {
            InitializeComponent();
        }

        private void frmBoMon_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * From BOMON";
            MyPublics.OpenData(strSelect, dsBoMon, "BOMON", daBoMon);
            bsBoMon.DataSource = dsBoMon;
            bsBoMon.DataMember = "BOMON";
            cboBoMon.DisplayMember = "TEN_BM";
            cboBoMon.ValueMember = "MA_BM";
            cboBoMon.DataSource = bsBoMon;
            txtMaBoMon.MaxLength = 5;
            txtTenBoMon.MaxLength=40;
            txtViTri.BackColor = Color.White;
            GanDuLieu();
            SoCanBo();
            DieuKhienKhiBinhThuong();
        }

        private void cboBoMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBoMon.SelectedIndex != -1)
            {
                bsBoMon.Position = cboBoMon.SelectedIndex;
                DieuKhienTheoViTri();
                SoCanBo();
               
            }

        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            bsBoMon.MoveFirst();
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
            btnKe.Enabled = true;
            btnCuoi.Enabled = true;
            txtViTri.Text = (bsBoMon.Position + 1) + " / " + bsBoMon.Count;
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bsBoMon.MoveLast();
            btnDau.Enabled = true;
            btnTruoc.Enabled = true;
            btnKe.Enabled = false;
            btnCuoi.Enabled = false;
            txtViTri.Text = bsBoMon.Count + " / " + bsBoMon.Count;
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            bsBoMon.MovePrevious();
            btnKe.Enabled = true;
            btnCuoi.Enabled = true;
            if (bsBoMon.Position == 0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            txtViTri.Text = (bsBoMon.Position + 1) + " / " + bsBoMon.Count;
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            bsBoMon.MoveNext();
            btnDau.Enabled = true;
            btnTruoc.Enabled = true;
            if (bsBoMon.Position == bsBoMon.Count-1)
            {
                btnKe.Enabled = false;
                btnCuoi.Enabled = false;
            }
            txtViTri.Text = (bsBoMon.Position + 1) + " / " + bsBoMon.Count;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            bsBoMon.AddNew();
            DieuKhienKhiThem();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            DieuKhienKhiChinhSua();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if ((txtMaBoMon.Text == "") || (txtTenBoMon.Text == ""))
                MessageBox.Show("Lỗi nhập dữ liệu!", "Lỗi");
            else
                if (blnThem == false)
                
                {
                    bsBoMon.EndEdit();
                    daBoMon.Update(dsBoMon, "BOMON");
                    dsBoMon.AcceptChanges();
                    blnThem = false;
                    DieuKhienKhiBinhThuong();
                }
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            bsBoMon.EndEdit();
            dsBoMon.RejectChanges();
            blnThem = false;
            DieuKhienKhiBinhThuong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MyPublics.TonTaiKhoaChinh(txtMaBoMon.Text, "MA_BM", "CANBO"))
                MessageBox.Show("Phải xóa cán bộ thuộc bộ môn này trước!", "Thông báo");
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn có muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (blnDongY == DialogResult.Yes)
                {
                    bsBoMon.RemoveCurrent();
                    daBoMon.Update(dsBoMon, "BOMON");
                    dsBoMon.AcceptChanges();
                }
            }
            DieuKhienKhiBinhThuong();
        }
    }
}
