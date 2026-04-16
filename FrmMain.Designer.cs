namespace QLVanBang_Nhom4
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnSinhVien = new System.Windows.Forms.Button();
            this.btnVanBang = new System.Windows.Forms.Button();
            this.btnNganhHoc = new System.Windows.Forms.Button();
            this.btnDonViCap = new System.Windows.Forms.Button();
            this.btnYeuCauCapLai = new System.Windows.Forms.Button();
            this.btnLichSuChinhSua = new System.Windows.Forms.Button();
            this.btnNguoiDung = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = UIHelper.BgPage;
            this.Name = "FrmMain";
            this.Text = "Hệ thống Quản lý Văn bằng";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Controls.Add(this.pnlSidebar);

            // ── pnlSidebar ────────────────────────────────────────────────
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width = 220;
            this.pnlSidebar.BackColor = UIHelper.BgSidebar;
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Controls.Add(this.pnlNav);
            this.pnlSidebar.Controls.Add(this.pnlBottom);

            // ── pnlLogo ───────────────────────────────────────────────────
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Height = 70;
            this.pnlLogo.BackColor = UIHelper.PrimaryDark;
            this.pnlLogo.Controls.Add(this.lblLogo);

            this.lblLogo.Text = "📜 QL VĂN BẰNG";
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── pnlNav ────────────────────────────────────────────────────
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.AutoSize = true;
            this.pnlNav.BackColor = UIHelper.BgSidebar;
            this.pnlNav.Controls.Add(this.btnNguoiDung);
            this.pnlNav.Controls.Add(this.btnLichSuChinhSua);
            this.pnlNav.Controls.Add(this.btnYeuCauCapLai);
            this.pnlNav.Controls.Add(this.btnDonViCap);
            this.pnlNav.Controls.Add(this.btnNganhHoc);
            this.pnlNav.Controls.Add(this.btnVanBang);
            this.pnlNav.Controls.Add(this.btnSinhVien);
            this.pnlNav.Controls.Add(this.btnDashboard);

            // Helper để tạo nav button
            SetupNavButton(this.btnDashboard, "🏠  Tổng quan", 0);
            SetupNavButton(this.btnSinhVien, "👤  Sinh viên", 1);
            SetupNavButton(this.btnVanBang, "📋  Văn bằng", 2);
            SetupNavButton(this.btnNganhHoc, "🎓  Ngành học", 3);
            SetupNavButton(this.btnDonViCap, "🏛  Đơn vị cấp", 4);
            SetupNavButton(this.btnYeuCauCapLai, "📝  Yêu cầu cấp lại", 5);
            SetupNavButton(this.btnLichSuChinhSua, "🕐  Lịch sử chỉnh sửa", 6);
            SetupNavButton(this.btnNguoiDung, "⚙  Người dùng", 7);

            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            this.btnSinhVien.Click += new System.EventHandler(this.btnSinhVien_Click);
            this.btnVanBang.Click += new System.EventHandler(this.btnVanBang_Click);
            this.btnNganhHoc.Click += new System.EventHandler(this.btnNganhHoc_Click);
            this.btnDonViCap.Click += new System.EventHandler(this.btnDonViCap_Click);
            this.btnYeuCauCapLai.Click += new System.EventHandler(this.btnYeuCauCapLai_Click);
            this.btnLichSuChinhSua.Click += new System.EventHandler(this.btnLichSuChinhSua_Click);
            this.btnNguoiDung.Click += new System.EventHandler(this.btnNguoiDung_Click);

            // ── pnlBottom ─────────────────────────────────────────────────
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 100;
            this.pnlBottom.BackColor = UIHelper.PrimaryDark;
            this.pnlBottom.Controls.Add(this.btnDangXuat);
            this.pnlBottom.Controls.Add(this.lblVaiTro);
            this.pnlBottom.Controls.Add(this.lblNguoiDung);

            this.lblNguoiDung.Text = string.Empty;
            this.lblNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblNguoiDung.ForeColor = System.Drawing.Color.White;
            this.lblNguoiDung.AutoSize = false;
            this.lblNguoiDung.Dock = System.Windows.Forms.DockStyle.None;
            this.lblNguoiDung.Size = new System.Drawing.Size(200, 20);
            this.lblNguoiDung.Location = new System.Drawing.Point(12, 10);

            this.lblVaiTro.Text = string.Empty;
            this.lblVaiTro.Font = UIHelper.FontSmall;
            this.lblVaiTro.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblVaiTro.AutoSize = false;
            this.lblVaiTro.Size = new System.Drawing.Size(200, 18);
            this.lblVaiTro.Location = new System.Drawing.Point(12, 32);

            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Font = UIHelper.FontButton;
            this.btnDangXuat.BackColor = UIHelper.AccentRed;
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Size = new System.Drawing.Size(196, 34);
            this.btnDangXuat.Location = new System.Drawing.Point(12, 56);
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private static void SetupNavButton(System.Windows.Forms.Button btn, string text, int index)
        {
            btn.Text = text;
            btn.Font = UIHelper.FontButton;
            btn.BackColor = UIHelper.BgSidebar;
            btn.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = UIHelper.SidebarHover;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Dock = System.Windows.Forms.DockStyle.Top;
            btn.Height = 46;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnSinhVien;
        private System.Windows.Forms.Button btnVanBang;
        private System.Windows.Forms.Button btnNganhHoc;
        private System.Windows.Forms.Button btnDonViCap;
        private System.Windows.Forms.Button btnYeuCauCapLai;
        private System.Windows.Forms.Button btnLichSuChinhSua;
        private System.Windows.Forms.Button btnNguoiDung;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblNguoiDung;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Button btnDangXuat;
    }
}