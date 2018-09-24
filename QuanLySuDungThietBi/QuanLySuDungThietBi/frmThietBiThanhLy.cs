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
    public partial class frmThietBiThanhLy : Form
    {
        public frmThietBiThanhLy()
        {
            InitializeComponent();
        }


        DataSet dsThietBiThanhLy = new DataSet();
        SqlDataAdapter daThietBiThanhLy = new SqlDataAdapter();
        BindingSource bsThietBiThanhLy = new BindingSource();

        private void ThietBiThanhLy_Load(object sender, EventArgs e)
        {
            string strSelect = "exec Pro_ThietBiThanhLy";
            MyPublics.OpenData(strSelect, dsThietBiThanhLy, "ThietBiThanhLy", daThietBiThanhLy);
            bsThietBiThanhLy.DataSource = dsThietBiThanhLy;
            bsThietBiThanhLy.DataMember = "ThietBiThanhLy";
            txtViTri.Enabled = false;
            txtViTri.BackColor = Color.White;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }
        void DieuKhienTheoViTri()
        {
            if (bsThietBiThanhLy.Position > 0)
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }
            else
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            if (bsThietBiThanhLy.Position < bsThietBiThanhLy.Count - 1)
            {
                btnKe.Enabled = true;
                btnCuoi.Enabled = true;
            }
            else
            {
                btnKe.Enabled = false;
                btnCuoi.Enabled = false;
            }
            txtViTri.Text = (bsThietBiThanhLy.Position + 1) + " / " + bsThietBiThanhLy.Count;
        }
        void QuyenThanhLy()
        {
            if (MyPublics.strQuyenSuDung != "AllAdmin")
                if (MyPublics.strMaCanBo == txtMaCanBo.Text)
                    btnHuyThanhLy.Enabled = true;
                else
                    btnHuyThanhLy.Enabled = false;
        }
        void DieuKhienKhiBinhThuong()
        {
            if (MyPublics.strQuyenSuDung != "AllAdmin")
            {
                btnHuyThanhLy.Enabled = false;
            }
            else
            {
                btnHuyThanhLy.Enabled = true;
            }
            QuyenThanhLy();
            btnDong.Enabled = true;
            txtMaThietBi.ReadOnly = true;
            txtMaCanBo.ReadOnly = true;
            txtTinhTrang.ReadOnly = true;
            txtGhiChu.ReadOnly = true;
            dtpNgayThanhLy.Enabled = false;
            DieuKhienTheoViTri();
        }
        void GanDuLieu()
        {
            txtMaThietBi.DataBindings.Add(new Binding("Text", bsThietBiThanhLy, "MA_TB"));
            txtMaCanBo.DataBindings.Add(new Binding("Text", bsThietBiThanhLy, "MA_CB"));
            txtTinhTrang.DataBindings.Add(new Binding("Text", bsThietBiThanhLy, "TINHTRANG"));
            dtpNgayThanhLy.DataBindings.Add(new Binding("Value", bsThietBiThanhLy, "NGAY"));
            txtGhiChu.DataBindings.Add(new Binding("Text", bsThietBiThanhLy, "GHICHU"));
        }


        private void btnTruoc_Click(object sender, EventArgs e)
        {
            bsThietBiThanhLy.MovePrevious();
            btnKe.Enabled = true;
            btnCuoi.Enabled = true;
            if (bsThietBiThanhLy.Position == 0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            txtViTri.Text = (bsThietBiThanhLy.Position + 1) + " / " + bsThietBiThanhLy.Count;
            QuyenThanhLy();
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            bsThietBiThanhLy.MoveFirst();
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
            btnKe.Enabled = true;
            btnCuoi.Enabled = true;
            txtViTri.Text = (bsThietBiThanhLy.Position + 1) + " / " + bsThietBiThanhLy.Count;
            QuyenThanhLy();
        }


        private void btnKe_Click(object sender, EventArgs e)
        {
            bsThietBiThanhLy.MoveNext();
            btnDau.Enabled = true;
            btnTruoc.Enabled = true;
            if (bsThietBiThanhLy.Position == bsThietBiThanhLy.Count - 1)
            {
                btnKe.Enabled = false;
                btnCuoi.Enabled = false;
            }
            txtViTri.Text = (bsThietBiThanhLy.Position + 1) + " / " + bsThietBiThanhLy.Count;
            QuyenThanhLy();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bsThietBiThanhLy.MoveLast();
            btnDau.Enabled = true;
            btnTruoc.Enabled = true;
            btnKe.Enabled = false;
            btnCuoi.Enabled = false;
            txtViTri.Text = (bsThietBiThanhLy.Position + 1) + " / " + bsThietBiThanhLy.Count;
            QuyenThanhLy();
        }

        private void btnHuyThanhLy_Click(object sender, EventArgs e)
        {
            DialogResult blnDongY;
            blnDongY = MessageBox.Show("Bạn thật sự muốn hủy thanh lý ?", "Xác nhận", MessageBoxButtons.YesNo);
            if (blnDongY == DialogResult.Yes)
            {
                string strDelete = "exec Pro_Delete_THIETBITHANHLY '" + txtMaThietBi.Text + "'";

                if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                    MyPublics.conMyConnection.Open();
                SqlCommand cmdCommand = new SqlCommand(strDelete, MyPublics.conMyConnection);
                cmdCommand.ExecuteNonQuery();
                MyPublics.conMyConnection.Close();

                bsThietBiThanhLy.RemoveCurrent();
                //daThietBiThanhLy.Update(dsThietBiThanhLy, "ThietBiThanhLy");
                //dsThietBiThanhLy.AcceptChanges();
            }

            DieuKhienKhiBinhThuong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
