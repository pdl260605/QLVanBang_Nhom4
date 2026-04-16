namespace QLVanBang_Nhom4
{
    partial class FrmNguoiDung
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboLocVaiTro = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvNguoiDung = new System.Windows.Forms.DataGridView();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblXacNhanMK = new System.Windows.Forms.Label();
            this.txtXacNhanMK = new System.Windows.Forms.TextBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnDatLaiMK = new System.Windows.Forms.Button();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            this.BackColor = UIHelper.BgPage;
            this.Name = "FrmNguoiDung"; this.Text = "Quản lý Người dùng";
            this.Load += new System.EventHandler(this.FrmNguoiDung_Load);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);

            // pnlTop
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top; this.pnlTop.Height = 60;
            this.pnlTop.BackColor = UIHelper.BgPanel; this.pnlTop.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlTop.Controls.Add(this.lblSoLuong);
            this.pnlTop.Controls.Add(this.cboLocVaiTro);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.lblTieuDe);

            this.lblTieuDe.Text = "⚙ Quản lý Người dùng"; this.lblTieuDe.Font = UIHelper.FontTitle;
            this.lblTieuDe.ForeColor = UIHelper.TextPrimary; this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(16, 14);

            this.txtTimKiem.Text = "🔍  Tìm tài khoản, họ tên, email...";
            this.txtTimKiem.Font = UIHelper.FontLabel; this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtTimKiem.Size = new System.Drawing.Size(260, 28); this.txtTimKiem.Location = new System.Drawing.Point(300, 17);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            this.cboLocVaiTro.Font = UIHelper.FontLabel; this.cboLocVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocVaiTro.Size = new System.Drawing.Size(130, 28); this.cboLocVaiTro.Location = new System.Drawing.Point(572, 16);
            this.cboLocVaiTro.SelectedIndexChanged += new System.EventHandler(this.cboLocVaiTro_SelectedIndexChanged);

            this.lblSoLuong.Text = string.Empty; this.lblSoLuong.Font = UIHelper.FontSmall;
            this.lblSoLuong.ForeColor = UIHelper.TextSecondary; this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(720, 22);

            // pnlContent
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(12);
            this.pnlContent.Controls.Add(this.pnlDetail);
            this.pnlContent.Controls.Add(this.dgvNguoiDung);

            this.dgvNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            UIHelper.StyleDataGridView(this.dgvNguoiDung);
            this.dgvNguoiDung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguoiDung_CellClick);

            // pnlDetail
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right; this.pnlDetail.Width = 320;
            this.pnlDetail.BackColor = UIHelper.BgPanel; this.pnlDetail.Padding = new System.Windows.Forms.Padding(16);

            int y = 16; int w = 280;
            F(this.lblTenDangNhap, "TÀI KHOẢN", this.txtTenDangNhap, this.pnlDetail, ref y, w);
            F(this.lblHoTen, "HỌ VÀ TÊN", this.txtHoTen, this.pnlDetail, ref y, w);
            C(this.lblVaiTro, "VAI TRÒ", this.cboVaiTro, this.pnlDetail, ref y, w);
            F(this.lblEmail, "EMAIL", this.txtEmail, this.pnlDetail, ref y, w);

            // Divider
            var lbl = new System.Windows.Forms.Label
            {
                Text = "──── Đặt lại mật khẩu ────",
                Font = UIHelper.FontSmall,
                ForeColor = UIHelper.TextSecondary,
                AutoSize = true,
                Location = new System.Drawing.Point(16, y)
            };
            this.pnlDetail.Controls.Add(lbl); y += 22;

            FP(this.lblMatKhau, "MẬT KHẨU MỚI", this.txtMatKhau, this.pnlDetail, ref y, w);
            FP(this.lblXacNhanMK, "XÁC NHẬN MK", this.txtXacNhanMK, this.pnlDetail, ref y, w);

            this.lblThongBao.Location = new System.Drawing.Point(16, y);
            this.lblThongBao.Size = new System.Drawing.Size(w, 18);
            this.lblThongBao.Font = UIHelper.FontSmall; this.lblThongBao.Text = string.Empty;
            this.pnlDetail.Controls.Add(this.lblThongBao); y += 24;

            this.pnlButtons.Location = new System.Drawing.Point(16, y);
            this.pnlButtons.Size = new System.Drawing.Size(w, 76);
            this.pnlButtons.BackColor = UIHelper.BgPanel;
            this.pnlDetail.Controls.Add(this.pnlButtons);
            this.pnlButtons.Controls.Add(this.btnLamMoi);
            this.pnlButtons.Controls.Add(this.btnKhoa);
            this.pnlButtons.Controls.Add(this.btnDatLaiMK);
            this.pnlButtons.Controls.Add(this.btnSua);
            this.pnlButtons.Controls.Add(this.btnThem);

            // Row 1: Thêm + Sửa
            SB(this.btnThem, "Thêm mới", UIHelper.AccentGreen, new System.Drawing.Point(0, 0), 136);
            SB(this.btnSua, "Cập nhật", UIHelper.PrimaryBlue, new System.Drawing.Point(140, 0), 136);
            // Row 2: Đặt lại MK + Khoá + Mới
            SB(this.btnDatLaiMK, "Đặt lại MK", System.Drawing.Color.FromArgb(245, 158, 11), new System.Drawing.Point(0, 40), 136);
            SB(this.btnKhoa, "Khoá/Mở", UIHelper.AccentRed, new System.Drawing.Point(140, 40), 86);
            SB(this.btnLamMoi, "Mới", System.Drawing.Color.FromArgb(100, 116, 139), new System.Drawing.Point(230, 40), 46);

            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnDatLaiMK.Click += new System.EventHandler(this.btnDatLaiMK_Click);
            this.btnKhoa.Click += new System.EventHandler(this.btnKhoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.pnlTop.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private static void F(System.Windows.Forms.Label l, string cap, System.Windows.Forms.TextBox t,
            System.Windows.Forms.Panel p, ref int y, int w)
        {
            l.Text = cap; l.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            l.ForeColor = UIHelper.TextSecondary; l.AutoSize = true;
            l.Location = new System.Drawing.Point(16, y); p.Controls.Add(l); y += 18;
            t.Location = new System.Drawing.Point(16, y); t.Width = w; t.Height = 28;
            t.Font = UIHelper.FontLabel; t.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            t.BackColor = System.Drawing.Color.FromArgb(248, 250, 252); p.Controls.Add(t); y += 34;
        }

        private static void FP(System.Windows.Forms.Label l, string cap, System.Windows.Forms.TextBox t,
            System.Windows.Forms.Panel p, ref int y, int w)
        {
            F(l, cap, t, p, ref y, w);
            t.PasswordChar = '●';
        }

        private static void C(System.Windows.Forms.Label l, string cap, System.Windows.Forms.ComboBox c,
            System.Windows.Forms.Panel p, ref int y, int w)
        {
            l.Text = cap; l.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            l.ForeColor = UIHelper.TextSecondary; l.AutoSize = true;
            l.Location = new System.Drawing.Point(16, y); p.Controls.Add(l); y += 18;
            c.Location = new System.Drawing.Point(16, y); c.Width = w; c.Font = UIHelper.FontLabel;
            c.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            p.Controls.Add(c); y += 32;
        }

        private static void SB(System.Windows.Forms.Button btn, string text, System.Drawing.Color color,
            System.Drawing.Point loc, int width)
        {
            btn.Text = text; btn.Font = UIHelper.FontButton; btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White; btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0; btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Location = loc; btn.Size = new System.Drawing.Size(width, 34);
        }
        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocVaiTro;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvNguoiDung;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblXacNhanMK;
        private System.Windows.Forms.TextBox txtXacNhanMK;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnDatLaiMK;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnLamMoi;
    }

}