namespace QuanLySuDungThietBi
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuQuanLySuDungThietBi = new System.Windows.Forms.MenuStrip();
            this.mnuCanBo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCanBoTheoBoMon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBoMon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThietBi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoaiThietBi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThietBiTheoLoai = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThietBiThanhLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChucNang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThanhLyThietBi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSCanBo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSThietBi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTienIch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoatDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLySuDungThietBi.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuQuanLySuDungThietBi
            // 
            this.mnuQuanLySuDungThietBi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuQuanLySuDungThietBi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCanBo,
            this.mnuBoMon,
            this.mnuPhong,
            this.mnuThietBi,
            this.mnuChucNang,
            this.mnuTienIch,
            this.mnuGioiThieu});
            this.mnuQuanLySuDungThietBi.Location = new System.Drawing.Point(0, 0);
            this.mnuQuanLySuDungThietBi.Name = "mnuQuanLySuDungThietBi";
            this.mnuQuanLySuDungThietBi.Size = new System.Drawing.Size(854, 25);
            this.mnuQuanLySuDungThietBi.TabIndex = 0;
            this.mnuQuanLySuDungThietBi.Text = "menuStrip1";
            // 
            // mnuCanBo
            // 
            this.mnuCanBo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCanBoTheoBoMon});
            this.mnuCanBo.Name = "mnuCanBo";
            this.mnuCanBo.Size = new System.Drawing.Size(61, 21);
            this.mnuCanBo.Text = "Cán Bộ";
            // 
            // mnuCanBoTheoBoMon
            // 
            this.mnuCanBoTheoBoMon.Name = "mnuCanBoTheoBoMon";
            this.mnuCanBoTheoBoMon.Size = new System.Drawing.Size(200, 22);
            this.mnuCanBoTheoBoMon.Text = "Cán Bộ Theo Bộ Môn";
            this.mnuCanBoTheoBoMon.Click += new System.EventHandler(this.mnuCanBoTheoBoMon_Click);
            // 
            // mnuBoMon
            // 
            this.mnuBoMon.Name = "mnuBoMon";
            this.mnuBoMon.Size = new System.Drawing.Size(65, 21);
            this.mnuBoMon.Text = "Bộ môn";
            this.mnuBoMon.Click += new System.EventHandler(this.mnuBoMon_Click);
            // 
            // mnuPhong
            // 
            this.mnuPhong.Name = "mnuPhong";
            this.mnuPhong.Size = new System.Drawing.Size(57, 21);
            this.mnuPhong.Text = "Phòng";
            this.mnuPhong.Click += new System.EventHandler(this.mnuPhong_Click);
            // 
            // mnuThietBi
            // 
            this.mnuThietBi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLoaiThietBi,
            this.mnuThietBiTheoLoai,
            this.mnuThietBiThanhLy});
            this.mnuThietBi.Name = "mnuThietBi";
            this.mnuThietBi.Size = new System.Drawing.Size(63, 21);
            this.mnuThietBi.Text = "Thiết bị";
            // 
            // mnuLoaiThietBi
            // 
            this.mnuLoaiThietBi.Name = "mnuLoaiThietBi";
            this.mnuLoaiThietBi.Size = new System.Drawing.Size(174, 22);
            this.mnuLoaiThietBi.Text = "Loại thiết bị";
            this.mnuLoaiThietBi.Click += new System.EventHandler(this.mnuLoaiThietBi_Click);
            // 
            // mnuThietBiTheoLoai
            // 
            this.mnuThietBiTheoLoai.Name = "mnuThietBiTheoLoai";
            this.mnuThietBiTheoLoai.Size = new System.Drawing.Size(174, 22);
            this.mnuThietBiTheoLoai.Text = "Thiết bị theo loại";
            this.mnuThietBiTheoLoai.Click += new System.EventHandler(this.mnuThietBiTheoLoai_Click);
            // 
            // mnuThietBiThanhLy
            // 
            this.mnuThietBiThanhLy.Name = "mnuThietBiThanhLy";
            this.mnuThietBiThanhLy.Size = new System.Drawing.Size(174, 22);
            this.mnuThietBiThanhLy.Text = "Thiết bị thanh lý";
            this.mnuThietBiThanhLy.Click += new System.EventHandler(this.mnuThietBiThanhLy_Click);
            // 
            // mnuChucNang
            // 
            this.mnuChucNang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThanhLyThietBi,
            this.mnuBaoCao});
            this.mnuChucNang.Name = "mnuChucNang";
            this.mnuChucNang.Size = new System.Drawing.Size(82, 21);
            this.mnuChucNang.Text = "Chức năng";
            // 
            // mnuThanhLyThietBi
            // 
            this.mnuThanhLyThietBi.Name = "mnuThanhLyThietBi";
            this.mnuThanhLyThietBi.Size = new System.Drawing.Size(168, 22);
            this.mnuThanhLyThietBi.Text = "Thanh lý thiết bị";
            this.mnuThanhLyThietBi.Click += new System.EventHandler(this.mnuThanhLyThietBi_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDSCanBo,
            this.mnuDSThietBi});
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(168, 22);
            this.mnuBaoCao.Text = "Báo cáo";
            // 
            // mnuDSCanBo
            // 
            this.mnuDSCanBo.Name = "mnuDSCanBo";
            this.mnuDSCanBo.Size = new System.Drawing.Size(260, 22);
            this.mnuDSCanBo.Text = "Danh sách cán bộ theo bộ môn";
            //this.mnuDSCanBo.Click += new System.EventHandler(this.mnuDSCanBo_Click);
            // 
            // mnuDSThietBi
            // 
            this.mnuDSThietBi.Name = "mnuDSThietBi";
            this.mnuDSThietBi.Size = new System.Drawing.Size(260, 22);
            this.mnuDSThietBi.Text = "Danh sách thiết bị theo loại";
            //this.mnuDSThietBi.Click += new System.EventHandler(this.mnuDSThietBi_Click);
            // 
            // mnuTienIch
            // 
            this.mnuTienIch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNhap,
            this.mnuThoatDangNhap,
            this.mnuThoat});
            this.mnuTienIch.Name = "mnuTienIch";
            this.mnuTienIch.Size = new System.Drawing.Size(64, 21);
            this.mnuTienIch.Text = "Tiện ích";
            // 
            // mnuDangNhap
            // 
            this.mnuDangNhap.Name = "mnuDangNhap";
            this.mnuDangNhap.Size = new System.Drawing.Size(140, 22);
            this.mnuDangNhap.Text = "Đăng nhập";
            this.mnuDangNhap.Click += new System.EventHandler(this.mnuDangNhap_Click);
            // 
            // mnuThoatDangNhap
            // 
            this.mnuThoatDangNhap.Name = "mnuThoatDangNhap";
            this.mnuThoatDangNhap.Size = new System.Drawing.Size(140, 22);
            this.mnuThoatDangNhap.Text = "Đăng xuất";
            this.mnuThoatDangNhap.Click += new System.EventHandler(this.mnuThoatDangNhap_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(140, 22);
            this.mnuThoat.Text = "Đóng";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // mnuGioiThieu
            // 
            this.mnuGioiThieu.Name = "mnuGioiThieu";
            this.mnuGioiThieu.Size = new System.Drawing.Size(75, 21);
            this.mnuGioiThieu.Text = "Giới thiệu";
            this.mnuGioiThieu.Click += new System.EventHandler(this.mnuGioiThieu_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::QuanLySuDungThietBi.Properties.Resources.gtZoeMs;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(854, 433);
            this.Controls.Add(this.mnuQuanLySuDungThietBi);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuQuanLySuDungThietBi;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Sử Dụng Thiết Bị";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuQuanLySuDungThietBi.ResumeLayout(false);
            this.mnuQuanLySuDungThietBi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuQuanLySuDungThietBi;
        public System.Windows.Forms.ToolStripMenuItem mnuDangNhap;
        public System.Windows.Forms.ToolStripMenuItem mnuCanBo;
        public System.Windows.Forms.ToolStripMenuItem mnuCanBoTheoBoMon;
        public System.Windows.Forms.ToolStripMenuItem mnuBoMon;
        public System.Windows.Forms.ToolStripMenuItem mnuPhong;
        public System.Windows.Forms.ToolStripMenuItem mnuTienIch;
        public System.Windows.Forms.ToolStripMenuItem mnuThoat;
        public System.Windows.Forms.ToolStripMenuItem mnuGioiThieu;
        public System.Windows.Forms.ToolStripMenuItem mnuThoatDangNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuThietBi;
        private System.Windows.Forms.ToolStripMenuItem mnuLoaiThietBi;
        private System.Windows.Forms.ToolStripMenuItem mnuThietBiTheoLoai;
        private System.Windows.Forms.ToolStripMenuItem mnuThietBiThanhLy;
        private System.Windows.Forms.ToolStripMenuItem mnuChucNang;
        private System.Windows.Forms.ToolStripMenuItem mnuThanhLyThietBi;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuDSCanBo;
        private System.Windows.Forms.ToolStripMenuItem mnuDSThietBi;
    }
}

