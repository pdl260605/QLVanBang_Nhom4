namespace QLVanBang_Nhom4
{
    partial class FrmSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────────────────
            this.BackColor = UIHelper.BgPage;
            this.Name = "FrmSinhVien";
            this.Text = "Quản lý Sinh viên";
            this.Load += new System.EventHandler(this.FrmSinhVien_Load);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);

            // ── pnlTop ────────────────────────────────────────────────────
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.BackColor = UIHelper.BgPanel;
            this.pnlTop.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlTop.Controls.Add(this.lblSoLuong);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.lblTieuDe);

            this.lblTieuDe.Text = "👤 Quản lý Sinh viên";
            this.lblTieuDe.Font = UIHelper.FontTitle;
            this.lblTieuDe.ForeColor = UIHelper.TextPrimary;
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(16, 14);

            this.txtTimKiem.Font = UIHelper.FontLabel;
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtTimKiem.Text = "🔍  Tìm kiếm theo mã, họ tên, CCCD, email...";
            this.txtTimKiem.Size = new System.Drawing.Size(320, 28);
            this.txtTimKiem.Location = new System.Drawing.Point(300, 17);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            this.lblSoLuong.Text = string.Empty;
            this.lblSoLuong.Font = UIHelper.FontSmall;
            this.lblSoLuong.ForeColor = UIHelper.TextSecondary;
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(640, 22);

            // ── pnlContent ────────────────────────────────────────────────
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(12);
            this.pnlContent.Controls.Add(this.pnlDetail);
            this.pnlContent.Controls.Add(this.dgvSinhVien);

            // ── dgvSinhVien ───────────────────────────────────────────────
            this.dgvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            UIHelper.StyleDataGridView(this.dgvSinhVien);
            this.dgvSinhVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinhVien_CellClick);

            // ── pnlDetail (form nhập liệu) ────────────────────────────────
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetail.Width = 320;
            this.pnlDetail.BackColor = UIHelper.BgPanel;
            this.pnlDetail.Padding = new System.Windows.Forms.Padding(16);
            this.pnlDetail.Controls.Add(this.pnlButtons);
            this.pnlDetail.Controls.Add(this.lblThongBao);
            this.pnlDetail.Controls.Add(this.txtDiaChi);
            this.pnlDetail.Controls.Add(this.lblDiaChi);
            this.pnlDetail.Controls.Add(this.txtSDT);
            this.pnlDetail.Controls.Add(this.lblSDT);
            this.pnlDetail.Controls.Add(this.txtEmail);
            this.pnlDetail.Controls.Add(this.lblEmail);
            this.pnlDetail.Controls.Add(this.txtCCCD);
            this.pnlDetail.Controls.Add(this.lblCCCD);
            this.pnlDetail.Controls.Add(this.cboGioiTinh);
            this.pnlDetail.Controls.Add(this.lblGioiTinh);
            this.pnlDetail.Controls.Add(this.dtpNgaySinh);
            this.pnlDetail.Controls.Add(this.lblNgaySinh);
            this.pnlDetail.Controls.Add(this.txtHoTen);
            this.pnlDetail.Controls.Add(this.lblHoTen);
            this.pnlDetail.Controls.Add(this.txtMaSV);
            this.pnlDetail.Controls.Add(this.lblMaSV);

            int y = 16; int w = 280;

            AddField(this.lblMaSV, "MÃ SINH VIÊN", this.txtMaSV, ref y, w); y += 4;
            AddField(this.lblHoTen, "HỌ VÀ TÊN", this.txtHoTen, ref y, w); y += 4;
            // NgaySinh
            this.lblNgaySinh.Text = "NGÀY SINH"; this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lblNgaySinh.ForeColor = UIHelper.TextSecondary; this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(16, y); y += 18;
            this.dtpNgaySinh.Location = new System.Drawing.Point(16, y); this.dtpNgaySinh.Width = w;
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Font = UIHelper.FontLabel; y += 30;
            // GioiTinh
            this.lblGioiTinh.Text = "GIỚI TÍNH"; this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lblGioiTinh.ForeColor = UIHelper.TextSecondary; this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(16, y); y += 18;
            this.cboGioiTinh.Location = new System.Drawing.Point(16, y); this.cboGioiTinh.Width = w;
            this.cboGioiTinh.Font = UIHelper.FontLabel;
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; y += 30;

            AddField(this.lblCCCD, "CCCD", this.txtCCCD, ref y, w); y += 4;
            AddField(this.lblEmail, "EMAIL", this.txtEmail, ref y, w); y += 4;
            AddField(this.lblSDT, "SỐ ĐIỆN THOẠI", this.txtSDT, ref y, w); y += 4;

            this.lblDiaChi.Text = "ĐỊA CHỈ"; this.lblDiaChi.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            this.lblDiaChi.ForeColor = UIHelper.TextSecondary; this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(16, y); y += 18;
            this.txtDiaChi.Location = new System.Drawing.Point(16, y); this.txtDiaChi.Width = w;
            this.txtDiaChi.Height = 54; this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Font = UIHelper.FontLabel;
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; y += 62;

            this.lblThongBao.Location = new System.Drawing.Point(16, y);
            this.lblThongBao.Size = new System.Drawing.Size(w, 20);
            this.lblThongBao.Font = UIHelper.FontSmall;
            this.lblThongBao.Text = string.Empty; y += 26;

            // Buttons
            this.pnlButtons.Location = new System.Drawing.Point(16, y);
            this.pnlButtons.Size = new System.Drawing.Size(w, 40);
            this.pnlButtons.BackColor = UIHelper.BgPanel;
            this.pnlButtons.Controls.Add(this.btnLamMoi);
            this.pnlButtons.Controls.Add(this.btnXoa);
            this.pnlButtons.Controls.Add(this.btnSua);
            this.pnlButtons.Controls.Add(this.btnThem);

            int bw = 66;
            SetupBtn(this.btnThem, "Thêm", UIHelper.AccentGreen, new System.Drawing.Point(0, 0), bw);
            SetupBtn(this.btnSua, "Sửa", UIHelper.PrimaryBlue, new System.Drawing.Point(70, 0), bw);
            SetupBtn(this.btnXoa, "Xóa", UIHelper.AccentRed, new System.Drawing.Point(140, 0), bw);
            SetupBtn(this.btnLamMoi, "Mới", System.Drawing.Color.FromArgb(100, 116, 139),
                                                                       new System.Drawing.Point(210, 0), bw);

            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.pnlTop.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private static void AddField(System.Windows.Forms.Label lbl, string caption,
                                     System.Windows.Forms.TextBox txt, ref int y, int w)
        {
            lbl.Text = caption;
            lbl.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = UIHelper.TextSecondary;
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(16, y); y += 18;
            txt.Location = new System.Drawing.Point(16, y);
            txt.Width = w; txt.Height = 28;
            txt.Font = UIHelper.FontLabel;
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.BackColor = System.Drawing.Color.FromArgb(248, 250, 252); y += 34;
        }

        private static void SetupBtn(System.Windows.Forms.Button btn, string text,
                                     System.Drawing.Color color, System.Drawing.Point loc, int width)
        {
            btn.Text = text; btn.Font = UIHelper.FontButton;
            btn.BackColor = color; btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Location = loc; btn.Size = new System.Drawing.Size(width, 36);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
    }

}