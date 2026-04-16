namespace QLVanBang_Nhom4
{
    partial class FrmYeuCauCapLai
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
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvYeuCau = new System.Windows.Forms.DataGridView();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblMaYC = new System.Windows.Forms.Label();
            this.txtMaYC = new System.Windows.Forms.TextBox();
            this.lblVanBang = new System.Windows.Forms.Label();
            this.cboVanBang = new System.Windows.Forms.ComboBox();
            this.lblLoaiYeuCau = new System.Windows.Forms.Label();
            this.cboLoaiYeuCau = new System.Windows.Forms.ComboBox();
            this.lblLiDo = new System.Windows.Forms.Label();
            this.txtLiDo = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            this.BackColor = UIHelper.BgPage;
            this.Name = "FrmYeuCauCapLai"; this.Text = "Quản lý Yêu cầu cấp lại";
            this.Load += new System.EventHandler(this.FrmYeuCauCapLai_Load);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);

            // pnlTop
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top; this.pnlTop.Height = 60;
            this.pnlTop.BackColor = UIHelper.BgPanel; this.pnlTop.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlTop.Controls.Add(this.lblSoLuong);
            this.pnlTop.Controls.Add(this.cboLocTrangThai);
            this.pnlTop.Controls.Add(this.txtTimKiem);
            this.pnlTop.Controls.Add(this.lblTieuDe);

            this.lblTieuDe.Text = "📝 Yêu cầu cấp lại / Chỉnh sửa"; this.lblTieuDe.Font = UIHelper.FontTitle;
            this.lblTieuDe.ForeColor = UIHelper.TextPrimary; this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(16, 14);

            this.txtTimKiem.Font = UIHelper.FontLabel; this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtTimKiem.Size = new System.Drawing.Size(280, 28); this.txtTimKiem.Location = new System.Drawing.Point(350, 17);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Text = "🔍  Tìm theo mã, văn bằng, lý do...";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            this.cboLocTrangThai.Font = UIHelper.FontLabel; this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Size = new System.Drawing.Size(140, 28); this.cboLocTrangThai.Location = new System.Drawing.Point(642, 16);
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);

            this.lblSoLuong.Text = string.Empty; this.lblSoLuong.Font = UIHelper.FontSmall;
            this.lblSoLuong.ForeColor = UIHelper.TextSecondary; this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(800, 22);

            // pnlContent
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Padding = new System.Windows.Forms.Padding(12);
            this.pnlContent.Controls.Add(this.pnlDetail);
            this.pnlContent.Controls.Add(this.dgvYeuCau);

            this.dgvYeuCau.Dock = System.Windows.Forms.DockStyle.Fill;
            UIHelper.StyleDataGridView(this.dgvYeuCau);
            this.dgvYeuCau.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYeuCau_CellClick);

            // pnlDetail
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Right; this.pnlDetail.Width = 320;
            this.pnlDetail.BackColor = UIHelper.BgPanel; this.pnlDetail.Padding = new System.Windows.Forms.Padding(16);

            int y = 16; int w = 280;
            F(this.lblMaYC, "MÃ YÊU CẦU", this.txtMaYC, this.pnlDetail, ref y, w);
            C(this.lblVanBang, "VĂN BẰNG", this.cboVanBang, this.pnlDetail, ref y, w);
            C(this.lblLoaiYeuCau, "LOẠI YÊU CẦU", this.cboLoaiYeuCau, this.pnlDetail, ref y, w);
            M(this.lblLiDo, "LÝ DO", this.txtLiDo, this.pnlDetail, ref y, w);
            C(this.lblTrangThai, "TRẠNG THÁI", this.cboTrangThai, this.pnlDetail, ref y, w);
            M(this.lblGhiChu, "GHI CHÚ", this.txtGhiChu, this.pnlDetail, ref y, w);

            this.lblThongBao.Location = new System.Drawing.Point(16, y);
            this.lblThongBao.Size = new System.Drawing.Size(w, 18);
            this.lblThongBao.Font = UIHelper.FontSmall; this.lblThongBao.Text = string.Empty;
            this.pnlDetail.Controls.Add(this.lblThongBao); y += 24;

            this.pnlButtons.Location = new System.Drawing.Point(16, y);
            this.pnlButtons.Size = new System.Drawing.Size(w, 40);
            this.pnlButtons.BackColor = UIHelper.BgPanel;
            this.pnlDetail.Controls.Add(this.pnlButtons);
            this.pnlButtons.Controls.Add(this.btnLamMoi);
            this.pnlButtons.Controls.Add(this.btnXoa);
            this.pnlButtons.Controls.Add(this.btnDuyet);
            this.pnlButtons.Controls.Add(this.btnThem);

            SB(this.btnThem, "Thêm", UIHelper.AccentGreen, new System.Drawing.Point(0, 0), 66);
            SB(this.btnDuyet, "Duyệt", UIHelper.PrimaryBlue, new System.Drawing.Point(70, 0), 66);
            SB(this.btnXoa, "Xóa", UIHelper.AccentRed, new System.Drawing.Point(140, 0), 66);
            SB(this.btnLamMoi, "Mới", System.Drawing.Color.FromArgb(100, 116, 139), new System.Drawing.Point(210, 0), 66);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.pnlTop.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).EndInit();
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

        private static void C(System.Windows.Forms.Label l, string cap, System.Windows.Forms.ComboBox c,
            System.Windows.Forms.Panel p, ref int y, int w)
        {
            l.Text = cap; l.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            l.ForeColor = UIHelper.TextSecondary; l.AutoSize = true;
            l.Location = new System.Drawing.Point(16, y); p.Controls.Add(l); y += 18;
            c.Location = new System.Drawing.Point(16, y); c.Width = w; c.Font = UIHelper.FontLabel;
            p.Controls.Add(c); y += 32;
        }

        private static void M(System.Windows.Forms.Label l, string cap, System.Windows.Forms.TextBox t,
            System.Windows.Forms.Panel p, ref int y, int w)
        {
            l.Text = cap; l.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            l.ForeColor = UIHelper.TextSecondary; l.AutoSize = true;
            l.Location = new System.Drawing.Point(16, y); p.Controls.Add(l); y += 18;
            t.Location = new System.Drawing.Point(16, y); t.Width = w; t.Height = 52;
            t.Multiline = true; t.Font = UIHelper.FontLabel;
            t.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            t.BackColor = System.Drawing.Color.FromArgb(248, 250, 252); p.Controls.Add(t); y += 58;
        }

        private static void SB(System.Windows.Forms.Button btn, string text, System.Drawing.Color color,
            System.Drawing.Point loc, int width)
        {
            btn.Text = text; btn.Font = UIHelper.FontButton; btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White; btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0; btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Location = loc; btn.Size = new System.Drawing.Size(width, 36);
        }
        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvYeuCau;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblMaYC;
        private System.Windows.Forms.TextBox txtMaYC;
        private System.Windows.Forms.Label lblVanBang;
        private System.Windows.Forms.ComboBox cboVanBang;
        private System.Windows.Forms.Label lblLoaiYeuCau;
        private System.Windows.Forms.ComboBox cboLoaiYeuCau;
        private System.Windows.Forms.Label lblLiDo;
        private System.Windows.Forms.TextBox txtLiDo;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
    }

}