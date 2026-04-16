namespace QLVanBang_Nhom4
{
    partial class FrmLogin
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
            this.pnlOuter = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppDesc = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblDangNhap = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.chkHienMatKhau = new System.Windows.Forms.CheckBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.pnlOuter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────────────────
            this.ClientSize = new System.Drawing.Size(820, 520);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = UIHelper.BgPanel;
            this.Name = "FrmLogin";
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.Controls.Add(this.pnlOuter);

            // ── pnlOuter ──────────────────────────────────────────────────
            this.pnlOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOuter.Controls.Add(this.pnlRight);
            this.pnlOuter.Controls.Add(this.pnlLeft);

            // ── pnlLeft (banner) ──────────────────────────────────────────
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Width = 340;
            this.pnlLeft.BackColor = UIHelper.PrimaryBlue;
            this.pnlLeft.Controls.Add(this.lblAppDesc);
            this.pnlLeft.Controls.Add(this.lblAppName);
            this.pnlLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            this.pnlLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseMove);
            this.pnlLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseUp);

            // lblAppName
            this.lblAppName.Text = "QL VĂN BẰNG";
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 22f, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.AutoSize = false;
            this.lblAppName.Width = 300;
            this.lblAppName.Height = 50;
            this.lblAppName.Location = new System.Drawing.Point(20, 190);
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblAppDesc
            this.lblAppDesc.Text = "Hệ thống Quản lý\nVăn bằng & Chứng chỉ";
            this.lblAppDesc.Font = new System.Drawing.Font("Segoe UI", 11f);
            this.lblAppDesc.ForeColor = System.Drawing.Color.FromArgb(200, 230, 255);
            this.lblAppDesc.AutoSize = false;
            this.lblAppDesc.Width = 300;
            this.lblAppDesc.Height = 60;
            this.lblAppDesc.Location = new System.Drawing.Point(20, 250);
            this.lblAppDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // ── pnlRight ──────────────────────────────────────────────────
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.BackColor = UIHelper.BgPanel;
            this.pnlRight.Controls.Add(this.pnlHeader);
            this.pnlRight.Controls.Add(this.pnlForm);

            // ── pnlHeader (top bar for dragging + close) ──────────────────
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 40;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseMove);
            this.pnlHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseUp);

            this.lblTieuDe.Text = "Hệ thống Quản lý Văn bằng";
            this.lblTieuDe.Font = UIHelper.FontSmall;
            this.lblTieuDe.ForeColor = UIHelper.TextSecondary;
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(12, 12);

            // ── pnlForm (login fields) ────────────────────────────────────
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.BackColor = UIHelper.BgPanel;
            this.pnlForm.Padding = new System.Windows.Forms.Padding(50, 60, 50, 40);
            this.pnlForm.Controls.Add(this.lblDangNhap);
            this.pnlForm.Controls.Add(this.lblSubtitle);
            this.pnlForm.Controls.Add(this.lblTaiKhoan);
            this.pnlForm.Controls.Add(this.txtTaiKhoan);
            this.pnlForm.Controls.Add(this.lblMatKhau);
            this.pnlForm.Controls.Add(this.txtMatKhau);
            this.pnlForm.Controls.Add(this.chkHienMatKhau);
            this.pnlForm.Controls.Add(this.btnDangNhap);
            this.pnlForm.Controls.Add(this.btnThoat);
            this.pnlForm.Controls.Add(this.lblThongBao);

            // lblDangNhap
            this.lblDangNhap.Text = "Đăng nhập";
            this.lblDangNhap.Font = new System.Drawing.Font("Segoe UI", 20f, System.Drawing.FontStyle.Bold);
            this.lblDangNhap.ForeColor = UIHelper.TextPrimary;
            this.lblDangNhap.AutoSize = true;
            this.lblDangNhap.Location = new System.Drawing.Point(50, 60);

            // lblSubtitle
            this.lblSubtitle.Text = "Nhập thông tin tài khoản để tiếp tục";
            this.lblSubtitle.Font = UIHelper.FontSubtitle;
            this.lblSubtitle.ForeColor = UIHelper.TextSecondary;
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(50, 95);

            // lblTaiKhoan
            this.lblTaiKhoan.Text = "TÀI KHOẢN";
            this.lblTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lblTaiKhoan.ForeColor = UIHelper.TextSecondary;
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.Location = new System.Drawing.Point(50, 148);

            // txtTaiKhoan
            this.txtTaiKhoan.Location = new System.Drawing.Point(50, 168);
            this.txtTaiKhoan.Size = new System.Drawing.Size(340, 34);
            this.txtTaiKhoan.Font = UIHelper.FontSubtitle;
            this.txtTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaiKhoan.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);

            // lblMatKhau
            this.lblMatKhau.Text = "MẬT KHẨU";
            this.lblMatKhau.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lblMatKhau.ForeColor = UIHelper.TextSecondary;
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(50, 222);

            // txtMatKhau
            this.txtMatKhau.Location = new System.Drawing.Point(50, 242);
            this.txtMatKhau.Size = new System.Drawing.Size(340, 34);
            this.txtMatKhau.Font = UIHelper.FontSubtitle;
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhau.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtMatKhau.PasswordChar = '●';

            // chkHienMatKhau
            this.chkHienMatKhau.Text = "Hiện mật khẩu";
            this.chkHienMatKhau.Font = UIHelper.FontLabel;
            this.chkHienMatKhau.ForeColor = UIHelper.TextSecondary;
            this.chkHienMatKhau.AutoSize = true;
            this.chkHienMatKhau.Location = new System.Drawing.Point(52, 285);
            this.chkHienMatKhau.CheckedChanged += new System.EventHandler(this.chkHienMatKhau_CheckedChanged);

            // lblThongBao
            this.lblThongBao.Text = string.Empty;
            this.lblThongBao.Font = UIHelper.FontLabel;
            this.lblThongBao.ForeColor = UIHelper.AccentRed;
            this.lblThongBao.AutoSize = false;
            this.lblThongBao.Size = new System.Drawing.Size(340, 20);
            this.lblThongBao.Location = new System.Drawing.Point(50, 313);
            this.lblThongBao.Visible = false;

            // btnDangNhap
            this.btnDangNhap.Text = "ĐĂNG NHẬP";
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnDangNhap.BackColor = UIHelper.PrimaryBlue;
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.Location = new System.Drawing.Point(50, 345);
            this.btnDangNhap.Size = new System.Drawing.Size(340, 44);
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);

            // btnThoat
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Font = UIHelper.FontButton;
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnThoat.ForeColor = UIHelper.TextSecondary;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Location = new System.Drawing.Point(50, 400);
            this.btnThoat.Size = new System.Drawing.Size(340, 36);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            this.pnlOuter.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlOuter;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppDesc;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblDangNhap;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.CheckBox chkHienMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblThongBao;
    }
}